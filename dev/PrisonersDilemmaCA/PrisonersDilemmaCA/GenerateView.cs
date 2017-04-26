using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrisonersDilemmaCA
{
    public partial class GenerateView : Form
    {
        public Grid currentGrid { get; set; }
        public List<Strategy> strategies { get; set; }

        int nbOfStrategies;
        int heightOfComponents = 40;
        int widthOfComponents = 150;
        int spacing;
        int formHeight;
        int formWidth;
        List<TrackBar> trackbars;
        List<Label> trackbarLabels;
        List<int> lastTrackbarValues;

        public GenerateView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Generates the GUI dynamially on load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateView_Load(object sender, EventArgs e)
        {
            // Store the number of available strategies we have
            nbOfStrategies = strategies.Count;

            // Define some values to create our view dynamically 
            spacing = heightOfComponents;
            formHeight = 0;
            formWidth = 0;

            // Initialize our list of trackbars
            trackbars = new List<TrackBar>();
            trackbarLabels = new List<Label>();
            lastTrackbarValues = new List<int>();

            // Generate the interface dynamically
            for (int i = 1; i <= nbOfStrategies; i++)
            {
                Label tmpLabel = new Label();
                int x = spacing;
                int y = i * (heightOfComponents / 3 + spacing);

                // Set the location of the label
                tmpLabel.Location = new Point(x, y);
                tmpLabel.Width = widthOfComponents;
                tmpLabel.Height = heightOfComponents;

                // Set the label font
                tmpLabel.Font = new Font(FontFamily.GenericSansSerif, 12);

                // Add the label content
                string strategyName = strategies[i - 1].ToString();
                tmpLabel.Text = strategyName;

                // Create a trackbar
                TrackBar tmpTrackbar = new TrackBar();
                tmpTrackbar.Location = new Point(x + tmpLabel.Width + spacing, y);
                tmpTrackbar.Size = new Size(lblTitle.Width / 2 - x / 2, heightOfComponents);
                tmpTrackbar.Anchor = (AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left);

                // Set the trackbar's parameters
                tmpTrackbar.Minimum = 0;
                tmpTrackbar.Maximum = 100;
                tmpTrackbar.Value = 0;
                tmpTrackbar.TickFrequency = 10;

                // Add an event handler to automatically refresh the interface
                tmpTrackbar.ValueChanged += new EventHandler(UpdateValues);

                // Add the trackbar to the list
                trackbars.Add(tmpTrackbar);
                lastTrackbarValues.Add(tmpTrackbar.Value);

                // Add a label for each trackbar
                Label tmpTrackbarLabel = new Label();

                // Set the location of the label (next to the trackbar)
                tmpTrackbarLabel.Location = new Point(tmpTrackbar.Left + tmpTrackbar.Width + spacing, y);
                tmpTrackbarLabel.Width = widthOfComponents;
                tmpTrackbarLabel.Height = heightOfComponents;

                // Anchor it
                tmpTrackbarLabel.Anchor = (AnchorStyles.Right | AnchorStyles.Top);

                // Set the label font
                tmpTrackbarLabel.Font = new Font(FontFamily.GenericSansSerif, 12);

                // Add it to the list
                trackbarLabels.Add(tmpTrackbarLabel);

                // Add the components to the form
                this.Controls.Add(tmpLabel);
                this.Controls.Add(tmpTrackbar);
                this.Controls.Add(tmpTrackbarLabel);

                // Set the form width and height
                formHeight += heightOfComponents + spacing;
            }
            formWidth = lblTitle.Width + spacing * 3;

            // Set the form's dimensions
            this.MinimumSize = new Size(formWidth, formHeight);

            // Refresh the progressbar
            UpdateValues(null, null);
        }

        /// <summary>
        /// Refreshes the interface and prevents the user from inputing incorrect values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void UpdateValues(object sender, EventArgs e)
        {
            // Get the current total percentage
            int sum = trackbars.Sum(item => item.Value);

            // Set the new max value of the trackbars
            for (int i = 0; i < trackbars.Count; i++)
            {
                // If we are at 100 percent, prevent the user from incrementing even more
                if (sum > 100)
                {
                    if (trackbars[i].Value > lastTrackbarValues[i])
                    {
                        // Restore from the last value
                        trackbars[i].Value = lastTrackbarValues[i];
                    }
                }
                // Store the last value
                lastTrackbarValues[i] = trackbars[i].Value;

                // Refresh the percentage of each of the trackbar's label
                trackbarLabels[i].Text = String.Format("{0}%", trackbars[i].Value);
            }

            // The percentage is equal to the sum of each of the trackbar's value
            sum = (sum > 100) ? 100 : sum;
            pbPercentage.Value = sum;
            lblPercentage.Text = String.Format("{0}%", sum);

            // Enable the button if we have 100% progress
            btnApply.Enabled = (sum >= 100) ? true : false;
        }

        /// <summary>
        /// Closes the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Generates a new board with random cells
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnApply_Click(object sender, EventArgs e)
        {
            // Create a new random number generator
            Random rng = new Random();

            Dictionary<Strategy, int> stratAndPercent = new Dictionary<Strategy, int>();
            List<Strategy> toRemove = new List<Strategy>();

            // Filter out the unused strategies
            for (int i = 0; i < nbOfStrategies; i++)
            {
                if (!(trackbars[i].Value <= 0))
                {
                    // Store the percentage of the remaining strategies
                    stratAndPercent.Add(strategies[i], trackbars[i].Value);
                }
            }

            Grid tmpGrid = new Grid(currentGrid.Width, currentGrid.Height, currentGrid.NbLines, currentGrid.NbCols, currentGrid.PayoffMatrix);

            // Generate a new board
            tmpGrid.generate(stratAndPercent);

            currentGrid.Cells = tmpGrid.Cells;

            // Close the form
            this.Close();
        }
    }
}
