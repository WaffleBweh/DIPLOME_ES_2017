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
        private static readonly IStrategy DEFAULT_STRATEGY = new StratTitForTat();

        #endregion

        private int _x;
        private int _y;
        private int _width;
        private int _height;
        private int _score;
        private IStrategy _strategy;
        private Color _color;
        private List<Cell> _neighbors;
        private PayoffMatrix _payoffMatrix;
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

        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }

        public IStrategy Strategy
        {
            get { return _strategy; }
            set { _strategy = value; }
        }

        public PayoffMatrix PayoffMatrix
        {
            get { return _payoffMatrix; }
            set { _payoffMatrix = value; }
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
        /// <param name="matrix">Payoff matrix used to determine the score of each cell</param>
        public Cell(int x, int y, IStrategy strategy, PayoffMatrix matrix)
        {
            this.X = x;
            this.Y = y;
            this.Strategy = strategy;
            this.PayoffMatrix = matrix;
            this.Score = 0;

            this.Neighbors = new List<Cell>();

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
        public Cell(int x, int y, PayoffMatrix matrix)
            : this(x, y, DEFAULT_STRATEGY, matrix)
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
            int realXPos = this.X * this.Width;
            int realYPos = this.Y * this.Height;

            // Draw the cell
            g.FillRectangle(brush, realXPos, realYPos, this.Width, this.Height);
        }

        /// <summary>
        /// Plays a game of the prisoners dilemma with the cell's neighbors using the cell's current strategy
        /// </summary>
        public void step()
        {
            // Choose the next move using our strategy
            this.nextMove = this.Strategy.chooseMove(this, this.Neighbors);

            // Go and play with each of our neighbors
            List<int> scores = new List<int>();
            foreach (Cell neighbor in this.Neighbors)
            {
                // Play a game and store the result
                scores.Add(PayoffMatrix.returnPayoff(this.nextMove, neighbor.nextMove));
            }

            // We get the average score of the cell
            this.Score = (int)Math.Floor(scores.Average());
        }
        #endregion
    }
}
