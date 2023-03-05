using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiS_1_Sem
{
    internal class GenEC
    {
        List<ValueForGen> valuesForGens;
        Random option1;
        Random option2;
        Random option3;
        Random probability;
        Random genForOptions = new Random();
        public GenEC(List<ValueForGen> valuesForGens_)
        {
            valuesForGens = valuesForGens_;
            probability = new Random(genForOptions.Next());
            option1 = new Random(genForOptions.Next());
            option2 = new Random(genForOptions.Next());
            option3 = new Random(genForOptions.Next());
        }
        public int GenerateValue()
        {
            double pGen = probability.NextDouble();
            if(pGen < valuesForGens[0].P)
            {
                return option1.Next(valuesForGens[0].TMin, valuesForGens[0].TMax + 1);
            } 
            else if (pGen >= valuesForGens[0].P && pGen < valuesForGens[0].P + valuesForGens[1].P)
            {
                return option2.Next(valuesForGens[1].TMin, valuesForGens[1].TMax + 1);
            } 
            else
            {

                return option3.Next(valuesForGens[2].TMin, valuesForGens[2].TMax + 1);
            }
        }
    }
}
