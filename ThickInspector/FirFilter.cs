using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SInspector
{
    public class FirFilter
    {
        protected double[] z;
        public FirFilter(int order)
        {
            this.z = new double[order];
        }

        public double compute(double input, double[] a)
        {
            // computes y(t) = a0*x(t) + a1*x(t-1) + a2*x(t-2) + ... an*x(t-n)
            double result = 0;

            for (int t = a.Length - 1; t >= 0; t--)
            {
                if (t > 0)
                {
                    this.z[t] = this.z[t - 1];
                }
                else
                {
                    this.z[t] = input;
                }
                result += a[t] * this.z[t];
            }
            return result;
        }
    }
}
