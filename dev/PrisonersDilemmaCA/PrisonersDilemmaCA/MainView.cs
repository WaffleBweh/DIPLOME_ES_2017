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
        Grid cellularAutomaton;
        //int nbLines = 10;
        //int nbCols = 10;

        public MainView()
        {
            InitializeComponent();

            // Initialize our grid of cells
            cellularAutomaton = new Grid(pbGrid.Width, pbGrid.Height, tbLines.Value, tbColumns.Value);
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
            cellularAutomaton.draw(e.Graphics);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            cellularAutomaton = new Grid(pbGrid.Width, pbGrid.Height, tbLines.Value, tbColumns.Value);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            cellularAutomaton = new Grid(pbGrid.Width, pbGrid.Height, tbLines.Value, tbColumns.Value);
        }
    }
}
