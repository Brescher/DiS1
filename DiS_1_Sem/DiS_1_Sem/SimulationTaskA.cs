using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiS_1_Sem
{
    internal class SimulationTaskA : SimulationCore
    {
        GenAB routeAAB;
        GenBC routeABC;
        GenCM routeACM;
        double timeRouteA;
        //ArrayList timesRouteA = new ArrayList();

        List<ValueForGen> cm = new List<ValueForGen>();

        private double sumWaitTimeTaskA, avgWaitTimeTaskA;

        public double SumWaitTimeTaskA { get => sumWaitTimeTaskA; set => sumWaitTimeTaskA = value; }
        public double AvgWaitTimeTaskA { get => avgWaitTimeTaskA; set => avgWaitTimeTaskA = value; }
        //public ArrayList TimesRouteA { get => timesRouteA; set => timesRouteA = value; }

        public SimulationTaskA()
        {
            ValueForGen CM1 = new ValueForGen(3, 10, 0.2);
            ValueForGen CM2 = new ValueForGen(11, 20, 0.2);
            ValueForGen CM3 = new ValueForGen(21, 34, 0.3);
            ValueForGen CM4 = new ValueForGen(35, 52, 0.1);
            ValueForGen CM5 = new ValueForGen(53, 59, 0.15);
            ValueForGen CM6 = new ValueForGen(60, 95, 0.03);
            ValueForGen CM7 = new ValueForGen(96, 110, 0.02);

            cm.Add(CM1);
            cm.Add(CM2);
            cm.Add(CM3);
            cm.Add(CM4);
            cm.Add(CM5);
            cm.Add(CM6);
            cm.Add(CM7);
        }

        public override void AfterReplication()
        {
            //TimesRouteA.Add(timeRouteA);
            if(timeRouteA > 125)
            {
                SumWaitTimeTaskA += timeRouteA - 125;
            }
        }

        public override void AfterSimulation()
        {
            AvgWaitTimeTaskA = SumWaitTimeTaskA / replications;
            //TimesRouteA.Clear();
            cm.Clear();
        }

        public override void BeforeReplication()
        {
            timeRouteA = 0;
        }

        public override void BeforeSimulation()
        {
            SumWaitTimeTaskA = 0;
            AvgWaitTimeTaskA = 0;

            routeAAB = new GenAB(39, 64);
            routeABC = new GenBC(57);
            routeACM = new GenCM(cm);
        }

        public override void OneReplication()
        {
            timeRouteA += routeAAB.GenerateValue();
            timeRouteA += routeABC.GenerateValue();
            timeRouteA += routeACM.GenerateValue();
        }
    }
}
