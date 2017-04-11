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
        PayoffMatrix matrixRef;

        public PayoffMatrixView(PayoffMatrix matrix)
        {
            InitializeComponent();
            // Get our matrix as reference
            matrixRef = matrix;

            // Initialize our textboxes with the matrix data
            rtbReward.Text = matrix.Reward.ToString();
            rtbSucker.Text = matrix.Sucker.ToString();
            rtbTemptation.Text = matrix.Temptation.ToString();
            rtbPunishment.Text = matrix.Punishment.ToString();

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
            // T > R > P > S
            if (!(PayoffMatrix.isValid(t, r, p, s)))
            {
                // If it is not valid we abort and tell the user
                MessageBox.Show(
                        "The selected matrix is not valid."
                        + Environment.NewLine
                        + "Rule : T > R > P > S"
                    );
            }
            else
            {
                // Else, we apply the changes
                matrixRef.Reward = r;
                matrixRef.Sucker = s;
                matrixRef.Temptation = t;
                matrixRef.Punishment = p;

                // Close the form
                this.Close();
            }
        }

        // Cancel and quit
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
