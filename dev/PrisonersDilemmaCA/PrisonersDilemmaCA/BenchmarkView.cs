using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        public int score = 0;
        public int totalScore = 0;
        public StringBuilder csv;

        public const bool SHOULD_EXPORT_DATA = false;

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

            // Reset the focus
            this.tbNbTurns.Select();

            // Set the chart
            scoreChart.AxisY.Add(new Axis
            {
                Title = "Score"
            });
            
            scoreChart.AxisX.Add(new Axis
            {
                Labels = new[] { "Strategies" }
            });
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
            // Reset the score
            csv = new StringBuilder();
            totalScore = 0;

            // Clear the chart
            scoreChart.Series = new SeriesCollection();

            // Create a grid for benchmarking (100px by 100px, 1 by 2 grid)
            Grid benchmarkGrid = new Grid(100, 100, 1, 2, this.matrix, WrapMode.Default);

            // For every available strategy
            foreach (Strategy strat in cbStrategy1.Items)
            {
                // Set the strategy (reset the strategy)
                Strategy strategyP1 = (Strategy)cbStrategy1.Items[cbStrategy1.SelectedIndex];
                benchmarkGrid.setStrategy(0, 0, strategyP1);

                // Set the opposing player's strategy
                benchmarkGrid.setStrategy(1, 0, strat);

                // Get the color from the strategy
                System.Windows.Media.BrushConverter converter = new System.Windows.Media.BrushConverter();
                System.Windows.Media.Brush brush = (System.Windows.Media.Brush)converter.ConvertFromString(strat.getColor().ToHex());


                // Play the rounds
                for (int i = 0; i < tbNbTurns.Value; i++)
                {
                    benchmarkGrid.step();
                    score += benchmarkGrid.Cells[0, 0].Score;
                    totalScore += benchmarkGrid.Cells[0, 0].Score;
                    csv.AppendLine(totalScore.ToString());
                }

                // Check if we should export as csv or not
                if (SHOULD_EXPORT_DATA)
                {
                    // Make sure the csv directory exists
                    if (!Directory.Exists("csv/"))
                    {
                        Directory.CreateDirectory("csv");
                    }

                    // Write the data
                    File.WriteAllText("csv/" + strategyP1.ToString() + " benchmark.csv", csv.ToString());
                }

                // Add the score to the chart
                scoreChart.Series.Add(new ColumnSeries
                {
                    Title = strat.ToString(),
                    Values = new ChartValues<double> { score },
                    Fill = brush,
                });

                // Reset the score
                score = 0;
            }

            // Set the total score label
            lblTotalScore.Text = "Total score: " + totalScore;

            this.Size = new Size(820, 340);
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
