using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrisonersDilemmaCA
{
    public partial class AboutView : Form
    {
        public AboutView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Close the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Open the wiki page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(lblWikiLink.Text);
        }

        /// <summary>
        /// Open the github page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblGithubLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(lblGithubLink.Text);
        }
    }
}
