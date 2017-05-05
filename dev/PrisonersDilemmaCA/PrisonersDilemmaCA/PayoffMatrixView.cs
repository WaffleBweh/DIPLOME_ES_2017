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
    public partial class PayoffMatrixView : Form
    {
        public PayoffMatrix currentMatrix { get; set; }

        public PayoffMatrixView()
        {
            InitializeComponent();
        }

        private void PayoffMatrixView_Load(object sender, EventArgs e)
        {
            // Initialize our textboxes with the matrix data
            rtbReward.Text = currentMatrix.Reward.ToString();
            rtbSucker.Text = currentMatrix.Sucker.ToString();
            rtbTemptation.Text = currentMatrix.Temptation.ToString();
            rtbPunishment.Text = currentMatrix.Punishment.ToString();
        }

        // Apply the changes and quit
        private void btnOk_Click(object sender, EventArgs e)
        {
            // Store the contents of the textboxes as integers
            int t = Convert.ToInt32(rtbTemptation.Text);
            int r = Convert.ToInt32(rtbReward.Text);
            int p = Convert.ToInt32(rtbPunishment.Text);
            int s = Convert.ToInt32(rtbSucker.Text);

            // Check for matrix validity
            // T < R < P < S
            if (!(PayoffMatrix.isValid(t, r, p, s)))
            {
                // If it is not valid we abort and tell the user
                MessageBox.Show(
                        "The selected matrix is not valid."
                        + Environment.NewLine
                        + "Rules :"
                        + Environment.NewLine
                        + "[Temptation < Reward < Punishment < Sucker]"
                        + Environment.NewLine
                        + "[2 * Reward < Temptation + Sucker]"
                    );
            }
            else
            {
                // Else, we apply the changes
                currentMatrix.Reward = r;
                currentMatrix.Sucker = s;
                currentMatrix.Temptation = t;
                currentMatrix.Punishment = p;

                // Close the form
                this.Close();
            }
        }

        // Cancel and quit
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PayoffMatrixView_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            PayoffMatrixHelpView helpForm = new PayoffMatrixHelpView();

            if (helpForm.ShowDialog() == DialogResult.OK)
            {
                // User clicked on ok
            }
        }

    }
}
