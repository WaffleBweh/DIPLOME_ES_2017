using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrisonersDilemmaCA
{
    public partial class BenchmarkView : Form
    {
        public List<Strategy> strategies { get; set; }
        public PayoffMatrix matrix { get; set; }
        public int p1Score = 0;
        public int p2Score = 0;

        public BenchmarkView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Things to be done when the form has finished loading
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BenchmarkView_Load(object sender, EventArgs e)
        {
            // Fill the textboxes and set the default position
            this.cbStrategy1.AddStrategies(strategies);
            this.cbStrategy1.SelectedIndex = 0;

            this.cbStrategy2.AddStrategies(strategies);
            this.cbStrategy2.SelectedIndex = 0;

            // Reset the focus
            this.tbNbTurns.Select();
        }

        /// <summary>
        /// Update the number of turns to play
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbNbTurns_Scroll(object sender, EventArgs e)
        {
            lblNbTurns.Text = tbNbTurns.Value.ToString();
        }

        /// <summary>
        /// Closes the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Plays the game and exports the results onto a graph
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlay_Click(object sender, EventArgs e)
        {
            scoreChart.Series = new SeriesCollection();

            // Create a grid for benchmarking (100px by 100px, 1 by 2 grid)
            Grid benchmarkGrid = new Grid(100, 100, 1, 2, this.matrix, WrapMode.Default);

            // Set the strategies
            Strategy strategyP1 = (Strategy)cbStrategy1.Items[cbStrategy1.SelectedIndex];
            Strategy strategyP2 = (Strategy)cbStrategy2.Items[cbStrategy2.SelectedIndex];
            benchmarkGrid.setStrategy(0, 0, strategyP1);
            benchmarkGrid.setStrategy(1, 0, strategyP2);

            // Play the rounds
            for (int i = 0; i < tbNbTurns.Value; i++)
            {
                benchmarkGrid.step();
                p1Score += benchmarkGrid.Cells[0, 0].Score;
                p2Score += benchmarkGrid.Cells[0, 1].Score;
            }

            this.Size = new Size(820, 340);

            // Charts
            scoreChart.Series.Add(new ColumnSeries
            {
                Title = strategyP1.ToString(),
                Values = new ChartValues<double> { p1Score }
            });

            scoreChart.Series.Add(new ColumnSeries
            {
                Title = strategyP2.ToString(),
                Values = new ChartValues<double> { p2Score }
            });


            scoreChart.AxisX.Add(new Axis
            {
                Title = "Strategy",
                Labels = new[] { strategyP1.ToString(), strategyP2.ToString() }
            });

            //MessageBox.Show("p1: " + p1Score + Environment.NewLine + "p2: " + p2Score);
            p1Score = 0;
            p2Score = 0;
        }

        /// <summary>
        /// Reset the size of the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Size = new Size(460, 340);
        }
    }
}
