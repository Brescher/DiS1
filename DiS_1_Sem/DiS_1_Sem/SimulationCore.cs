using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiS_1_Sem
{
    internal abstract class SimulationCore
    {
        protected double replications;
        private int repsDone;

        protected int RepsDone { get => repsDone; set => repsDone = value; }

        public async Task Simulate(double replications_)
        {
            replications = replications_;
            RepsDone = 0;
            BeforeSimulation();
            for(int RepsDone = 0; RepsDone < replications; RepsDone++)
            {
                BeforeReplication();
                OneReplication();
                AfterReplication();
            }
            AfterSimulation();
        }

        public abstract void OneReplication();
        public abstract void BeforeSimulation();
        public abstract void AfterSimulation();
        public abstract void BeforeReplication();
        public abstract void AfterReplication();
    }
}
