/*
    Class           :   Cell.cs
    Description     :   Main class, represents one "player" of the prisoner's dilemma
    Author          :   SEEMULLER Julien
    Date            :   10.04.2017
*/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrisonersDilemmaCA
{
    public class Cell
    {
        #region fields

        #region consts & enums
        private static readonly IStrategy DEFAULT_STRATEGY = new TitForTat();
        public enum Move { None, Cooperate, Defect }
        #endregion

        private int _x;
        private int _y;
        private double _width;
        private double _height;
        private int _score;
        private IStrategy _strategy;
        private Color _color;
        private List<Cell> _neighbors;
        private Move nextMove;
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

        public double Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public double Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }

        internal IStrategy Strategy
        {
            get { return _strategy; }
            set { _strategy = value; }
        }

        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public List<Cell> Neighbors
        {
            get { return _neighbors; }
            set { _neighbors = value; }
        }

        private Move NextMove
        {
            get { return nextMove; }
            set { nextMove = value; }
        }
        #endregion

        #region constructors
        /// <summary>
        /// Designated constructor
        /// </summary>
        /// <param name="x">X coordinate of the cell on the grid</param>
        /// <param name="y">Y coordinate of the cell on the grid</param>
        /// <param name="strategy">Current strategy of the cell</param>
        public Cell(int x, int y, IStrategy strategy)
        {
            this.X = x;
            this.Y = y;
            this.Strategy = strategy;
            // Get the color of the cell from the current strategy
            this.Color = this.Strategy.getColor();
            // Starts with no moves
            this.NextMove = Move.None;
        }

        /// <summary>
        /// Default constructor
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Cell(int x, int y) : this(x, y, DEFAULT_STRATEGY)
        {
            // No code
        }
        #endregion

        #region methods

        /// <summary>
        /// Function used to draw the cell
        /// </summary>
        /// <param name="g">The graphical element we use to draw</param>
        public void draw(Graphics g)
        {
            SolidBrush brush = new SolidBrush(this.Color);

            // Calculate the positions
            int roundedHeight = Convert.ToInt32(this.Height);
            int roundedWidth = Convert.ToInt32(this.Width);
            int realXPos = this.X * roundedWidth;
            int realYPos = this.Y * roundedHeight;

            // Draw the cell
            g.FillRectangle(brush, realXPos, realYPos, roundedWidth, roundedHeight);
        }
        #endregion
    }
}
