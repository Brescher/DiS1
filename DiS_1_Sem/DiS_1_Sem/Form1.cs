using ScottPlot;
using ScottPlot.Plottable;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DiS_1_Sem
{
    public partial class Form1 : Form
    {
        SimulationTaskA simA = new SimulationTaskA();
        SimulationTaskB simB = new SimulationTaskB();
        CancellationTokenSource cancelTokenSource;
        SignalPlotXY plot;
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cancelTokenSource = new CancellationTokenSource();
            Task taskA = Task.Factory.StartNew(() => simA.Simulate(Int32.Parse(textBox1.Text), cancelTokenSource.Token));
            Task taskB = Task.Factory.StartNew(() => simB.Simulate(Int32.Parse(textBox1.Text), cancelTokenSource.Token));
            plot = formsPlot1.Plot.AddSignalXY(simB.PlotX, simB.PlotY);
            Task.WaitAll(taskA, taskB);
            //plot.MaxRenderIndex = simB.IndexPlot;
            formsPlot1.Refresh();
        }

        private void timerRender_Tick(object sender, EventArgs e)
        {
            //if (simB.IndexPlot != 0)
            //{
            //    if (simB.IndexPlot == 1000)
            //    {
            //        plot.MaxRenderIndex = 999;
            //    }
            //    else
            //    {
            //        plot.MaxRenderIndex = simB.IndexPlot;
            //    }
            //    formsPlot1.Refresh();

            //}
            label2.Text = simA.AvgWaitTimeTaskA.ToString() + " min";
            label3.Text = (simB.ProbabilityTaskB * 100).ToString() + " %";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cancelTokenSource?.Cancel();
        }
    }
}