using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiS_1_Sem
{
    internal class GenAB
    {
        int tMin, tMax;
        Random random;

        public GenAB(int tMin_, int tMax_)
        {
            tMin = tMin_;
            tMax = tMax_;
            random = new Random();
        }
        public int GenerateValue()
        {
            int value = random.Next(tMin, tMax + 1);
            return value;
        }
    }
}
