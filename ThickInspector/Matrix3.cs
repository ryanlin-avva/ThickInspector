using System;

namespace SInspector
{
    class Matrix3
    {
        public float[,] M = new float[4, 4];
        public Matrix3()
        {
            Identity3();
        }
        public Matrix3(
            float m00, float m01, float m02, float m03
            , float m10, float m11, float m12, float m13
            , float m20, float m21, float m22, float m23
            , float m30, float m31, float m32, float m33)
        {
            M[0, 0] = m00; M[0, 1] = m01; M[0, 2] = m02; M[0, 3] = m03;
            M[1, 0] = m10; M[1, 1] = m11; M[1, 2] = m12; M[1, 3] = m13;
            M[2, 0] = m20; M[2, 1] = m21; M[2, 2] = m22; M[2, 3] = m23;
            M[3, 0] = m30; M[3, 1] = m31; M[3, 2] = m32; M[3, 3] = m33;
        }
        public static Matrix3 operator *(Matrix3 m1, Matrix3 m2)
        {
            Matrix3 result = new Matrix3();
            for (int i=0; i<4; i++)
            {
                for (int j=0; j<4; j++)
                {
                    float element = 0;
                    for (int k=0; k<4; k++)
                    {
                        element += m1.M[i, k] * m2.M[k, j];
                    }
                    result.M[i, j] = element;
                }
            }
            return result;
        }
        public static Matrix3 Scale3(float sx, float sy, float sz)
        {
            Matrix3 result = new Matrix3();
            result.M[0, 0] = sx;
            result.M[1, 1] = sy;
            result.M[2, 2] = sz;
            return result;
        }
        public static Matrix3 Translate3(float dx, float dy, float dz)
        {
            Matrix3 result = new Matrix3();
            result.M[0, 3] = dx;
            result.M[1, 3] = dy;
            result.M[2, 3] = dz;
            return result;
        }
        //around X axis
        public static Matrix3 Rotate3X(float theta)
        {
            theta = theta * (float)Math.PI / 180f;
            float sn = (float)Math.Sin(theta);
            float cn = (float)Math.Cos(theta);
            Matrix3 m = new Matrix3();
            m.M[1, 1] = cn;
            m.M[1, 2] = -sn;
            m.M[2, 1] = sn;
            m.M[2, 2] = cn;
            return m;
        }
        //around Y axis
        public static Matrix3 Rotate3Y(float theta)
        {
            theta = theta * (float)Math.PI / 180f;
            float sn = (float)Math.Sin(theta);
            float cn = (float)Math.Cos(theta);
            Matrix3 m = new Matrix3();
            m.M[0, 0] = cn;
            m.M[0, 2] = sn;
            m.M[2, 0] = -sn;
            m.M[2, 2] = cn;
            return m;
        }
        //around Z axis
        public static Matrix3 Rotate3Z(float theta)
        {
            theta = theta * (float)Math.PI / 180f;
            float sn = (float)Math.Sin(theta);
            float cn = (float)Math.Cos(theta);
            Matrix3 m = new Matrix3();
            m.M[0, 0] = cn;
            m.M[0, 1] = -sn;
            m.M[1, 0] = sn;
            m.M[1, 1] = cn;
            return m;
        }
        public static Matrix3 FrontView()
        {
            Matrix3 m = new Matrix3();
            m.M[2, 2] = 0;
            return m;
        }
        public static Matrix3 SideView()
        {
            Matrix3 m = new Matrix3();
            m.M[0, 0] = 0;
            m.M[2, 2] = 0;
            m.M[0, 2] = -1;
            return m;
        }
        public static Matrix3 TopView()
        {
            Matrix3 m = new Matrix3();
            m.M[1, 2] = -1;
            m.M[1, 1] = 0;
            m.M[2, 2] = 0;
            return m;
        }
        public static Matrix3 Axonometric(float alpha, float beta)
        {
            Matrix3 m = new Matrix3();
            float sinA = (float)Math.Sin(alpha * Math.PI / 180);
            float cosA = (float)Math.Cos(alpha * Math.PI / 180);
            float sinB = (float)Math.Sin(beta * Math.PI / 180);
            float cosB = (float)Math.Cos(beta * Math.PI / 180);
            m.M[0, 0] = cosB;
            m.M[0, 2] = sinB;
            m.M[1, 0] = sinA * sinB;
            m.M[1, 1] = cosA;
            m.M[1, 2] = -sinA * cosB;
            m.M[2, 2] = 0;
            return m;
        }
        public static Matrix3 AzimuthElevation(float elevation, float azimuth)
        {
            Matrix3 m = new Matrix3();

            //Elevation range = 90 ~ -90
            if (elevation > 90) elevation = 90;
            else if (elevation < -90) elevation = -90;
            elevation = elevation * (float)Math.PI / 180.0f;
            float sinElev = (float)Math.Sin(elevation);
            float cosElev = (float)Math.Cos(elevation);

            //Azimuth range = -180 ~ 180
            if (azimuth > 180) azimuth = 180;
            else if (azimuth < -180) azimuth = -180;
            azimuth = azimuth * (float)Math.PI / 180.0f;
            float sinAzim = (float)Math.Sin(azimuth);
            float cosAzim = (float)Math.Cos(azimuth);

            m.M[0, 0] = cosAzim;
            m.M[0, 1] = sinAzim;
            m.M[0, 2] = 0;
            m.M[1, 0] = -sinElev * sinAzim;
            m.M[1, 1] = sinElev * cosAzim;
            m.M[1, 2] = cosElev;
            m.M[2, 0] = cosElev * sinAzim;
            m.M[2, 1] = -cosElev * cosAzim;
            m.M[2, 2] = sinElev;
            return m;
        }
        public float[] vectorMultiply(float[] vector)
        {
            float[] result = new float[4];
            for (int i=0; i<4; i++)
            {
                for (int j=0; j<4; j++)
                {
                    result[i] += M[i, j] * vector[j];
                }
            }
            return result;
        }
        public void Identity3()
        {
            for (int i=0; i<4; i++)
            {
                for (int j=0; j<4; j++)
                {
                    if (i == j)
                    {
                        M[i, j] = 1;
                    }
                    else
                    {
                        M[i, j] = 0;
                    }
                }
            }
        }
    }
}
