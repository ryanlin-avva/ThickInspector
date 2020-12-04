using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Diagnostics;

namespace SInspector
{
    class Draw3DSkin
    {
        private Panel panel;
        public Color ChartBackColor { get; set; }
        public Color ChartBorderColor { get; set; }
        public Color PlotBackColor { get; set; }
        public Color PlotBorderColor { get; set; }

        public Draw3DSkin(Panel p)
        {
            panel = p;
        }

        public void AddChartStyle2D(Graphics g, ChartStyle cs3d)
        {
            using (Pen apen = new Pen(cs3d.GridColor, 1f))
            {
                apen.DashStyle = cs3d.GridStyle;
                //Create Vertical Grid Lines
                if (cs3d.IsYGrid)
                {
                    for (float x = cs3d.XMin + cs3d.XTick; x < cs3d.XMax; x += cs3d.XTick)
                    {
                        g.DrawLine(apen, PointSkin(new PointF(x, cs3d.YMin), cs3d)
                            , PointSkin(new PointF(x, cs3d.YMax), cs3d));
                    }
                }
                //Create Horizontal Grid Lines
                if (cs3d.IsXGrid)
                {
                    for (float y = cs3d.YMin + cs3d.YTick; y < cs3d.YMax; y += cs3d.YTick)
                    {
                        g.DrawLine(apen, PointSkin(new PointF(cs3d.XMin, y), cs3d)
                            , PointSkin(new PointF(cs3d.XMax, y), cs3d));
                    }
                }
                //Create x-axis tick marks
                for (float x = cs3d.XMin; x <= cs3d.XMax; x += cs3d.XTick)
                {
                    PointF axisPoint = PointSkin(new PointF(x, cs3d.YMin), cs3d);
                    g.DrawLine(apen, axisPoint
                        , new PointF(axisPoint.X, axisPoint.Y - 5f));
                }
                //Create x-axis tick marks
                for (float y = cs3d.YMin; y <= cs3d.YMax; y += cs3d.YTick)
                {
                    PointF axisPoint = PointSkin(new PointF(cs3d.XMin, y), cs3d);
                    g.DrawLine(apen, axisPoint
                        , new PointF(axisPoint.X + 5f, axisPoint.Y));
                }
            }
        }

        //2D point
        private PointF PointSkin(PointF p, ChartStyle cs3d)
        {
            PointF pt = new PointF();
            if (p.X < cs3d.XMin || p.X > cs3d.XMax
                || p.Y < cs3d.YMin || p.Y > cs3d.YMax)
            {
                p.X = Single.NaN;
                p.Y = Single.NaN;
            }
            pt.X = (p.X - cs3d.XMin) * panel.Width / (cs3d.XMax - cs3d.XMin);
            pt.Y = (p.Y - cs3d.YMin) * panel.Height / (cs3d.YMax - cs3d.YMin);
            return pt;
        }
    }
}
