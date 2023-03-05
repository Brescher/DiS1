using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiS_1_Sem
{
    internal class GenBC
    {
        int value;

        public GenBC(int value_)
        {
            value = value_;
        }
        public int GenerateValue()
        {
            return value;
        }
    }
}
