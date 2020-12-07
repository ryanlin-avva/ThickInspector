using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThickInspector
{
    class Constants
    {
        public const int DotNumber = 192;
        public const int DotDistance = 5;//um
        public const int caliLength = 3;

        public const int Draw3DXPointTotal = 70;
        public const int Draw3DYPointTotal = 70;

        public const int Draw2DXTickNumber = 15;
        public const int Draw2DZTickNumber = 8;

        public const int Draw3DXTickNumber = 7;
        public const int Draw3DYTickNumber = 10;
        public const int Draw3DZTickNumber = 8;

        //Add some space outside the highest/lowest z value
        public const int Draw3DZAxisPadding = 5;

        public const float Draw3DElevation = 30;
        //public const float Draw3DAzimuth = -37.5f;
        public const float Draw3DAzimuth = -63.5f;

        public const float Draw2DZAxisPadding = 0.1f;


    }
}
