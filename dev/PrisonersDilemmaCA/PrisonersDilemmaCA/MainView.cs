using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrisonersDilemmaCA
{
    public partial class MainView : Form
    {

        /**************************************************************************
         *                            GLOBAL VARIABLES                            *
         **************************************************************************/
        GridController _ctrl;

        public GridController Ctrl
        {
            get { return _ctrl; }
            set { _ctrl = value; }
        } 

        bool isClickingOnGrid = false;
        bool isAutoplaying = false;
        int mouseX = 0;
        int mouseY = 0;
        int generation = 0;
        WrapMode gridWrappingMode = WrapMode.Default;

        const int MAX_NB_ELEMENTS_IN_CHART = 10;
        const int DEFAULT_NORMAL_VIEW_WIDTH = 610;
        const int DEFAULT_EXTENDED_VIEW_WIDTH = 1100;
        /**************************************************************************
         *                                EVENTS                                  *
         **************************************************************************/
        /// <summary>
        /// Default constructor
        /// </summary>
        public MainView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Set up the form after it is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainView_Load(object sender, EventArgs e)
        {
            this.Ctrl = new GridController(pbGrid.Width, pbGrid.Height, tbLines.Value, tbColumns.Value, gridWrappingMode);

            // Initialise the combobox with strategies and colors
            cbStrategies.AddStrategies(this.Ctrl.AvailableStrategies);

            // Select the first element by default
            cbStrategies.SelectedIndex = 0;

            // Set the user help text
            lblUserHelp.Text = "Click on a cell to change its strategy."
                + Environment.NewLine + "The default strategy is "
                + Cell.DEFAULT_STRATEGY.ToString();

            // Update the other labels
            updateLabels();

            // CHARTS
            // Pie chart
            pieStrategy.InnerRadius = 50;
            pieStrategy.LegendLocation = LegendLocation.Right;
            pieStrategy.DisableAnimations = true;
            pieStrategy.Series = new SeriesCollection();

            foreach (Strategy strategy in this.Ctrl.AvailableStrategies)
            {
                // Get the color from the strategy
                System.Windows.Media.BrushConverter converter = new System.Windows.Media.BrushConverter();
                System.Windows.Media.Brush brush = (System.Windows.Media.Brush)converter.ConvertFromString(strategy.getColor().ToHex());

                // Create an object for storing values on the pie chart
                PieSeries stratToAdd = new PieSeries
                {
                    Title = strategy.ToString(),
                    Values = new ChartValues<double> 
                        {
                            this.Ctrl.findCountOfStrategy(strategy) 
                        },
                    DataLabels = true,
                    Fill = brush
                };

                stratToAdd.Visibility = System.Windows.Visibility.Hidden;


                // Add the values to the pie chart
                pieStrategy.Series.Add(stratToAdd);
            }

            // Cartesian
            cartesianStrategy.LegendLocation = LegendLocation.Right;
            cartesianStrategy.AxisX.Add(new Axis
            {
                Title = "Current Generation",
                LabelFormatter = value => value.ToString()
            });

            cartesianStrategy.AxisY.Add(new Axis
            {
                Title = "Number of Days in Prison",
                LabelFormatter = value => value.ToString(),

            });

            // Initialize the cartesian chart
            initializeChart();
            updateDonutChart();
        }

        /// <summary>
        /// Force refresh the form each tick of the timer
        /// Default tickrate : 16ms -> 60fps
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainTimer_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        private void pbGrid_Paint(object sender, PaintEventArgs e)
        {
            // Draw code here
            this.Ctrl.draw(e.Graphics);
        }

        /// <summary>
        /// Updates when changing the number of cells horizontally
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            updateGrid();
        }

        /// <summary>
        /// Updates when changing the number of cells vertically
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            updateGrid();
        }

        /// <summary>
        /// Open the generation form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void generateNewBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            interruptTimer();

            // Pass the grid and list of strategies to the form and open them
            GenerateView generateView = new GenerateView();
            generateView.currentGrid = this.Ctrl.Grid;                                   // TO CHANGE, NOT MVC !!
            generateView.strategies = this.Ctrl.AvailableStrategies;                     // TO CHANGE, NOT MVC !!

            if (generateView.ShowDialog() == DialogResult.OK)
            {
                // The user has validated his input
                // Reset the generation count
                generation = 0;

                // Update the GUI
                updateLabels();
                updateDonutChart();
                initializeChart();
                this.Ctrl.setColorMode(ColorMode.Strategy);
            }
        }

        /// <summary>
        /// Open the payoff matrix parameters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void payoffMatrixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            interruptTimer();

            // Pass the PayoffMatrix object as parameter to the form and open it
            PayoffMatrixView matrixView = new PayoffMatrixView();
            matrixView.currentMatrix = this.Ctrl.PayoffMatrix;                          // TO CHANGE, NOT MVC !!

            if (matrixView.ShowDialog() == DialogResult.Yes)
            {
                // The user has validated his input
            }
        }

        /// <summary>
        /// Open the about window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutView view = new AboutView();

            if (view.ShowDialog() == DialogResult.OK)
            {
                // The user has validated his input
            }
        }

        /// <summary>
        /// Update a flag when we click on the grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbGrid_MouseDown(object sender, MouseEventArgs e)
        {
            isClickingOnGrid = true;
            updateCellState();
        }

        /// <summary>
        /// Update a flag when we release our click on the grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbGrid_MouseUp(object sender, MouseEventArgs e)
        {
            isClickingOnGrid = false;
            updateCellState();
            updateDonutChart();
        }

        /// <summary>
        /// Updates the clicked cell with its new strategy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbGrid_MouseMove(object sender, MouseEventArgs e)
        {
            mouseX = e.X;
            mouseY = e.Y;
            updateCellState();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlayPause_Click(object sender, EventArgs e)
        {
            // Change the button's text and launch the timer
            switchPlayPauseState();
        }

        /// <summary>
        /// Manually steps forward (click)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStep_Click(object sender, EventArgs e)
        {
            stepForward();
        }

        /// <summary>
        /// Automatically steps forwards
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StepTimer_Tick(object sender, EventArgs e)
        {
            stepForward();
        }

        /// <summary>
        /// Change the autostep speed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbTimerSpeed_Scroll(object sender, EventArgs e)
        {
            StepTimer.Interval = tbTimerSpeed.Value;
            updateLabels();
        }


        /// <summary>
        /// Switch back to strategy color mode when we click on the strategy combo box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbStrategies_Click(object sender, EventArgs e)
        {
            // Interrupt the autoplay if it is running
            interruptTimer();
            this.Ctrl.setColorMode(ColorMode.Strategy);
            updateLabels();
            Refresh();
        }

        // Clears the board and fills it with the default cell
        private void btnClear_Click(object sender, EventArgs e)
        {
            updateGrid();
        }


        /// <summary>
        /// Alternates between normal and extended view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsExtendedView_CheckedChanged(object sender, EventArgs e)
        {
            if (tsExtendedView.Checked)
            {
                // Switch to extended view
                this.Width = DEFAULT_EXTENDED_VIEW_WIDTH;
            }
            else
            {
                // Switch to normal view
                this.Width = DEFAULT_NORMAL_VIEW_WIDTH;
            }
        }

        /// <summary>
        /// Alternates between default and torus wrapping mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsWrapMode_CheckedChanged(object sender, EventArgs e)
        {
            if (tsWrapMode.Checked)
            {
                gridWrappingMode = WrapMode.Torus;
            }
            else
            {
                gridWrappingMode = WrapMode.Default;
            }

            // Reset the grid to regenerate the neighbors lists
            updateGrid();
        }

        /// <summary>
        /// Serialize and save the grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Ctrl.saveData();
            MessageBox.Show("Data successfully exported !");
        }

        /// <summary>
        /// Load the serialized grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadAGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Ctrl.loadData();
            MessageBox.Show("Data successfully loaded !");
            Refresh();
        }

        /**************************************************************************
         *                                FUNCTIONS                               *
         **************************************************************************/
        /// <summary>
        /// Switch the states between play and pause
        /// </summary>
        public void switchPlayPauseState()
        {
            if (isAutoplaying)
            {
                btnPlayPause.Text = "4";
                StepTimer.Stop();
            }
            else
            {
                btnPlayPause.Text = ";";
                StepTimer.Start();
            }

            // Invert the state
            isAutoplaying = !isAutoplaying;
        }


        /// <summary>
        /// Steps forward in time
        /// </summary>
        private void stepForward()
        {
            // Steps forward
            this.Ctrl.step();
            this.Ctrl.setColorMode(ColorMode.Playing);

            // Increment the generation count
            generation++;

            // Update the GUI
            updateLabels();
            updateDonutChart();
            addDataToChart();
        }



        /// <summary>
        /// Pause the "autostep" timer if it is running
        /// </summary>
        public void interruptTimer()
        {
            if (isAutoplaying)
            {
                switchPlayPauseState();
            }
        }

        /// <summary>
        /// Updates the labels with new information
        /// </summary>
        private void updateLabels()
        {
            // Trackbar labels
            lblLines.Text = String.Format("Rows : {0}", tbLines.Value);
            lblCols.Text = String.Format("Columns : {0}", tbColumns.Value);

            // Grid label
            lblGridInfo.Text = String.Format("{0}x{1} Grid - Mode : {2} - Generation {3}", tbLines.Value, tbColumns.Value, this.Ctrl.getColorMode().ToString(), generation);

            // Speed labels
            lblSpeedValue.Text = "automatically steps every " + tbTimerSpeed.Value + " [ms]";
        }

        /// <summary>
        /// If the user is clicking on the grid, update the cell under the user's cursor
        /// </summary>
        public void updateCellState()
        {
            if (isClickingOnGrid)
            {
                Strategy selectedStrategy = this.Ctrl.AvailableStrategies[cbStrategies.SelectedIndex];         // TO CHANGE
                this.Ctrl.onClick(mouseX, mouseY, selectedStrategy);

                // Interrupt the autoplay if it is running
                interruptTimer();

                // Change the color mode
                this.Ctrl.setColorMode(ColorMode.Strategy);
                updateLabels();
                Refresh();
            }
        }

        /// <summary>
        /// Updates the grid with new values (Re-create the grid)
        /// </summary>
        private void updateGrid()
        {
            // Interrupt the autoplay if it is running
            interruptTimer();
            this.Ctrl = new GridController(pbGrid.Width, pbGrid.Height, tbLines.Value, tbColumns.Value, gridWrappingMode);

            // Reset the generation count
            generation = 0;

            // Update the labels and chart
            updateLabels();
            updateDonutChart();
            initializeChart();
        }

        /// <summary>
        /// Updates the donut chart on the main view
        /// </summary>
        private void updateDonutChart()
        {
            // Update the donut chart
            int count = 0;
            foreach (Series serie in pieStrategy.Series)
            {
                if (this.Ctrl.findCountOfStrategy(this.Ctrl.AvailableStrategies[count]) > 0)                    // TO CHANGE, NOT MVC
                {
                    serie.Visibility = System.Windows.Visibility.Visible;
                    serie.Values = new ChartValues<double> { this.Ctrl.findCountOfStrategy(this.Ctrl.AvailableStrategies[count]) };
                }
                else
                {
                    serie.Visibility = System.Windows.Visibility.Hidden;
                }

                count++;
            }
        }

        /// <summary>
        /// Initialize the cartesian chart with the base values
        /// </summary>
        public void initializeChart()
        {
            cartesianStrategy.Series = new SeriesCollection();
            foreach (Strategy strategy in this.Ctrl.AvailableStrategies)                    // TO CHANGE, NOT MVC
            {
                // Get the color from the strategy
                System.Windows.Media.BrushConverter converter = new System.Windows.Media.BrushConverter();
                System.Windows.Media.Brush brush = (System.Windows.Media.Brush)converter.ConvertFromString(strategy.getColor().ToHex(60));
                System.Windows.Media.Brush stroke = (System.Windows.Media.Brush)converter.ConvertFromString(strategy.getColor().ToHex());

                // Create an object for storing values on the line chart
                LineSeries stratToAdd = new LineSeries
                {
                    Title = strategy.ToString(),
                    Values = new ChartValues<double> { 0 },
                    PointGeometry = DefaultGeometries.None,
                    PointGeometrySize = 15,
                    Fill = brush,
                    Stroke = stroke
                };

                // Hide the unused strategies
                if (this.Ctrl.findCountOfStrategy(strategy) <= 0)
                {
                    stratToAdd.Visibility = System.Windows.Visibility.Hidden;
                }

                cartesianStrategy.AxisX[0].MinValue = 0;
                cartesianStrategy.AxisX[0].MaxValue = MAX_NB_ELEMENTS_IN_CHART;

                // Add the values to the pie chart
                cartesianStrategy.Series.Add(stratToAdd);
            }
        }

        /// <summary>
        /// Adds data to the cartesian chart
        /// </summary>
        private void addDataToChart()
        {
            int count = 0;

            // Readjust the X axis
            cartesianStrategy.AxisX[0].MaxValue = generation;
            if (generation > MAX_NB_ELEMENTS_IN_CHART)
            {
                cartesianStrategy.AxisX[0].MinValue = generation - MAX_NB_ELEMENTS_IN_CHART;
            }

            foreach (Series serie in cartesianStrategy.Series)
            {

                // Check the currently used strategies
                if (this.Ctrl.findCountOfStrategy(this.Ctrl.AvailableStrategies[count]) > 0)    // TO CHANGE, NOT MVC
                {
                    // Add the average score of each used strategy
                    serie.Values.Add(this.Ctrl.findAvgScoreOfStrategy(this.Ctrl.AvailableStrategies[count]));    // TO CHANGE, NOT MVC
                    serie.Visibility = System.Windows.Visibility.Visible;
                }
                else
                {
                    // Add 0 to the unused values (allows the graph to stay synced)
                    serie.Values.Add((double)0);
                    serie.Visibility = System.Windows.Visibility.Hidden;
                }

                count++;
            }
        }
    }
}
