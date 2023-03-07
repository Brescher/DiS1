using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiS_1_Sem
{
    internal class GenDE
    {
        double tMin, tMax;
        Random random;

        public GenDE(double tMin_, double tMax_)
        {
            tMin = tMin_;
            tMax = tMax_;
            random = new Random();
        }

        public double GenerateValue()
        {
            double value = random.NextDouble() * (tMax - tMin) + tMin;
            return value;
        }
    }
}
