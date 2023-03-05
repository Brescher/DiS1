using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiS_1_Sem
{
    internal class GenCM
    {
        List<ValueForGen> valuesForGens;
        Random option1;
        Random option2;
        Random option3;
        Random option4;
        Random option5;
        Random option6;
        Random option7;
        Random probability;
        Random genForOptions = new Random();
        public GenCM(List<ValueForGen> valuesForGens_)
        {
            valuesForGens = valuesForGens_;
            probability = new Random(genForOptions.Next());
            option1 = new Random(genForOptions.Next());
            option2 = new Random(genForOptions.Next());
            option3 = new Random(genForOptions.Next());
            option4 = new Random(genForOptions.Next());
            option5 = new Random(genForOptions.Next());
            option6 = new Random(genForOptions.Next());
            option7 = new Random(genForOptions.Next());
        }
        public int GenerateValue()
        {
            double pGen = probability.NextDouble();
            if (pGen < valuesForGens[0].P)
            {
                return option1.Next(valuesForGens[0].TMin, valuesForGens[0].TMax + 1);
            }
            else if (pGen >= valuesForGens[0].P && 
                    pGen < valuesForGens[0].P + valuesForGens[1].P)
            {
                return option2.Next(valuesForGens[1].TMin, valuesForGens[1].TMax + 1);
            }
            else if (pGen >= valuesForGens[0].P + valuesForGens[1].P && 
                    pGen < valuesForGens[0].P + valuesForGens[1].P + valuesForGens[2].P)
            {
                return option3.Next(valuesForGens[2].TMin, valuesForGens[2].TMax + 1);
            }
            else if (pGen >= valuesForGens[0].P + valuesForGens[1].P + valuesForGens[2].P && 
                    pGen < valuesForGens[0].P + valuesForGens[1].P + valuesForGens[2].P + valuesForGens[3].P)
            {
                return option4.Next(valuesForGens[3].TMin, valuesForGens[3].TMax + 1);
            }
            else if (pGen >= valuesForGens[0].P + valuesForGens[1].P + valuesForGens[2].P + valuesForGens[3].P &&
                    pGen < valuesForGens[0].P + valuesForGens[1].P + valuesForGens[2].P + valuesForGens[3].P + valuesForGens[4].P)
            {
                return option5.Next(valuesForGens[4].TMin, valuesForGens[4].TMax + 1);
            }
            else if (pGen >= valuesForGens[0].P + valuesForGens[1].P + valuesForGens[2].P + valuesForGens[3].P + valuesForGens[4].P &&
                    pGen < valuesForGens[0].P + valuesForGens[1].P + valuesForGens[2].P + valuesForGens[3].P + valuesForGens[4].P + valuesForGens[5].P)
            {
                return option6.Next(valuesForGens[5].TMin, valuesForGens[5].TMax + 1);
            }
            else
            {
                return option7.Next(valuesForGens[6].TMin, valuesForGens[6].TMax + 1);
            }
        }
    }
}
