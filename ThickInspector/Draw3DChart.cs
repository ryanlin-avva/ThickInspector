using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Diagnostics;

namespace ThickInspector
{
    class Draw3DChart
    {
        private Panel panel;
        private ChartStyle cs;

        public int NumberInterp { get; set; }
        public int[,] CMap { get; set; }

        public Draw3DChart(Panel p, ChartStyle cs3d)
        {
            panel = p;
            Debug.WriteLine("3D Panel Size = " + panel.Size.Width.ToString()
                                + " X " + panel.Size.Height.ToString());
            cs = cs3d;
            NumberInterp = 2;
        }
        public void AddChart(Graphics g, DataSeries ds,  Draw3DSkin skin3d)
        {
            //Debug.WriteLine("Entering AddChart panel=" + panel.Width.ToString()
            //+ "," + panel.Height.ToString());

            AddSurface(g, ds, skin3d);
            //AddMesh(g, ds, cs);
            if (ds.XArray != null) AddColorBar(g, ds, skin3d);
           // Debug.WriteLine("Exit AddChart panel=" + panel.Width.ToString()
           //+ "," + panel.Height.ToString());
        }

        public void AddPartialChart(Graphics g, DataSeries ds, Draw3DSkin skin3d, int pos1, int pos2)
        {
            //Debug.WriteLine("Entering AddChart panel=" + panel.Width.ToString()
            //+ "," + panel.Height.ToString());

            if (ds.XArray != null)
            {
                AddPartialSurface(g, ds, skin3d, pos1, pos2);
                //AddMesh(g, ds, cs);
                AddColorBar(g, ds, skin3d);
            }
            Debug.WriteLine("Exit AddChart panel=" + panel.Width.ToString()
           + "," + panel.Height.ToString());
        }

        private void AddColorBar(Graphics g, DataSeries ds, Draw3DSkin skin3d)
        {
            SolidBrush abrush = new SolidBrush(cs.TickColor);

            using (Pen apen = new Pen(Color.Black, 1))
            {
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Near;
                SizeF size = g.MeasureString("A", cs.TickFont);

                int x, y, w, h;
                Point3[] pts = new Point3[64];
                PointF[] pta = new PointF[4];

                float dz = ds.Zdistance / 63;
                x = 5 * panel.Width / 6 + 25;
                y = panel.Height / 10;
                w = panel.Width / 40;
                h = 3 * panel.Height / 5;

                //Add Color Bar
                for (int i = 0; i < 64; i++)
                {
                    pts[i] = new Point3(x, y, ds.Zmin + i * dz, 1);
                }
                for (int i = 0; i < 63; i++)
                {
                    Color color = AddColor(pts[i], ds.Zmin, ds.Zmax);
                    abrush = new SolidBrush(color);
                    float y1 = y + h - h * (pts[i].Z - ds.Zmin) / ds.Zdistance;
                    float y2 = y + h - h * (pts[i + 1].Z - ds.Zmin) / ds.Zdistance;
                    pta[0] = new PointF(x, y2);
                    pta[1] = new PointF(x + w, y2);
                    pta[2] = new PointF(x + w, y1);
                    pta[3] = new PointF(x, y1);
                    g.FillPolygon(abrush, pta);
                }

                g.DrawRectangle(apen, x, y, w, h);

                //Add ticks and label to color bar
                float tickLength = 0.1f * w;
                for (float z = ds.Zmin; z <= ds.Zmax; z += (ds.Zmax - ds.Zmin) / 6)
                {
                    float yy = y + h - h * (z - ds.Zmin) / ds.Zdistance;
                    g.DrawLine(apen, x, yy, x + tickLength, yy);
                    g.DrawLine(apen, x + w, yy, x + w - tickLength, yy);
                    g.DrawString(Math.Round(z, 2).ToString(), cs.TickFont
                        , abrush, new PointF(x + w + 5, yy - size.Height / 2), sf);
                }
            }
            abrush.Dispose();
        }

        private Color AddColor(Point3 p, float zmin, float zmax)
        {
            int colorLength = CMap.GetLength(0);
            int cindex = (int)Math.Round((colorLength * (p.Z - zmin) + (zmax - p.Z))
                                            / (zmax - zmin));
            if (cindex < 1) cindex = 1;
            if (cindex > colorLength) cindex = colorLength;
            Color color = Color.FromArgb(CMap[cindex - 1, 0], CMap[cindex - 1, 1]
                                        , CMap[cindex - 1, 2], CMap[cindex - 1, 3]);
            return color;
        }

        private void AddSurface(Graphics g, DataSeries ds, Draw3DSkin skin3d)
        {
            SolidBrush abrush = new SolidBrush(Color.AliceBlue);
            Pen apen = new Pen(ds.DataLine.LineColor, ds.DataLine.Thickness);
            apen.DashStyle = ds.DataLine.LineStyle;

            Matrix3 m = Matrix3.AzimuthElevation(cs.Elevation, cs.Azimuth);
            Point3[,] pts = ds.CloneDataSet();
            int len0 = pts.GetLength(0);
            int len1 = pts.GetLength(1);
            Point3[,] pts1 = new Point3[len0, len1];
            PointF[] pta = new PointF[4];

            for (int i = 0; i < len0; i++)
            {
                for (int j = 0; j < len1; j++)
                {
                    if (pts[i, j].Z > 80 && pts[i,j].X==42)
                        Debug.WriteLine("hello");
                    pts1[i, j] = new Point3(pts[i, j].X, pts[i, j].Y, pts[i, j].Z, 1);
                    pts[i, j].Transform(m, panel.Size, cs);
                }
            }

            //Draw Surface
            for (int i = 0; i < len0 - 1; i++)
            {
                for (int j = 0; j < len1 - 1; j++)
                {
                    int ii = i;
                    if (cs.Azimuth >= -180 && cs.Azimuth < 0)
                    {
                        ii = len0 - 2 - i;
                    }
                    Point3[] p3 = new Point3[4];
                    p3[0] = pts1[ii, j];
                    p3[1] = pts1[ii, j + 1];
                    p3[2] = pts1[ii + 1, j + 1];
                    p3[3] = pts1[ii + 1, j];
                    Interp(g, skin3d, m, p3, ds.Zmin, ds.Zmax, 1);

                    pta[0] = new PointF(pts[ii, j].X, pts[ii, j].Y);
                    pta[1] = new PointF(pts[ii, j + 1].X, pts[ii, j + 1].Y);
                    pta[2] = new PointF(pts[ii + 1, j + 1].X, pts[ii + 1, j + 1].Y);
                    pta[3] = new PointF(pts[ii + 1, j].X, pts[ii + 1, j].Y);
                    //g.DrawPolygon(apen, pta);
                }
            }

            apen.Dispose();
            abrush.Dispose();
        }

        private void AddPartialSurface(Graphics g, DataSeries ds, Draw3DSkin skin3d
            , int pos1, int pos2)
        {
            SolidBrush abrush = new SolidBrush(Color.AliceBlue);
            Pen apen = new Pen(ds.DataLine.LineColor, ds.DataLine.Thickness);
            apen.DashStyle = ds.DataLine.LineStyle;

            Matrix3 m = Matrix3.AzimuthElevation(cs.Elevation, cs.Azimuth);
            Point3[,] pts = ds.CloneDataSet();
            int len0 = pts.GetLength(0);
            int len1 = pts.GetLength(1);
            Point3[,] pts1 = new Point3[len0, pos2-pos1];
            PointF[] pta = new PointF[4];

            for (int i = 0; i < len0; i++)
            {
                for (int j = pos1; j < pos2; j++)
                {
                    pts1[i, j-pos1] = new Point3(pts[i, j].X, pts[i, j].Y, pts[i, j].Z, 1);
                    pts[i, j-pos1].Transform(m, panel.Size, cs);
                }
            }

            //Draw Surface
            for (int i = 0; i < len0 - 1; i++)
            {
                for (int j = 0; j < pos2 - pos1 - 1; j++)
                {
                    int ii = i;
                    if (cs.Azimuth >= -180 && cs.Azimuth < 0)
                    {
                        ii = len0 - 2 - i;
                    }
                    Point3[] p3 = new Point3[4];
                    p3[0] = pts1[ii, j];
                    p3[1] = pts1[ii, j + 1];
                    p3[2] = pts1[ii + 1, j + 1];
                    p3[3] = pts1[ii + 1, j];
                    Interp(g, skin3d, m, p3, ds.Zmin, ds.Zmax, 1);

                    pta[0] = new PointF(pts[ii, j].X, pts[ii, j].Y);
                    pta[1] = new PointF(pts[ii, j + 1].X, pts[ii, j + 1].Y);
                    pta[2] = new PointF(pts[ii + 1, j + 1].X, pts[ii + 1, j + 1].Y);
                    pta[3] = new PointF(pts[ii + 1, j].X, pts[ii + 1, j].Y);
                    //g.DrawPolygon(apen, pta);
                }
            }

            apen.Dispose();
            abrush.Dispose();
        }

        private void Interp(Graphics g, Draw3DSkin skin3d, Matrix3 m
                            , Point3[] pta, float zmin, float zmax, int flag)
        {
            SolidBrush abrush = new SolidBrush(Color.Black);
            PointF[] pf = new PointF[4];
            int nPoint = NumberInterp;
            Point3[,] pts = new Point3[nPoint + 1, nPoint + 1];
            Point3[,] pts1 = new Point3[nPoint + 1, nPoint + 1];
            float x0 = pta[0].X;
            float y0 = pta[0].Y;
            float x1 = pta[2].X;
            float y1 = pta[2].Y;
            float dx = (x1 - x0) / nPoint;
            float dy = (y1 - y0) / nPoint;
            float C00 = pta[0].Z;
            float C01 = pta[1].Z;
            float C11 = pta[2].Z;
            float C10 = pta[3].Z;
            float x, y, C;
            Color color;

            if (flag == 1) //Surface chart
            {
                for (int i = 0; i <= nPoint; i++)
                {
                    x = x0 + dx * i;
                    for (int j = 0; j <= nPoint; j++)
                    {
                        y = y0 + dy * j;
                        C = ((y1 - y) * ((x1 - x) * C00 + (x - x0) * C10)
                            + (y - y0) * ((x1 - x) * C01 + (x - x0) * C11))
                            / (x1 - x0) / (y1 - y0);
                        pts[i, j] = new Point3(x, y, C, 1);
                        pts[i, j].Transform(m, panel.Size, cs);
                    }
                }
                for (int i = 0; i < nPoint; i++)
                {
                    for (int j = 0; j < nPoint; j++)
                    {
                        color = AddColor(pts[i, j], zmin, zmax);
                        abrush = new SolidBrush(color);
                        pf[0] = new PointF(pts[i, j].X, pts[i, j].Y);
                        pf[1] = new PointF(pts[i, j + 1].X, pts[i, j + 1].Y);
                        pf[2] = new PointF(pts[i + 1, j + 1].X, pts[i + 1, j + 1].Y);
                        pf[3] = new PointF(pts[i + 1, j].X, pts[i + 1, j].Y);
                        g.FillPolygon(abrush, pf);
                    }
                }
            }
            abrush.Dispose();
        }

        private void AddMesh(Graphics g, DataSeries ds, ChartStyle cs)
        {
            Debug.WriteLine("Entering AddMesh panel=" + panel.Width.ToString()
                + "," + panel.Height.ToString());

            Pen apen = new Pen(ds.DataLine.LineColor, ds.DataLine.Thickness);
            using (SolidBrush abrush = new SolidBrush(Color.Wheat))
            {
                Point3[,] pts = ds.CloneDataSet();
                PointF[] pta = new PointF[4];
                Matrix3 m = Matrix3.AzimuthElevation(cs.Elevation, cs.Azimuth);

                //Points transform
                for (int i = 0; i < pts.GetLength(0); i++)
                {
                    for (int j = 0; j < pts.GetLength(1); j++)
                    {
                        pts[i, j].Transform(m, panel.Size, cs);

                    }
                }

                //Draw Mesh
                for (int i = 0; i < pts.GetLength(0) - 1; i++)
                {
                    for (int j = 0; j < pts.GetLength(1) - 1; j++)
                    {
                        int ii = i;
                        if (cs.Azimuth >= -180 && cs.Azimuth < 0)
                        {
                            ii = pts.GetLength(0) - 2 - i;
                        }
                        pta[0] = new PointF(pts[ii, j].X, pts[ii, j].Y);
                        pta[1] = new PointF(pts[ii, j + 1].X, pts[ii, j + 1].Y);
                        pta[2] = new PointF(pts[ii + 1, j + 1].X, pts[ii + 1, j + 1].Y);
                        pta[3] = new PointF(pts[ii + 1, j].X, pts[ii + 1, j].Y);
                        //g.FillPolygon(abrush, pta);
                        g.DrawPolygon(apen, pta);
                    }
                }
            }
            apen.Dispose();

            Debug.WriteLine("Exit AddMesh panel=" + panel.Width.ToString()
              + "," + panel.Height.ToString());

        }
        public void DrawPosPointer(Graphics g, int vertex, float z)
        {
            Point3[] pnt = new Point3[3];
            pnt[0] = new Point3(cs.XMin, vertex, z, 1);
            pnt[1] = new Point3(cs.XMin - 100, vertex, z, 1);
            pnt[2] = new Point3(cs.XMin - 100, vertex+60, z, 1);
            Point3 linePnt = new Point3(cs.XMin - 180, vertex+40, z, 1);

            Matrix3 m = Matrix3.AzimuthElevation(cs.Elevation, cs.Azimuth);
            PointF[] pts = new PointF[3];
            pnt[0].Transform(m, panel.Size, cs);
            pts[0] = new PointF(pnt[0].X, pnt[0].Y);
            pnt[1].Transform(m, panel.Size, cs);
            pts[1] = new PointF(pnt[1].X, pnt[1].Y);
            pnt[2].Transform(m, panel.Size, cs);
            pts[2] = new PointF(pnt[2].X, pnt[2].Y);
            linePnt.Transform(m, panel.Size, cs);
            PointF linePts = new PointF(linePnt.X, linePnt.Y);

            Debug.WriteLine("Triangle point:{" + pnt[0] + "} {" + pnt[1] + "} {"
                                + pnt[2] + "} {" + "\n  Transformed:{"
                                + pts[0].ToString() + "} {" + pts[1].ToString() + "} {"
                                + pts[2].ToString() + "}");

            using (SolidBrush abrush = new SolidBrush(Color.Brown))
            {
                g.FillPolygon(abrush, pts);
            }
            using (Pen apen = new Pen(Color.Brown, 5f))
            {
                g.DrawLine(apen, pts[0], linePts);
            }

        }
        public void AddPosIndicator(Graphics g, int vertex, float z)
        {
            //An arrowhead line as indicator
            Point3[] pta = new Point3[2];
            pta[0] = new Point3(cs.XMin, vertex, z, 1);
            pta[1] = new Point3(cs.XMax, vertex, z, 1);
            //pta[0] = new Point3(cs.XMin-50, vertex, z, 1);
            //pta[1] = new Point3(cs.XMin, vertex, z, 1);

            Matrix3 m = Matrix3.AzimuthElevation(cs.Elevation, cs.Azimuth);
            PointF[] pts = new PointF[2];
            pta[0].Transform(m, panel.Size, cs);
            pts[0] = new PointF(pta[0].X, pta[0].Y);
            pta[1].Transform(m, panel.Size, cs);
            pts[1] = new PointF(pta[1].X, pta[1].Y);

            //using (Pen apen = new Pen(Color.Brown, 5f))
            using (Pen apen = new Pen(Color.Brown, 3f))
            {
                apen.StartCap = LineCap.RoundAnchor;
                apen.EndCap = LineCap.RoundAnchor;
                //apen.StartCap = LineCap.Flat;
                //apen.EndCap = LineCap.ArrowAnchor;
                g.DrawLine(apen, pts[0], pts[1]);
            }

            //A plane as indicator
            //Point3[] pta = new Point3[4];
            //pta[0] = new Point3(cs.XMin, vertex, cs.ZMin, 1);
            //pta[1] = new Point3(cs.XMin, vertex, cs.ZMax, 1);
            //pta[2] = new Point3(cs.XMax, vertex, cs.ZMax, 1);
            //pta[3] = new Point3(cs.XMax, vertex, cs.ZMin, 1);
            ////pta[1] = new Point3(cs.XMax, vertex, cs.ZMin, 1);

            //Matrix3 m = Matrix3.AzimuthElevation(cs.Elevation, cs.Azimuth);
            //PointF[] pts = new PointF[4];
            //for (int i = 0; i < 4; i++)
            //{
            //    pta[i].Transform(m, panel.Size, cs);
            //    pts[i] = new PointF(pta[i].X, pta[i].Y);
            //}

            //Color c = Color.FromArgb(128, Color.DarkGray);

            //using (SolidBrush apen = new SolidBrush(c))
            //{
            //    g.FillPolygon(apen, pts);
            //}

        }
    }
}
