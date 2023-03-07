using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiS_1_Sem
{
    internal class SimulationTaskB : SimulationCore
    {
        GenDE routeBDE;
        GenEC routeBEC;
        GenCM routeBCM;
        double timeRouteB;
        double[] plotX = new double[1000];
        double[] plotY = new double[1000];
        int indexPlot;

        List<ValueForGen> cm = new List<ValueForGen>();
        List<ValueForGen> ec = new List<ValueForGen>();

        private double probabilityTaskB, hits;

        public double ProbabilityTaskB { get => probabilityTaskB; set => probabilityTaskB = value; }
        public double[] PlotX { get => plotX; set => plotX = value; }
        public double[] PlotY { get => plotY; set => plotY = value; }
        public int IndexPlot { get => indexPlot; set => indexPlot = value; }


        public SimulationTaskB()
        {
            

            ValueForGen CM1 = new ValueForGen(3, 10, 0.2);
            ValueForGen CM2 = new ValueForGen(11, 20, 0.2);
            ValueForGen CM3 = new ValueForGen(21, 34, 0.3);
            ValueForGen CM4 = new ValueForGen(35, 52, 0.1);
            ValueForGen CM5 = new ValueForGen(53, 59, 0.15);
            ValueForGen CM6 = new ValueForGen(60, 95, 0.03);
            ValueForGen CM7 = new ValueForGen(96, 110, 0.02);

            ValueForGen EC1 = new ValueForGen(230, 243, 0.3);
            ValueForGen EC2 = new ValueForGen(244, 280, 0.5);
            ValueForGen EC3 = new ValueForGen(281, 350, 0.2);

            cm.Add(CM1);
            cm.Add(CM2);
            cm.Add(CM3);
            cm.Add(CM4);
            cm.Add(CM5);
            cm.Add(CM6);
            cm.Add(CM7);

            ec.Add(EC1);
            ec.Add(EC2);
            ec.Add(EC3);
        }

        public override void AfterReplication()
        {
            if (timeRouteB <= 320)
            {
                hits++;
            }
            RepsDone++;
            probabilityTaskB = hits / RepsDone;
            if (RepsDone % (replications / 1000) == 0)
            {
                plotX[indexPlot] = RepsDone;
                plotY[indexPlot] = ProbabilityTaskB;
                indexPlot++;
            }
        }

        public override void AfterSimulation()
        {
            ProbabilityTaskB = hits / RepsDone;
        }

        public override void BeforeReplication()
        {
            timeRouteB = 0;
        }

        public override void BeforeSimulation()
        {
            ProbabilityTaskB = 0;
            hits = 0;
            IndexPlot = 0;

            routeBDE = new GenDE(19, 36);
            routeBEC = new GenEC(ec);
            routeBCM = new GenCM(cm);
        }

        public override void OneReplication()
        {
            timeRouteB += routeBDE.GenerateValue();
            timeRouteB += routeBEC.GenerateValue();
            timeRouteB += routeBCM.GenerateValue();
        }
    }
}
