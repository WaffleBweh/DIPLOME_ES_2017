/*
    Class           :   ComboBoxExtensions.cs
    Description     :   Allows the use of colors inside combo boxes
    Author          :   STEPHENS Rod
                        http://csharphelper.com/blog/2016/03/make-a-combobox-display-colors-or-images-in-c/

    Date            :   29.03.2016
    Changes         :   Adapted for use with strategies - SEEMULLER Julien - 24.04.2017
*/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrisonersDilemmaCA
{
    public static class ComboBoxExtensions
    {
        // Margins around owner drawn ComboBoxes.
        private const int MarginWidth = 6;
        private const int MarginHeight = 2;

        /// <summary>
        /// Draw a ComboBox item that is displaying a strategy and its color
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            // Clear the background appropriately.
            e.DrawBackground();

            // Draw the color sample.
            int height = e.Bounds.Height - 2 * MarginHeight;
            Rectangle rectangle = new Rectangle(e.Bounds.X + MarginWidth, e.Bounds.Y + MarginHeight, height, height);
            ComboBox comboBox = sender as ComboBox;
            Color color = (comboBox.Items[e.Index] as Strategy).getColor();

            using (SolidBrush brush = new SolidBrush(color))
            {
                e.Graphics.FillRectangle(brush, rectangle);
            }

            // Outline the sample in black.
            e.Graphics.DrawRectangle(Pens.Black, rectangle);

            // Draw the color's name to the right.
            using (Font font = new Font(comboBox.Font.FontFamily, comboBox.Font.Size * 0.95f, FontStyle.Regular))
            {
                using (StringFormat sf = new StringFormat())
                {
                    sf.Alignment = StringAlignment.Near;
                    sf.LineAlignment = StringAlignment.Center;
                    int x = height + 2 * MarginWidth;
                    int y = e.Bounds.Y + e.Bounds.Height / 2;
                    e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                    e.Graphics.DrawString(comboBox.Items[e.Index].ToString(), font, Brushes.Black, x, y, sf);
                }
            }

            // Draw the focus rectangle if appropriate.
            e.DrawFocusRectangle();
        }


        /// <summary>
        /// Add a list of strategy to a combobox
        /// </summary>
        /// <param name="comboBox"></param>
        /// <param name="strats"></param>
        public static void AddStrategies(this ComboBox comboBox, List<Strategy> strats)
        {
            // Make the ComboBox owner-drawn.
            comboBox.DrawMode = DrawMode.OwnerDrawFixed;

            // Add the strategies to the ComboBox's items.
            foreach (Strategy strat in strats)
            {
                comboBox.Items.Add(strat);
            }

            // Subscribe to the DrawItem event.
            comboBox.DrawItem += DrawItem;
        }
    }
}
