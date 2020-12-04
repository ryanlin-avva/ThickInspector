using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SInspector
{
    class ColorMap
    {
        private int colorMapLength = 64;
        private int alphaValue = 255;

        public ColorMap()
        {
        }
        public ColorMap(int len)
        {
            colorMapLength = len;
        }
        public ColorMap(int len, int alpha)
        {
            colorMapLength = len;
            alphaValue = alpha;
        }
        public int GetColorNumber()
        {
            return colorMapLength;
        }
        public int[,] Spring()
        {
            var cmap = new int[colorMapLength, 4];
            var gradient = new float[colorMapLength];
            for (int i = 0; i < colorMapLength; i++)
            {
                gradient[i] = 1.0f * i / (colorMapLength - 1);
                cmap[i, 0] = alphaValue;
                cmap[i, 1] = 255;
                cmap[i, 2] = (int)(255 * gradient[i]);
                cmap[i, 3] = 255 - cmap[i, 2];
            }
            return cmap;
        }
        public int[,] Summer()
        {
            var cmap = new int[colorMapLength, 4];
            var gradient = new float[colorMapLength];
            for (int i = 0; i < colorMapLength; i++)
            {
                gradient[i] = 1.0f * i / (colorMapLength - 1);
                cmap[i, 0] = alphaValue;
                cmap[i, 1] = (int)(255 * gradient[i]);
                cmap[i, 2] = (int)(255 * 0.5f * (1 + gradient[i]));
                cmap[i, 3] = (int)(255 * 0.4f);
            }
            return cmap;
        }
        public int[,] Autumn()
        {
            var cmap = new int[colorMapLength, 4];
            var gradient = new float[colorMapLength];
            for (int i = 0; i < colorMapLength; i++)
            {
                gradient[i] = 1.0f * i / (colorMapLength - 1);
                cmap[i, 0] = alphaValue;
                cmap[i, 1] = 255;
                cmap[i, 2] = (int)(255 * gradient[i]);
                cmap[i, 3] = 0;
            }
            return cmap;
        }
        public int[,] Winter()
        {
            var cmap = new int[colorMapLength, 4];
            var gradient = new float[colorMapLength];
            for (int i = 0; i < colorMapLength; i++)
            {
                gradient[i] = 1.0f * i / (colorMapLength - 1);
                cmap[i, 0] = alphaValue;
                cmap[i, 1] = 0;
                cmap[i, 2] = (int)(255 * gradient[i]);
                cmap[i, 3] = (int)(255 * (1.0f - 0.5f * gradient[i]));
            }
            return cmap;
        }
        public int[,] Gray()
        {
            var cmap = new int[colorMapLength, 4];
            var gradient = new float[colorMapLength];
            for (int i = 0; i < colorMapLength; i++)
            {
                gradient[i] = 1.0f * i / (colorMapLength - 1);
                cmap[i, 0] = alphaValue;
                cmap[i, 1] = (int)(255 * gradient[i]);
                cmap[i, 2] = (int)(255 * gradient[i]);
                cmap[i, 3] = (int)(255 * gradient[i]);
            }
            return cmap;
        }

        public int[,] Jet()
        {
            int[,] cmap = new int[colorMapLength, 4];
            float[,] cMatrix = new float[colorMapLength, 3];
            int n = (int)Math.Ceiling(colorMapLength / 4.0f);
            int nMod = 0;
            float[] fArray = new float[3 * n - 1];
            int[] red = new int[fArray.Length];
            int[] green = new int[fArray.Length];
            int[] blue = new int[fArray.Length];

            if (colorMapLength % 4 == 1)
            {
                nMod = 1;
            }
            for (int i = 0; i < fArray.Length; i++)
            {
                if (i < n)
                    fArray[i] = (float)(i + 1) / n;
                else if (i < 2 * n - 1)
                    fArray[i] = 1.0f;
                else
                    fArray[i] = (float)(3 * n - 1 - i) / n;
                green[i] = (int)Math.Ceiling(n / 2.0f) - nMod + i;
                red[i] = green[i] + n;
                blue[i] = green[i] - n;
            }
            int nb = 0;
            for (int i = 0; i < blue.Length; i++)
            {
                if (blue[i] > 0) nb++;
            }
            for (int i = 0; i < colorMapLength; i++)
            {
                for (int j = 0; j < red.Length; j++)
                {
                    if (i == red[j] && red[j] < colorMapLength)
                    {
                        cMatrix[i, 0] = fArray[i - red[0]];
                    }
                }
                for (int j = 0; j < green.Length; j++)
                {
                    if (i == green[j] && green[j] < colorMapLength)
                    {
                        cMatrix[i, 1] = fArray[i - green[0]];
                    }
                }
                for (int j = 0; j < blue.Length; j++)
                {
                    if (i == blue[j] && blue[j] >= 0)
                    {
                        cMatrix[i, 2] = fArray[fArray.Length - 1 - nb + i];
                    }
                }
            }
            for (int i = 0; i < colorMapLength; i++)
            {
                cmap[i, 0] = alphaValue;
                for (int j = 0; j < 3; j++)
                {
                    cmap[i, j + 1] = (int)(cMatrix[i, j] * 255);
                }
            }
            return cmap;
        }
    }
}
