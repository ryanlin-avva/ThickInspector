using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ThickInspector
{
    class DataStyle
    {
        public DashStyle LineStyle { get; set; }
        public Color LineColor { get; set; }
        public float Thickness { get; set; }

        public DataStyle() 
        {
            Thickness = 1;
            LineColor = Color.Black;
            LineStyle = DashStyle.Solid;
        }
    }
}
