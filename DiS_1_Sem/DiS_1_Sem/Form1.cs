using System;
using System.Threading;
using System.Threading.Tasks;

namespace DiS_1_Sem
{
    public partial class Form1 : Form
    {
        SimulationTaskA simA = new SimulationTaskA();
        SimulationTaskB simB = new SimulationTaskB();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var plt = new ScottPlot.Plot();

            //Task taskA = Task.Factory.StartNew(() => simA.Simulate(Int32.Parse(textBox1.Text)));
            //Task taskB = Task.Factory.StartNew(() => simB.Simulate(Int32.Parse(textBox1.Text)));
            //Task.WaitAll(taskA, taskB);

            simA.Simulate(Int32.Parse(textBox1.Text));
            simB.Simulate(Int32.Parse(textBox1.Text));

            label2.Text = simA.AvgWaitTimeTaskA.ToString();
            label3.Text = simB.ProbabilityTaskB.ToString();
        }
    }
}