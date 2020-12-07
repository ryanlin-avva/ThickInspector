using System;
using System.Drawing;

namespace ThickInspector
{
    class Point3
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float W { get; set; }
        public Point3()
        {
            W = 1;
        }
        public Point3(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public Point3(Point3 p)
        {
            X = p.X;
            Y = p.Y;
            Z = p.Z;
            W = p.W;
        }
        //Apply Transform to a point
        public void Transform(Matrix3 m)
        {
            float[] result = m.vectorMultiply(new float[4] { X, Y, Z, W});
            X = result[0];
            Y = result[1];
            Z = result[2];
            W = result[3];
        }
        public void Transform(Matrix3 m, SizeF panelSize, ChartStyle cs)
        {
            float x1 = (X - cs.XMin) / (cs.XMax - cs.XMin) - 0.5f;
            //float y1 = (Y - cs.YMin) / (cs.YMax - cs.YMin) - 0.5f;
            float y1 = (cs.YMax - Y) / (cs.YMax - cs.YMin) - 0.5f;
            float z1 = (Z - cs.ZMin) / (cs.ZMax - cs.ZMin) - 0.5f;
            float[] result = m.vectorMultiply(new float[4] { x1, y1, z1, W });
            X = result[0];
            Y = result[1];

            float xShift = 1f;
            float xScale = 1f;
            float yShift = 1f;
            float yScale = 1f;

            //float xShift = 0.95f;
            //float xScale = 1f;
            //float yShift = 1.05f;
            //float yScale = 1f;

            X = (xShift + xScale * X) * panelSize.Width / 2;
            Y = (yShift - yScale * Y) * panelSize.Height / 2;
        }
        public override string ToString()
        {
            return X.ToString("f2") + ", " + Y.ToString("f2") + ", " 
                 + Z.ToString("f2") + ", " + W.ToString("f2"); ;
        }
    }
}
