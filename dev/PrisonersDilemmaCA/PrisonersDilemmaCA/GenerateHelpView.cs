/*
    Class           :   GenerateHelpView.cs
    Description     :   Gives help on generating grid of cells
    Author          :   SEEMULLER Julien
    Date            :   10.04.2017
*/

using System;
using System.Windows.Forms;

namespace PrisonersDilemmaCA
{
    public partial class GenerateHelpView : Form
    {
        public GenerateHelpView()
        {
            InitializeComponent();
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
    }
}
