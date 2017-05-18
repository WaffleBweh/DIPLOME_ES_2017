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
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace PrisonersDilemmaCA
{
    public class Cell : IXmlSerializable
    {
        #region fields
        #region consts
        public static readonly Strategy DEFAULT_STRATEGY = new StratTitForTat();
        private const int DEFAULT_X = 0;
        private const int DEFAULT_Y = 0;
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
        private Move _choice;                 // What the cell intends to do this turn (ex : Defect)
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

        private Move Choice
        {
            get { return _choice; }
            set { _choice = value; }
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
        /// Conveniance constructor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Cell(int x, int y, PayoffMatrix matrix)
            : this(x, y, DEFAULT_STRATEGY, matrix)
        {
            // No code
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Cell()
            : this(DEFAULT_X, DEFAULT_Y, new PayoffMatrix())
        {

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
                scores.Add(PayoffMatrix.returnPayoff(this.Choice, neighbor.Choice));
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
            this.Choice = this.Strategy.chooseMove(this, this.Neighbors);
        }

        /// <summary>
        /// Updates the last move of the cell
        /// </summary>
        public void updateLastMove()
        {
            this.History.Push(this.Choice);
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
        /// Implicit conversion to rectangle to simplify other functions
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

            // We play a game with our neighbors to sync with the current game
            this.chooseNextMove();
            this.updateLastMove();
            this.step();
        }

        /// <summary>
        /// Set the color of the cell according to its next move
        /// </summary>
        public void setColorFromMove()
        {
            switch (this.Choice)
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





        //****************************//
        // INTERFACE IXMLSERIALIZABLE //
        //****************************//

        /// <summary>
        /// Unused, see MSDN documentation :
        /// "This method is reserved and should not be used. It should always return a null value"
        /// </summary>
        /// <returns></returns>
        public XmlSchema GetSchema()
        {
            return null;
        }


        /// <summary>
        /// Reads through a serialized XML file to get the values for a cell
        /// </summary>
        /// <param name="reader"></param>
        public void ReadXml(XmlReader reader)
        {

            int R = -1;
            int G = -1;
            int B = -1;

            reader.Read(); // Skip the beggining tab
            if (reader.Name == "X")
            {
                reader.Read(); // Read past the name tag
                this.X = int.Parse(reader.Value);
                reader.Read(); // Read past the value 

            }
            reader.Read(); // Read past the closing tag

            // repeat this process for every value...

            if (reader.Name == "Y")
            {
                reader.Read();
                this.Y = int.Parse(reader.Value);
                reader.Read();
            }
            reader.Read();

            if (reader.Name == "Width")
            {
                reader.Read();
                this.Width = int.Parse(reader.Value);
                reader.Read();
            }
            reader.Read();

            if (reader.Name == "Height")
            {
                reader.Read();
                this.Height = int.Parse(reader.Value);
                reader.Read();
            }
            reader.Read();

            if (reader.Name == "Strategy")
            {
                reader.Read();
                // Create a new instance of the strategy
                Type elementType = Type.GetType(reader.Value);
                this.Strategy = (Strategy)Activator.CreateInstance(elementType);
                reader.Read();
            }
            reader.Read();


            if (reader.Name == "R")
            {
                reader.Read();
                R = int.Parse(reader.Value);
                reader.Read();
            }
            reader.Read();

            if (reader.Name == "G")
            {
                reader.Read();
                G = int.Parse(reader.Value);
                reader.Read();
            }
            reader.Read();

            if (reader.Name == "B")
            {
                reader.Read();
                B = int.Parse(reader.Value);
                reader.Read();
            }
            reader.Read();

            // Check if the RGB values are assigned
            if (R > 0 && G > 0 && B > 0)
            {
                // Create a color
                this.Color = Color.FromArgb(R, G, B);

                // Reset the color
                R = -1;
                G = -1;
                B = -1;
            }

            if (reader.Name == "Score")
            {
                reader.Read();
                // Tries to parse the reader value as a "Move" enum
                this.Score = int.Parse(reader.Value);
                reader.Read();
            }
            reader.Read();
            reader.Read(); // Skip ending tag
        }


        /// <summary>
        /// Write the cell's value to a serialized XML file
        /// </summary>
        /// <param name="writer"></param>
        public void WriteXml(XmlWriter writer)
        {
            // Set color from strategy before continuing
            setColorFromStrategy();

            // Write the content of the cell to xml format
            writer.WriteStartElement("X");
            writer.WriteString(this.X.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("Y");
            writer.WriteString(this.Y.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("Width");
            writer.WriteString(this.Width.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("Height");
            writer.WriteString(this.Height.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("Strategy");
            writer.WriteString(this.Strategy.GetType().ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("R");
            writer.WriteString(this.Color.R.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("G");
            writer.WriteString(this.Color.G.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("B");
            writer.WriteString(this.Color.B.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("Score");
            writer.WriteString(this.Score.ToString());
            writer.WriteEndElement();

            /* HISTORY - UNUSED, INCREASED SIZE OF FILE EXPONENTIALLY WITH EACH GENERATION
            writer.WriteStartElement("History");
            foreach (Move choice in this.History)
            {
                writer.WriteStartElement("Choice");
                writer.WriteString(choice.ToString());
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            */
        }
        #endregion
    }
}