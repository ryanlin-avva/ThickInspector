using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Diagnostics;

namespace ThickInspector
{
    //因為是Z軸定點的橫剖面
    //所以Z軸使用的是Z座標
    class DrawSection
    {
        private Panel panel;
        private ChartStyle cs;
        public Rectangle PlotArea { get; set; }
        public float XOffset { get; set; }
        public float YOffset { get; set; }
        public bool RawDisplay { get; set; }
        public bool NoZeroDisplay { get; set; }
        public bool FilteredDisplay { get; set; }
        public DrawSection(Panel p, ChartStyle cs3d) 
        {
            panel = p;
            cs = cs3d.ShallowCopy();
            cs.XTick = 20;
            float scale = 28.0f;
            XOffset = panel.Width / scale;
            YOffset = panel.Height / scale;
        }
        public ChartStyle GetStyle()
        {
            return cs;
        }
        public void UpdateChartStyle(ChartStyle cs3d)
        {
            //cs = cs3d.ShallowCopy();
            cs.XMax = cs3d.XMax;
            cs.XMin = cs3d.XMin;
            cs.XTick = (cs.XMax - cs.XMin) / Constants.Draw2DXTickNumber;
        }
        public void CreateBase(Graphics g)
        {
            AddGrid(g);
            AddLabel(g);
        }
        private void PrintLinePoint(PointF a, PointF b, PointF c, PointF d)
        {
            Debug.WriteLine("[PrintLinePoints] ({0},{1}) ({2},{3})  ---  ({4},{5}) ({6},{7})"
                , a.X, a.Y, b.X, b.Y, c.X, c.Y, d.X, d.Y);
        }

        public void AddChart(Graphics g, DataSeries ds, int pos)
        {
            if (ds.XArray == null) return;
            using (Pen rpen = new Pen(Color.Red, ds.DataLine.Thickness))
            using (Pen bpen = new Pen(Color.Blue, ds.DataLine.Thickness))
            using (Pen gpen = new Pen(Color.Green, ds.DataLine.Thickness))
            {
                rpen.DashStyle = ds.DataLine.LineStyle;
                gpen.DashStyle = ds.DataLine.LineStyle;
                bpen.DashStyle = ds.DataLine.LineStyle;
                PointF[] pts = ds.GetNZeroDataSet(pos);
                PointF[] pts_raw = null;
                PointF[] pts_filtered = null;
                //Find min, max 
                //Remove zero and small intensity dots
                float temp_min = pts[0].Y;
                float temp_max = pts[0].Y;
                for (int i = 1; i < pts.Length; i++)
                {
                    if (pts[i].Y > 0 && pts[i].Y < temp_min)
                        temp_min = pts[i].Y;
                    if (pts[i].Y > temp_max)
                        temp_max = pts[i].Y;
                }
                cs.ZMin = (float)((int)(temp_min - Constants.Draw2DZAxisPadding));
                if (cs.ZMin < 0) cs.ZMin = 0;
                cs.ZMax = temp_max + Constants.Draw2DZAxisPadding;
                cs.ZTick = (cs.ZMax- cs.ZMin)/Constants.Draw2DZTickNumber;

                CreateBase(g);
                if (RawDisplay)
                    pts_raw = ds.GetOriDataSet(pos);
                if (FilteredDisplay)
                    pts_filtered = ds.GetFilteredDataSet(pos);
                for (int i = 1; i < pts.Length; i++)
                {
                    if (RawDisplay)
                    {
                        if (pts_raw[i - 1].Y != 0 && pts_raw[i].Y != 0)
                            g.DrawLine(rpen, Point2D(pts_raw[i - 1].X, pts_raw[i - 1].Y)
                                , Point2D(pts_raw[i].X, pts_raw[i].Y));
                    }
                    if (NoZeroDisplay)
                        g.DrawLine(bpen, Point2D(pts[i - 1].X, pts[i - 1].Y)
                            , Point2D(pts[i].X, pts[i].Y));
                    if (FilteredDisplay)
                    {
                        if (i >= 10 && i < pts.Length - 10) 
                        {
                            PointF p1 = Point2D(pts_filtered[i - 1].X, pts_filtered[i - 1].Y);
                            PointF p2 = Point2D(pts_filtered[i].X, pts_filtered[i].Y);
                            g.DrawLine(gpen, p1, p2);
                        }
                    }
                }
            }
        }
        private void AddGrid(Graphics g)
        {
            g.DrawRectangle(new Pen(Color.DarkSlateGray, 2), PlotArea);
            Pen apen = new Pen(cs.GridColor, cs.GridThickness);
            apen.DashStyle = cs.GridStyle;
            //畫縱格線
            if (cs.IsZGrid)
            {
                
                for (float fX = cs.XMin + cs.XTick; fX < cs.XMax; fX += cs.XTick)
                    g.DrawLine(apen, Point2D(fX, cs.ZMin), Point2D(fX, cs.ZMax));
            }
            //畫橫格線
            if (cs.IsXGrid)
            {
                for (float fZ = cs.ZMin + cs.ZTick; fZ < cs.ZMax; fZ += cs.ZTick)
                    g.DrawLine(apen, Point2D(cs.XMin, fZ), Point2D(cs.XMax, fZ));
            }
            //Draw Ticks
            apen = new Pen(cs.AxisColor, cs.AxisThickness);
            SolidBrush abrush = new SolidBrush(cs.TickColor);
            for (float fX = cs.XMin; fX <= cs.XMax; fX += cs.XTick)
            {
                PointF yAxisPoint = Point2D(fX, cs.ZMin);
                g.DrawLine(Pens.Black, yAxisPoint, new PointF(yAxisPoint.X, yAxisPoint.Y - 5f));
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Far;
                SizeF sizeXTick = g.MeasureString(fX.ToString(), cs.TickFont);
                g.DrawString(fX.ToString("#.#"), cs.TickFont, abrush
                    , new PointF(yAxisPoint.X + sizeXTick.Width / 2, yAxisPoint.Y + 4f)
                    , sf);
            }
            for (float fZ = cs.ZMin; fZ <= cs.ZMax; fZ += cs.ZTick)
            {
                PointF xAxisPoint = Point2D(cs.XMin, fZ);
                g.DrawLine(Pens.Black, xAxisPoint, new PointF(xAxisPoint.X + 5f, xAxisPoint.Y));
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Far;
                SizeF sizeZTick = g.MeasureString(fZ.ToString(), cs.TickFont);
                g.DrawString(fZ.ToString("#.#"), cs.TickFont, abrush
                    , new PointF(xAxisPoint.X - 3, xAxisPoint.Y - sizeZTick.Height / 2)
                    , sf);
            }
            apen.Dispose();
            abrush.Dispose();
        }
        private void AddLabel(Graphics g)
        {
            SizeF titleSize = g.MeasureString(cs.Title2, cs.TitleFont);

            // Add horizontal axis label:
            SolidBrush abrush = new SolidBrush(cs.LabelColor);
            SizeF labelSize = g.MeasureString(cs.XLabel, cs.LabelFont);
            g.DrawString(cs.XLabel, cs.LabelFont, abrush
                , new Point(PlotArea.Left + (int)((PlotArea.Width - labelSize.Width) / 2)
                    , PlotArea.Bottom + (int)(YOffset+labelSize.Height/2)));

            // Shift and Add y label:
            //StringFormat sf = new StringFormat();
            //sf.Alignment = StringAlignment.Center;
            //// Save the state of the current Graphics object--put on stack
            //GraphicsState gState = g.Save();
            //g.TranslateTransform(XOffset, YOffset + titleSize.Height + YOffset / 3 + PlotArea.Height / 2);
            //g.RotateTransform(-90);
            g.DrawString(cs.ZLabel, cs.LabelFont, abrush
                , new Point((int)(PlotArea.Left - labelSize.Width * 3-5)
                    , (PlotArea.Bottom + PlotArea.Top) / 2));
            //g.Restore(gState);

            // Add title:
            abrush = new SolidBrush(cs.TitleColor);
            g.DrawString(cs.Title2, cs.TitleFont, abrush
                , new Point(PlotArea.Left + (int)((PlotArea.Width - titleSize.Width) / 2)
                        , PlotArea.Top - (int)(YOffset+ titleSize.Height)));
            abrush.Dispose();
        }
        public bool SetPlotArea(Graphics g)
        {
            SizeF labelSize = g.MeasureString("A", cs.LabelFont);
            SizeF titleSize = g.MeasureString("A", cs.TitleFont);
            SizeF tickSize = g.MeasureString("A", cs.TickFont);
            SizeF yTickSize = g.MeasureString(cs.ZMax.ToString(), cs.TickFont);

            float xSpacing = XOffset / 3.0f;
            float ySpacing = YOffset / 3.0f;
            float tickSpacing = 2.0f;

            //找出Z軸刻度的最長數字寬度，以確認plot的左邊界
            //X軸刻度的高度固定，不必找出最長數字寬度
            //for (float yTick = cs.ZMin; yTick <= cs.ZMax; yTick += cs.ZTick)
            //{
            //    SizeF temp = g.MeasureString(yTick.ToString(), cs.TickFont);
            //    if (yTickSize.Width < temp.Width)
            //    {
            //        yTickSize = temp;
            //    }
            //}
            float leftMargin = XOffset + labelSize.Height + xSpacing + yTickSize.Width + tickSpacing;
            float rightMargin = XOffset * 2;
            float topMargin = YOffset + titleSize.Height + ySpacing;
            float bottomMargin = YOffset + ySpacing + labelSize.Height + tickSpacing + tickSize.Height;

            //int plotX = panel.Left + (int)leftMargin;
            //int plotZ = panel.Top + (int)topMargin;
            int plotX = (int)leftMargin;
            int plotZ = (int)topMargin;
            int plotWidth = panel.Width - (int)leftMargin - (int)rightMargin;
            int plotHeight = panel.Height - (int)topMargin - (int)bottomMargin;
            Rectangle r = new Rectangle(plotX, plotZ, plotWidth, plotHeight);
            if (PlotArea == r) //No need to re-calculate
                return false;
            //PlotArea = new Rectangle(plotX, plotZ, plotWidth, plotHeight);
            PlotArea = r;
            return true;
        }
        public float GetRealDistance(float d1, float d2, bool isH)
        {
            if (isH)
            {
                return (cs.XMax - cs.XMin) * (d2 - d1) / PlotArea.Width;
            }
            else
            {
                return (cs.ZMax - cs.ZMin) * (d2 - d1) / PlotArea.Height;
            }
            
        }
        public PointF Point2D(float x, float y)
        {
            float xDiff;
            float yDiff;
            xDiff = cs.XMax - cs.XMin;
            yDiff = cs.ZMax - cs.ZMin;
            PointF pt = new PointF();
            if (x < cs.XMin) x = cs.XMin;
            if (x > cs.XMax) x = cs.XMax;
            if (y < cs.ZMin) y = cs.ZMin;
            if (y > cs.ZMax) y = cs.ZMax;
            if (x < cs.XMin || x > cs.XMax || y < cs.ZMin || y > cs.ZMax)
            {
                Debug.WriteLine("Point2D ({0},{1}) out of range: x({2}..{3}) y({4}..{5})"
                           , x, y, cs.XMax, cs.XMin, cs.ZMax, cs.ZMin);
            }
            pt.X = PlotArea.Left + PlotArea.Width * (x - cs.XMin) / xDiff;
            pt.Y = PlotArea.Bottom - PlotArea.Height * (y - cs.ZMin) / yDiff;
            return pt;
        }
    }
}
