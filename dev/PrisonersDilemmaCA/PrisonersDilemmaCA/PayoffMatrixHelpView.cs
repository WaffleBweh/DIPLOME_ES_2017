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
