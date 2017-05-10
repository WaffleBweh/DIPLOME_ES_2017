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

namespace PrisonersDilemmaCA
{
    public class Cell
    {
        #region fields
        #region consts
        public static readonly Strategy DEFAULT_STRATEGY = new StratTitForTat();
        #endregion

        private int _x;                     // X position in the grid (should be multiplied by width if used for graphics)
        private int _y;                     // Y position in the grid (should be multiplied by height if used for graphics)
        private int _width;                 // Width of the cell (dependent on the grid)
        private int _height;                // Height of the cell (dependent on the grid)
        private int _score;                 // Represents the number of days in prison
        private Strategy _strategy;         // The strategy used by the cell (ex : Tit for Tat)
        private Color _color;               // The current color of the cell
        private List<Cell> _neighbors;      // A list of references to the cells neighbors
        private PayoffMatrix _payoffMatrix; // The payoff matrix used by the cell
        private Move _move;                 // What the cell intends to do this turn (ex : Defect)
        private Stack<Move> _history;       // Complete history of the cell's actions (ex : C, C, C, D, C, D, etc...)
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
                // Make sure it is a new instance of the strategy
                _strategy = (Strategy)Activator.CreateInstance(value.GetType());
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

        public Stack<Move> History
        {
            get { return _history; }
            set { _history = value; }
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
            this.History = new Stack<Move>();

            // Get the color of the cell from the current strategy
            this.setColorFromStrategy();

            // Starts with a move relevent to the strategy
            this.chooseNextMove();
        }

        /// <summary>
        /// Default constructor
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

            // We get the best score of the cell
            this.Score = scores.Min();

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
            this.History.Push(this.Move);
        }

        /// <summary>
        /// Function used to draw the cell
        /// </summary>
        /// <param name="g">The graphical element we use to draw</param>
        public void draw(Graphics g)
        {
            SolidBrush brush = new SolidBrush(this.Color);

            // Draw the cell
            g.FillRectangle(brush, this); // Implicitly converted as a rectangle
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

            // If we are the cell that is hit, update our strategy and clear it's history
            if (hitbox.Contains(x, y))
            {
                updateStrategy(strat);
            }
        }

        /// <summary>
        /// Updates the strategy of the cell
        /// </summary>
        /// <param name="strat"></param>
        public void updateStrategy(Strategy strat)
        {
            // Change the strategy
            this.Strategy = strat;

            // Updates the cell's move with the new strategy
            this.History.Clear();

            // Play a game with our neighbors to set our base state
            this.chooseNextMove();
            this.updateLastMove();
            this.step();
        }

        /// <summary>
        /// Set the color of the cell according to its next move
        /// </summary>
        public void setColorFromMove()
        {
            switch (this.Move)
            {
                case Move.Cooperate:
                    if (this.History.First() == Move.Defect)
                    {
                        this.Color = Color.FromArgb(230, 126, 34); // ORANGE
                    }
                    else
                    {
                        this.Color = Color.FromArgb(46, 204, 113); // GREEN
                    }
                    break;


                case Move.Defect:
                    if (this.History.First() == Move.Cooperate)
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
