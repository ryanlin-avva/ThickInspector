using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Diagnostics;

namespace SInspector
{
    class Draw3DBase
    {
        private Panel panel;
        private ChartStyle cs;
       
        //3D para
        private Matrix3 transMatrix;
        private Point3[] pts;
        public Draw3DBase(Panel p, ChartStyle cs3d)
        {
            panel = p;
            cs = cs3d;
        }
        private void AddAxes(Graphics g)
        {
            Point3[] pta = new Point3[pts.Length];
            for (int i=0; i< pts.Length; i++)
            {
                pta[i] = new Point3(pts[i]);
            }
            using (Pen apen = new Pen(cs.AxisColor, cs.AxisThickness))
            {
                apen.DashStyle = cs.AxisStyle;
                for (int i = 0; i < pta.Length; i++)
                {
                    pta[i].Transform(transMatrix, panel.Size, cs);
                }
                g.DrawLine(apen, pta[0].X, pta[0].Y, pta[1].X, pta[1].Y);
                g.DrawLine(apen, pta[1].X, pta[1].Y, pta[2].X, pta[2].Y);
                g.DrawLine(apen, pta[2].X, pta[2].Y, pta[3].X, pta[3].Y);
            }
        }

        //使用固定elevation與azimuth
        //elevation > 0, -90< azimuth < 0
        private void AddTicks(Graphics g)
        {
            Point3[] pta = new Point3[2];
            Point3 labelPt;
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            SolidBrush tbrush = new SolidBrush(cs.TickColor);
            SolidBrush abrush = new SolidBrush(cs.LabelColor);
            Pen apen = new Pen(cs.AxisColor, cs.AxisThickness);
            apen.DashStyle = cs.AxisStyle;
            SizeF tickNumberOffset = g.MeasureString(cs.XMax.ToString(".#"), cs.TickFont);
            SizeF labelOffset = g.MeasureString(cs.XLabel.ToString(), cs.LabelFont);
            //int nameMappingPos = Constants.Draw3DXTickNumber / 3;
            int keepIdx = 1;
            //PointF namePt = new PointF();
            for (float x = cs.XMin + cs.XTick; x < cs.XMax; x += cs.XTick)
            {
                labelPt = new Point3(x + tickNumberOffset.Height / 2
                    , pts[1].Y + tickNumberOffset.Width / 2
                    , pts[1].Z, pts[1].W);
                labelPt.Transform(transMatrix, panel.Size, cs);
                g.DrawString(x.ToString(".#"), cs.TickFont, tbrush
                    , new PointF(labelPt.X, labelPt.Y), sf);
                keepIdx++;
                //if (keepIdx < nameMappingPos)
                //{
                //    keepIdx++;
                //}
                //else
                //{
                //    SizeF s = g.MeasureString(x.ToString(".#"), cs.TickFont);
                //    namePt = new PointF(labelPt.X + s.Width + 6, labelPt.Y);
                //    keepIdx = -Constants.Draw3DXTickNumber;
                //}
            }

            //Add x axis label
            //pta[0] = new Point3(pts[0]);
            //pta[0].Transform(transMatrix, panel.Size, cs);
            //pta[1] = new Point3(pts[1]);
            //pta[1].Transform(transMatrix, panel.Size, cs);
            //float theta = (float)Math.Atan((pta[1].Y - pta[0].Y) / (pta[1].X - pta[0].X));
            //theta = theta * 180 / (float)Math.PI;
            //GraphicsState gs = g.Save();
            //g.TranslateTransform(namePt.X, namePt.Y);
            //g.RotateTransform(theta);
            //g.DrawString(cs.XLabel, cs.LabelFont, abrush, new PointF(0, 0), sf);
            //g.Restore(gs);

            //Use keepIdx / 2 * cs.XTick + cs.XTick / 2 to put labelX between 2 ticks
            float pos_x = (keepIdx + 1) * cs.XTick / 2.0f;
            labelPt = new Point3(pos_x
                        , pts[1].Y + tickNumberOffset.Width
                        , pts[1].Z, pts[1].W);
            labelPt.Transform(transMatrix, panel.Size, cs);
            g.DrawString(cs.XLabel, cs.LabelFont, abrush
                , new PointF(labelPt.X, labelPt.Y + labelOffset.Height / 2.0f));

            //Add y ticks
            tickNumberOffset = g.MeasureString(cs.YMax.ToString(".#"), cs.TickFont);
            //nameMappingPos = Constants.Draw3DYTickNumber * 2 / 3;
            //keepIdx = 1;
            for (float y = cs.YMin + cs.YTick; y < cs.YMax; y += cs.YTick)
            {
                labelPt = new Point3(pts[1].X , y, pts[1].Z, pts[1].W);
                labelPt.Transform(transMatrix, panel.Size, cs);
                g.DrawString(y.ToString(".#"), cs.TickFont, tbrush
                    , new PointF(labelPt.X, labelPt.Y+3), sf);
                //if (keepIdx < nameMappingPos)
                //{
                //    keepIdx++;
                //}
                //else
                //{
                //    SizeF s = g.MeasureString(y.ToString(".#"), cs.TickFont);
                //    namePt = new PointF(labelPt.X, labelPt.Y + s.Height + 3);
                //    keepIdx = -Constants.Draw3DYTickNumber;
                //}
            }
            //Add y axis label
            labelPt = new Point3(pts[1].X- tickNumberOffset.Width, (cs.YMax+cs.YMin)/2, pts[1].Z, pts[1].W);
            labelPt.Transform(transMatrix, panel.Size, cs);

            g.DrawString(cs.YLabel, cs.LabelFont, abrush
                        , new PointF(labelPt.X - 3, labelPt.Y + 12));

            //Add z ticks
            SizeF tickNumbeSize = g.MeasureString(cs.ZMax.ToString(".0"), cs.TickFont);
            //nameMappingPos = Constants.Draw3DZTickNumber / 2;
            //keepIdx = 1;
            for (float z = cs.ZMin + cs.ZTick; z < cs.ZMax; z += cs.ZTick)
            {
                //labelPt = new Point3(pts[1].X - tickNumbeSize.Width, pts[2].Y - tickNumbeSize.Width, z, pts[1].W);
                labelPt = new Point3(pts[1].X
                    , pts[2].Y
                    , z, pts[1].W);
                labelPt.Transform(transMatrix, panel.Size, cs);
                PointF pt = new PointF(labelPt.X - tickNumbeSize.Width + 6
                                    , labelPt.Y - tickNumbeSize.Height / 2);
                g.DrawString(z.ToString(".0"), cs.TickFont, tbrush
                    , pt, sf);
                //if (keepIdx < nameMappingPos)
                //{
                //    keepIdx++;
                //}
                //else
                //{
                //    SizeF s = g.MeasureString(z.ToString(".0"), cs.TickFont);
                //    namePt = new PointF(pt.X - s.Width - 12, pt.Y);
                //    keepIdx = -Constants.Draw3DZTickNumber;
                //}
            }
            //Add z axis label
            //gs = g.Save();
            //g.TranslateTransform(namePt.X, namePt.Y);
            //g.RotateTransform(270);
            labelPt = new Point3(pts[1].X, pts[2].Y, (cs.ZMax+cs.ZMin)/2, pts[1].W);
            labelPt.Transform(transMatrix, panel.Size, cs);
            SizeF sZlabel = g.MeasureString(cs.ZLabel, cs.LabelFont);
            PointF ptZlabel = new PointF(labelPt.X - tickNumbeSize.Width - sZlabel.Width - 2
                    , labelPt.Y - sZlabel.Height / 2);
            g.DrawString(cs.ZLabel, cs.LabelFont, abrush, ptZlabel, sf);
            //g.Restore(gs);

            abrush = new SolidBrush(cs.TitleColor);
            g.DrawString(cs.Title, cs.TitleFont, abrush
                , new PointF(panel.Size.Width / 2, panel.Size.Height / 30), sf);
            apen.Dispose();
            abrush.Dispose();
            tbrush.Dispose();
        }
        private void AddGrid(Graphics g)
        {
            using (Pen apen = new Pen(cs.GridColor))
            {
                apen.DashStyle = cs.GridStyle;
                Point3[] ptx = new Point3[3];
                Point3[] pty = new Point3[3];
                Point3[] ptz = new Point3[3];
                ptx[0] = new Point3(0, pts[1].Y, pts[1].Z, pts[1].W);
                pty[0] = new Point3(pts[1].X, 0, pts[1].Z, pts[1].W);
                ptz[0] = new Point3(pts[2].X, pts[2].Y, 0, pts[2].W);
                ptx[1] = new Point3(pts[2].X, pts[2].Y, pts[1].Z, pts[1].W);
                ptx[2] = new Point3(pts[2].X, pts[2].Y, pts[3].Z, pts[1].W);
                pty[1] = new Point3(pts[0].X, pts[0].Y, pts[1].Z, pts[1].W);
                pty[2] = new Point3(pts[0].X, pts[0].Y, pts[3].Z, pts[1].W);
                ptz[1] = new Point3(pts[0].X, pts[2].Y, pts[1].Z, pts[1].W);
                ptz[2] = new Point3(pts[0].X, pts[1].Y, pts[1].Z, pts[1].W);

                Point3[] pta = new Point3[3];
                if (cs.IsXGrid)
                {
                    for (float x = cs.XMin; x <= cs.XMax; x += cs.XTick)
                    {
                        for (int i = 0; i < ptx.Length; i++)
                            pta[i] = new Point3(x, ptx[i].Y, ptx[i].Z, ptx[i].W);
                        for (int i = 0; i < pta.Length; i++)
                            pta[i].Transform(transMatrix, panel.Size, cs);
                        g.DrawLine(apen, pta[0].X, pta[0].Y, pta[1].X, pta[1].Y);
                        g.DrawLine(apen, pta[1].X, pta[1].Y, pta[2].X, pta[2].Y);
                    }
                }
                if (cs.IsYGrid)
                {
                    for (float y = cs.YMin; y <= cs.YMax; y += cs.YTick)
                    {
                        for (int i = 0; i < pty.Length; i++)
                            pta[i] = new Point3(pty[i].X, y, pty[i].Z, pty[i].W);
                        for (int i = 0; i < pta.Length; i++)
                            pta[i].Transform(transMatrix, panel.Size, cs);
                        g.DrawLine(apen, pta[0].X, pta[0].Y, pta[1].X, pta[1].Y);
                        g.DrawLine(apen, pta[1].X, pta[1].Y, pta[2].X, pta[2].Y);
                    }
                }
                if (cs.IsZGrid)
                {
                    for (float z = cs.ZMin; z <= cs.ZMax; z += cs.ZTick)
                    {
                        for (int i = 0; i < ptz.Length; i++)
                            pta[i] = new Point3(ptz[i].X, ptz[i].Y, z, ptz[i].W);
                        for (int i = 0; i < pta.Length; i++)
                            pta[i].Transform(transMatrix, panel.Size, cs);
                        g.DrawLine(apen, pta[0].X, pta[0].Y, pta[1].X, pta[1].Y);
                        g.DrawLine(apen, pta[1].X, pta[1].Y, pta[2].X, pta[2].Y);
                    }
                }
            }
        }

        public void CreateBase(Graphics g)
        {
            transMatrix = Matrix3.AzimuthElevation(cs.Elevation, cs.Azimuth);
            pts = CoordinatesOfChartBox();

            AddGrid(g);
            AddTicks(g);
            AddAxes(g);
        }
        private Point3[] CoordinatesOfChartBox()
        {
            Point3[] pta = new Point3[4];
            //pta[0] = new Point3(cs.XMax, cs.YMin, cs.ZMin, 1);
            pta[0] = new Point3(cs.XMax, cs.YMax, cs.ZMin, 1);
            pta[1] = new Point3(cs.XMin, cs.YMax, cs.ZMin, 1);
            pta[2] = new Point3(cs.XMin, cs.YMin, cs.ZMin, 1);
            //pta[3] = new Point3(cs.XMin, cs.YMax, cs.ZMax, 1);
            pta[3] = new Point3(cs.XMin, cs.YMin, cs.ZMax, 1);
            return pta;
        }
    }
}
