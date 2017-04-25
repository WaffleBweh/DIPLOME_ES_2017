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
    public partial class MainView : Form
    {
        Grid mainGrid;
        PayoffMatrix payoffMatrix;
        List<Strategy> availableStrategies;
        bool isClickingOnGrid = false;
        bool isAutoplaying = false;
        int mouseX = 0;
        int mouseY = 0;

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
            // Make a list of all our available strategies
            availableStrategies = new List<Strategy>();
            // To add more strategies, add them to the list
            availableStrategies.Add(new StratRandom());
            availableStrategies.Add(new StratTitForTat());
            availableStrategies.Add(new StratBlinker());
            availableStrategies.Add(new StratAlwaysCooperate());
            availableStrategies.Add(new StratAlwaysDefect());
            availableStrategies.Add(new StratTitForTwoTats());
            availableStrategies.Add(new StratGrimTrigger());
            availableStrategies.Add(new StratReverseTitForTat());

            // Sort the list
            availableStrategies.Sort();

            // Initialize the payoff matrix with default values
            payoffMatrix = new PayoffMatrix();

            // Initialize our grid of cells
            mainGrid = new Grid(pbGrid.Width, pbGrid.Height, tbLines.Value, tbColumns.Value, payoffMatrix);

            // Initialise the combobox with strategies and colors
            cbStrategies.AddStrategies(availableStrategies);

            // Select the first element by default
            cbStrategies.SelectedIndex = 0;

            // Set the user help text
            lblUserHelp.Text = "Click on a cell to change its strategy."
                + Environment.NewLine + "The default strategy is "
                + Cell.DEFAULT_STRATEGY.ToString();
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
            mainGrid.draw(e.Graphics);
        }

        /// <summary>
        /// Updates when changing the number of cells horizontally
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            UpdateGrid();
        }

        /// <summary>
        /// Updates when changing the number of cells vertically
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            UpdateGrid();
        }

        /// <summary>
        /// Updates the grid with new values (Re-create the grid)
        /// </summary>
        private void UpdateGrid()
        {
            // Interrupt the autoplay if it is running
            interruptTimer();
            mainGrid = new Grid(pbGrid.Width, pbGrid.Height, tbLines.Value, tbColumns.Value, payoffMatrix);
        }

        // Open the generation form
        private void generateNewBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            interruptTimer();

            // Pass the grid and list of strategies to the form and open them
            GenerateView generateView = new GenerateView();
            generateView.currentGrid = this.mainGrid;
            generateView.strategies = this.availableStrategies;
            generateView.Show();
        }

        // Open the payoff matrix parameters
        private void payoffMatrixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            interruptTimer();

            // Pass the PayoffMatrix object as parameter to the form and open it
            PayoffMatrixView matrixView = new PayoffMatrixView();
            matrixView.currentMatrix = this.payoffMatrix;
            matrixView.Show();
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
        /// If the user is clicking on the grid, update the cell under the user's cursor
        /// </summary>
        public void updateCellState()
        {
            if (isClickingOnGrid)
            {
                Strategy selectedStrategy = availableStrategies[cbStrategies.SelectedIndex];
                this.mainGrid.onClick(mouseX, mouseY, selectedStrategy);

                // Interrupt the autoplay if it is running
                interruptTimer();

                // Change the color mode
                mainGrid.setColorMode(ColorMode.Strategy);
                Refresh();
            }
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
        /// Steps forward in time
        /// </summary>
        private void stepForward()
        {
            mainGrid.step();
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

        private void tbTimerSpeed_Scroll(object sender, EventArgs e)
        {
            StepTimer.Interval = tbTimerSpeed.Value;
            lblSpeedValue.Text = "automatically steps every " + tbTimerSpeed.Value + " [ms]";
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
            mainGrid.setColorMode(ColorMode.Strategy);
            Refresh();
        }

        // Pause the timer if it is running
        public void interruptTimer()
        {
            if (isAutoplaying)
            {
                switchPlayPauseState();
            }
        }

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
    }
}
