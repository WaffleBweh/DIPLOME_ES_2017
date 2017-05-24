/*
    Class           :   PayoffMatrixHelpView.cs
    Description     :   Gives help to the user on payoff matrixes
    Author          :   SEEMULLER Julien
    Date            :   10.04.2017
*/

using System;
using System.Windows.Forms;

namespace PrisonersDilemmaCA
{
    public partial class PayoffMatrixHelpView : Form
    {
        public PayoffMatrixHelpView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Quit the help form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
