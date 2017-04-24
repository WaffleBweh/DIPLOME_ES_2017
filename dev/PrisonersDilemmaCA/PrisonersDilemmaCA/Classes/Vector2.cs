/*
    Class           :   Vector2.cs
    Description     :   Alternative to the .NET graphics "point" class. 
                        Compatible with unit testing.
    Author          :   SEEMULLER Julien
    Date            :   10.04.2017
*/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilemmaCA
{
    public class Vector2
    {
        #region fields
        private int _x;
        private int _y;
        #endregion

        #region properties
        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }
        #endregion

        #region constructor
        /// <summary>
        /// Designated constructor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Vector2(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Point conveniance constructor
        /// </summary>
        /// <param name="point"></param>
        public Vector2(Point point) : this(point.X, point.Y)
        {
            // No code
        }
        #endregion

        #region methods
        /// <summary>
        /// Implicit conversion to a Point object
        /// </summary>
        /// <returns></returns>
        public static implicit operator Point(Vector2 vec2)
        {
            return new Point(vec2.X, vec2.Y);
        }
        #endregion
    }
}
