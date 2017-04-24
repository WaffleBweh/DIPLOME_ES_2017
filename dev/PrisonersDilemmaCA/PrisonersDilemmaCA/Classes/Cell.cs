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
        #region consts
        public static readonly Strategy DEFAULT_STRATEGY = new StratTitForTat();
        #endregion

        private int _x;
        private int _y;
        private int _width;
        private int _height;
        private int _score;
        private Strategy _strategy;
        private Color _color;
        private List<Cell> _neighbors;
        private PayoffMatrix _payoffMatrix;
        private Move _move;
        private Move _lastMove;
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

        public Strategy Strategy
        {
            get { return _strategy; }
            set
            {
                _strategy = value;
                // Set the color when we change the strategy
                this.Color = this.Strategy.getColor();
            }
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

        private Move Move
        {
            get { return _move; }
            set { _move = value; }
        }

        public Move LastMove
        {
            get { return _lastMove; }
            set { _lastMove = value; }
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
        public Cell(int x, int y, Strategy strategy, PayoffMatrix matrix)
        {
            this.X = x;
            this.Y = y;
            this.Strategy = strategy;
            this.PayoffMatrix = matrix;
            this.Score = 0;

            this.Neighbors = new List<Cell>();

            // Get the color of the cell from the current strategy
            this.setColorFromStrategy();
            // Starts with no moves
            this.Move = Move.None;
            this.LastMove = this.Move;
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
        /// Plays a game of the prisoners dilemma with the cell's neighbors using the cell's current strategy
        /// </summary>
        public void step()
        {
            // Go and play with each of our neighbors
            List<int> scores = new List<int>();
            foreach (Cell neighbor in this.Neighbors)
            {
                // Play a game and store the result
                scores.Add(PayoffMatrix.returnPayoff(this.Move, neighbor.Move));
            }

            // We get the average score of the cell
            this.Score = (int)Math.Floor(scores.Average());

            // Update the color of the cell
            this.setColorFromMove();
        }

        /// <summary>
        /// Choose the next move using our strategy and neighbors
        /// </summary>
        public void chooseNextMove()
        {
            this.Move = this.Strategy.chooseMove(this, this.Neighbors);
        }

        /// <summary>
        /// Updates the last move of the cell
        /// </summary>
        public void updateLastMove()
        {
            this.LastMove = this.Move;
        }

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
        /// Implicit conversion to rectangle to use its contains function easily
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        public static implicit operator Rectangle(Cell cell)
        {
            return new Rectangle(cell.X * cell.Width, cell.Y * cell.Height, cell.Width, cell.Height);
        }

        /// <summary>
        /// On click, we update the cell's strategy with a new one
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void onClick(int x, int y, Strategy strat)
        {
            Rectangle hitbox = this;

            // If we are the cell that is hit, update our strategy
            if (hitbox.Contains(x, y))
            {
                this.Strategy = strat;
            }
        }

        /// <summary>
        /// Set the color of the cell according to its next move
        /// </summary>
        public void setColorFromMove()
        {
            switch (this.Move)
            {
                case Move.Cooperate:
                    if (this.LastMove == Move.Defect)
                    {
                        this.Color = Color.FromArgb(211, 84, 0); // ORANGE
                    }
                    else
                    {
                        this.Color = Color.FromArgb(46, 204, 113); // GREEN
                    }
                    break;


                case Move.Defect:
                    if (this.LastMove == Move.Cooperate)
                    {
                        this.Color = Color.FromArgb(241, 196, 15); // YELLOW
                    }
                    else
                    {
                        this.Color = Color.FromArgb(192, 57, 43); // RED
                    }

                    break;
            }
        }

        /// <summary>
        /// Set the color of the cell according to its strategy
        /// </summary>
        public void setColorFromStrategy()
        {
            this.Color = this.Strategy.getColor();
        }
        #endregion
    }
}
