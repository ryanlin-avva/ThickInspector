using System;
using System.Drawing;
using System.Diagnostics;

namespace SInspector
{
    class DraggableLine
    {
        public Pen MyPen { get; set; }
        public bool Visible { get; set; }
        public bool IsDragging = false;
        public string LenStr { get; set; }

        private int CurPointFIdx { get; set; }
        private float dragBuffer { get; set; }
        private bool isHorizontal;
        private int xMin;
        private int xMax;
        private int yMin;
        private int yMax;
        private Point preMousePos;
        private Point curMousePos;
        private ChartStyle cs;
        private int line_offset;
        private Point[] pts;
        public DraggableLine(Pen p, int offset, bool isHor, float buffer=5)
        {
            MyPen = p;
            isHorizontal = isHor;
            dragBuffer = buffer;
            line_offset = offset;
            pts = new Point[2];
            curMousePos = new Point(0, 0); //for 1st assignment in setMousePos
        }
        private float GetRealDistance()
        {
            if (isHorizontal)
            {
                return (cs.XMax - cs.XMin) * (pts[1].X-pts[0].X) / (xMax - xMin);
            }
            else
            {
                return (cs.ZMax - cs.ZMin) * (pts[1].Y - pts[0].Y) / (yMax - yMin);
            }

        }
        public void SetStartingPos()
        {
            int w = (xMax - xMin) / 4;
            int h = (yMax - yMin) / 3;
            if (isHorizontal)
            {
                pts[0] = new Point(xMin + line_offset + w, yMin + line_offset + h);
                pts[1] = new Point(xMin + line_offset + 2 * w, yMin + line_offset + h);
            }
            else
            {
                pts[0] = new Point(xMin + line_offset + w, yMin + line_offset + h + 10);
                pts[1] = new Point(xMin + line_offset + w, yMin + line_offset + 2 * h);
            }
        }
        public void SetBoundary(int xmin, int xmax, int ymin, int ymax, ChartStyle s)
        {
            xMin = xmin;
            xMax = xmax;
            yMin = ymin;
            yMax = ymax;
            cs = s;
            SetStartingPos();
        }

        public void SetMousePos(Point p)
        {
            preMousePos = curMousePos;
            curMousePos = new Point(p.X, p.Y);
            //Debug.WriteLine("[SetMousePos] :(" + p.X.ToString() + "," + p.Y.ToString()
            //    + ") (" + preMousePos.X.ToString() + ", " + preMousePos.Y.ToString() + ")");
        }

        public void Draw(Graphics g)
        {
            float len = GetRealDistance();
            DrawRuler(g);
            Point p;
            LenStr = len.ToString("F2");
            SizeF s = g.MeasureString(LenStr, cs.TickFont);
            if (isHorizontal)
            {
                int h = pts[0].Y - (int)s.Height;
                if (h <= yMin) h = pts[0].Y + (int)s.Height - 2;
                int w = (pts[1].X - pts[0].X - (int)s.Width) / 2;
                p = new Point(pts[0].X + w, h);
            }
            else
            {
                int w = pts[0].X + 2;
                if (w > xMax) w = pts[0].X - 2;
                int h = (pts[1].Y - pts[0].Y - (int)s.Height) / 2;
                p = new Point(w, pts[0].Y + h);
            }
            g.DrawString(LenStr, cs.TickFont, new SolidBrush(Color.Brown), p);
        }
        public void Move()
        {
            /*
            Debug.WriteLine("Entering move");
            Debug.WriteLine("[Move1] CurPointFIdx:" + CurPointFIdx
                + " pts(" + pts[0].X.ToString()
                + "," + pts[0].Y.ToString()
                + ") (" + pts[1].X.ToString()
                + ", " + pts[1].Y.ToString()
                + ") mouse pos (" + curMousePos.X.ToString()
                + "," + curMousePos.Y.ToString()
                + ") (" + preMousePos.X.ToString()
                + ", " + preMousePos.Y.ToString()
                + ")");
            */
            if (curMousePos.Y > yMax) curMousePos.Y = yMax;
            else if (curMousePos.Y < yMin) curMousePos.Y = yMin;
            if (curMousePos.X > xMax) curMousePos.X = xMax;
            else if (curMousePos.X < xMin) curMousePos.X = xMin;

            if (CurPointFIdx == 2)
            {
                int x = curMousePos.X - preMousePos.X;
                int y = curMousePos.Y - preMousePos.Y;
                //pts[0] = new Point(pts[0].X + x, pts[0].Y + y);
                //pts[1] = new Point(pts[1].X + x, pts[1].Y + y);
                pts[0].X += x;
                pts[0].Y += y;
                pts[1].X += x;
                pts[1].Y += y;

            }
            else if (CurPointFIdx == 0)
            {
                if (isHorizontal)
                    pts[0] = new Point(curMousePos.X, pts[0].Y);
                else
                    pts[0] = new Point(pts[0].X, curMousePos.Y);
            }
            else
            {
                if (isHorizontal)
                    pts[1] = new Point(curMousePos.X, pts[1].Y);
                else
                    pts[1] = new Point(pts[1].X, curMousePos.Y);
            }
            /*
            Debug.WriteLine("[Move2] CurPointFIdx:" + CurPointFIdx
                + " pts(" + pts[0].X.ToString()
                + "," + pts[0].Y.ToString()
                + ") (" + pts[1].X.ToString()
                + ", " + pts[1].Y.ToString()
                + ") mouse pos (" + curMousePos.X.ToString() 
                + "," + curMousePos.Y.ToString()
                + ") (" + preMousePos.X.ToString() 
                + ", " + preMousePos.Y.ToString() 
                + ")");
            */
        }
        public bool IsAtLine(PointF p)
        {
            CurPointFIdx = -1; //0:move pts[0], 1:move pts[1], 2:move line
            if (isHorizontal)
            {
                if (Math.Abs(p.Y - pts[0].Y) > dragBuffer) return false;
            }
            else
            {
                if (Math.Abs(p.X - pts[0].X) > dragBuffer) return false;
            }
            if (IsAtPointF(p, pts[0])) CurPointFIdx = 0;
            else if (IsAtPointF(p, pts[1])) CurPointFIdx = 1;
            else
            {
                if (isHorizontal)
                {
                    if ((p.X - pts[0].X) * (p.X - pts[1].X) < 0)
                        CurPointFIdx = 2;
                }
                else
                {
                    if ((p.Y - pts[0].Y) * (p.Y - pts[1].Y) < 0)
                        CurPointFIdx = 2;
                }
            }
            Debug.WriteLine("[IsAtLine] CurPointFIdx = " + CurPointFIdx);
            if (CurPointFIdx >= 0) 
                return true;
            return false;
        }
        private bool IsAtPointF(PointF p, PointF target)
        {
            if ((isHorizontal && Math.Abs(p.X - target.X) <= dragBuffer)
                || (!isHorizontal && Math.Abs(p.Y - target.Y) <= dragBuffer))
                return true;
            return false;
        }
        private void DrawRuler(Graphics g)
        {
            g.DrawLine(MyPen, pts[0], pts[1]);
            PointF[] shortLine = new PointF[2];
            if (isHorizontal)
            {
                shortLine[0] = new PointF(pts[0].X, pts[0].Y + 5);
                shortLine[1] = new PointF(pts[0].X, pts[0].Y - 5);
                g.DrawLine(MyPen, shortLine[0], shortLine[1]);
                shortLine[0].X = pts[1].X;
                shortLine[1].X = pts[1].X;
                g.DrawLine(MyPen, shortLine[0], shortLine[1]);
            }
            else
            {
                shortLine[0] = new PointF(pts[0].X + 5, pts[0].Y);
                shortLine[1] = new PointF(pts[0].X - 5, pts[0].Y);
                g.DrawLine(MyPen, shortLine[0], shortLine[1]);
                shortLine[0].Y = pts[1].Y;
                shortLine[1].Y = pts[1].Y;
                g.DrawLine(MyPen, shortLine[0], shortLine[1]);
            }
        }
    }
}
