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

        public MainView()
        {
            InitializeComponent();

            // Initialize the payoff matrix with default values
            payoffMatrix = new PayoffMatrix();

            // Initialize our grid of cells
            mainGrid = new Grid(pbGrid.Width, pbGrid.Height, tbLines.Value, tbColumns.Value, payoffMatrix);
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

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            mainGrid = new Grid(pbGrid.Width, pbGrid.Height, tbLines.Value, tbColumns.Value, payoffMatrix);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            mainGrid = new Grid(pbGrid.Width, pbGrid.Height, tbLines.Value, tbColumns.Value, payoffMatrix);
        }

        // Open the generation form
        private void generateNewBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        // Open the payoff matrix parameters
        private void payoffMatrixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Pass the PayoffMatrix object as parameter to the form and open it
            PayoffMatrixView matrixView = new PayoffMatrixView(payoffMatrix);
            matrixView.Show();
        }
    }
}
