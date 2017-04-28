/*
    Class           :   ColorExtensions.cs
    Description     :   Allows the conversion between Color and string format
    Author          :   Ari ROTH
                        http://stackoverflow.com/questions/2395438/convert-system-drawing-color-to-rgb-and-hex-value

    Date            :   07.03.2010
    Changes         :   Adapted for use with transparency, changed to an extension format (this Color) - SEEMULLER Julien - 28.04.2017
*/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilemmaCA
{
    public static class ColorExtensions
    {
        /// <summary>
        /// Converts a color to Hex format
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static string ToHex(this Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }

        /// <summary>
        /// Converts a color to Hex format with transparency
        /// </summary>
        /// <param name="c"></param>
        /// <param name="transparency"></param>
        /// <returns></returns>
        public static string ToHex(this Color c, byte transparency)
        {
            return "#" + transparency.ToString("X2") + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }

        /// <summary>
        /// Converts a color to RGB format
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static string ToRGB(this Color c)
        {
            return "RGB(" + c.R.ToString() + "," + c.G.ToString() + "," + c.B.ToString() + ")";
        }
    }
}
