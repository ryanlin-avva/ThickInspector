using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ThickInspector
{
    class ChartStyle
    {
        //Display Range
        public float XMin { get; set; }
        public float XMax { get; set; }
        public float YMin { get; set; }
        public float YMax { get; set; }
        public float ZMin { get; set; }
        public float ZMax { get; set; }

        //Label
        public string XLabel { get; set; }
        public string YLabel { get; set; }
        public string ZLabel { get; set; }
        public Font LabelFont { get; set; }
        public Color LabelColor { get; set; }

        //Title
        public string Title { get; set; }
        public string Title2 { get; set; }
        public Font TitleFont { get; set; }
        public Color TitleColor { get; set; }

        //Ticks
        public float XTick { get; set; }
        public float YTick { get; set; }
        public float ZTick { get; set; }
        public Font TickFont { get; set; }
        public Color TickColor { get; set; }

        //LineStyle
        public DashStyle GridStyle { get; set; }
        public Color GridColor { get; set; }
        public float GridThickness { get; set; }
        public DashStyle AxisStyle { get; set; }
        public Color AxisColor { get; set; }
        public float AxisThickness { get; set; }

        //Chart Style Selector
        public bool IsXGrid { get; set; }
        public bool IsYGrid { get; set; }
        public bool IsZGrid { get; set; }
        public bool IsColorBar { get; set; }
        public float Elevation { get; set; }
        public float Azimuth { get; set; }
        public bool FullScale { get; set; }

        public ChartStyle()
        {
            IsXGrid = true;
            IsYGrid = true;
            IsZGrid = true;
            IsColorBar = true;
            XMin = 0;
            XMax = 0;
            YMin = 0;
            YMax = 0;
            ZMin = 0;
            ZMax = 0;
            Title = "My Form";
            XLabel = "X";
            YLabel = "Y";
            ZLabel = "Z";
            FullScale = false;
        }

        public ChartStyle ShallowCopy()
        {
            return MemberwiseClone() as ChartStyle;
        } 
        //public void SetParas(DataSeries ds)
        //{
        //    XMin = ds.XArray[0];
        //    XMax = ds.XArray[ds.XArray.Length - 1];
        //    YMin = 0;
        //    YMax = (ds.YArray[ds.YArray.Length - 1] - ds.YArray[0]) * 1.1f;
        //    XTick = XMax / Constants.Draw3DXTickNumber;
        //    YTick = YMax / Constants.Draw3DYTickNumber;
        //    ZMin = ds.Zmin * 0.9f;
        //    ZMax = ds.Zmax * 1.1f;
        //    ZTick = (ZMax - ZMin) / Constants.Draw3DZTickNumber;
        //    XMax += XTick / 2;
        //    XMin -= XTick / 2;
        //}
    }
}
