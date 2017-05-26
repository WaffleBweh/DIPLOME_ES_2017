/*
    Class           :   Grid.cs
    Description     :   Stores the cells of the cellular automaton, 
                        main model of the cellular automaton
    Author          :   SEEMULLER Julien
    Date            :   10.04.2017
*/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PrisonersDilemmaCA
{
    public class Grid
    {
        #region fields

        #region consts
        public const int NEAREST_NEIGHBOR_RANGE = 1;    // Change the "radius" at which we consider cells neighbors
        private const int DEFAULT_HEIGHT = 100;
        private const int DEFAULT_WIDTH = 100;
        private const int DEFAULT_NB_COLS = 10;
        private const int DEFAULT_NB_LINES = 10;
        private const string DEFAULT_DATA_FILEPATH = "xml/grid.xml";

        public const WrapMode DEFAULT_WRAP_MODE = WrapMode.Torus;
        #endregion

        private Cell[,] _cells;                         // 2D array containing the cells
        private int _width;                             // Width of the grid in pixels
        private int _height;                            // Height of the grid in pixels
        private int _nbLines;                           // Number of lines in the grid (y)
        private int _nbCols;                            // Number of columns in the grid (x)
        private PayoffMatrix _payoffMatrix;             // Payoff matrix to be distributed to cells
        private ColorMode _colorMode;                   // The current color mode of the grid (cf. ColorMode enum)
        private WrapMode _wrapMode;                     // The current wrapping mode of the grid (cf. WrapMode enum)
        private List<Cell> _serializableCells;          // Since [,] is not serializable, we make a list of cell before serializing.
        #endregion

        #region properties
        [XmlIgnore]
        public Cell[,] Cells
        {
            get { return _cells; }
            set { _cells = value; }
        }

        public List<Cell> SerializableCells
        {
            get { return _serializableCells; }
            set { _serializableCells = value; }
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

        public int NbCols
        {
            get { return _nbCols; }
            set { _nbCols = value; }
        }

        public int NbLines
        {
            get { return _nbLines; }
            set { _nbLines = value; }
        }

        public PayoffMatrix PayoffMatrix
        {
            get { return _payoffMatrix; }
            set { _payoffMatrix = value; }
        }

        public ColorMode ColorMode
        {
            get { return _colorMode; }
            set { _colorMode = value; }
        }

        public WrapMode WrapMode
        {
            get { return _wrapMode; }
            set { _wrapMode = value; }
        }
        #endregion

        #region constructors
        /// <summary>
        /// Designated constructor
        /// </summary>
        /// <param name="width">The width of the grid in pixels</param>
        /// <param name="height">The height of the grid in pixels</param>
        /// <param name="nbCols">The number of columns of the grid</param>
        /// <param name="nbLines">The number of lines of the grid</param>
        public Grid(int width, int height, int nbLines, int nbCols, PayoffMatrix matrix, WrapMode wrapmode, Strategy strategy)
        {
            this.Width = width;
            this.Height = height;
            this.NbLines = nbLines;
            this.NbCols = nbCols;
            this.PayoffMatrix = matrix;
            this.ColorMode = ColorMode.Strategy;
            this.WrapMode = wrapmode;

            // Initialize our list of cells
            this.Cells = new Cell[nbLines, nbCols];

            // Calculate the width and the height of a cell
            int cellWidth = this.Width / nbCols;
            int cellHeight = this.Height / nbLines;

            // Go through each possible slot in the grid
            for (int y = 0; y < this.NbLines; y++)
            {
                for (int x = 0; x < this.NbCols; x++)
                {
                    // Create a temporary cell with the default strategy
                    Cell tmpCell = new Cell(x, y, strategy, this.PayoffMatrix);

                    // Set the cell's height according to the grid's need
                    tmpCell.Width = cellWidth;
                    tmpCell.Height = cellHeight;

                    // Add the cell to the list
                    this.Cells[y, x] = tmpCell;
                }
            }

            foreach (Cell cell in this.Cells)
            {
                // Make each cell aware of its neighbors
                cell.Neighbors = findCellNeighbors(cell);
            }
        }

        /// <summary>
        /// Conveniance constructor
        /// </summary>
        public Grid(int width, int height, int nbLines, int nbCols, PayoffMatrix matrix, WrapMode wrapmode)
            : this(width, height, nbLines, nbCols, matrix, wrapmode, Cell.DEFAULT_STRATEGY)
        {
            // No code
        }

        /// <summary>
        /// Conveniance constructor 2
        /// </summary>
        public Grid(int width, int height, int nbLines, int nbCols, PayoffMatrix matrix)
            : this(width, height, nbLines, nbCols, matrix, DEFAULT_WRAP_MODE, Cell.DEFAULT_STRATEGY)
        {
            // No code
        }

        /// <summary>
        /// Conveniance constructor 3
        /// </summary>
        public Grid(int width, int height, int nbLines, int nbCols)
            : this(width, height, nbLines, nbCols, new PayoffMatrix(), DEFAULT_WRAP_MODE, Cell.DEFAULT_STRATEGY)
        {
            // No code
        }

        /// <summary>
        /// Default constructor
        /// (Required for serialization)
        /// </summary>
        public Grid()
            : this(DEFAULT_WIDTH, DEFAULT_HEIGHT, DEFAULT_NB_LINES, DEFAULT_NB_COLS, new PayoffMatrix())
        {
            // No code
        }
        #endregion

        #region methods

        /// <summary>
        /// Steps forward in time
        /// </summary>
        public void step()
        {
            // Store each of the cell's last move
            foreach (Cell cell in this.Cells)
            {
                cell.updateLastMove();
            }

            // Choose each of the cell's next move
            foreach (Cell cell in this.Cells)
            {
                cell.chooseNextMove();
            }

            // Step forward (play the game)
            foreach (Cell cell in this.Cells)
            {
                cell.step();
            }
        }

        /// <summary>
        /// Draw every cell on the board and the grid around them
        /// </summary>
        /// <param name="g">The graphics element we draw on</param>
        public void draw(Graphics g)
        {
            // Draw each cell
            foreach (Cell cell in this.Cells)
            {
                cell.draw(g);
            }

            // Avoid drawing errors due to rounding
            Pen borderColor = new Pen(Color.Black, Cell.DEFAULT_BORDER_WIDTH * 2);
            g.DrawLine(borderColor, 0, this.Height, this.Width, this.Height);
            g.DrawLine(borderColor, this.Width, 0, this.Width, this.Height);
        }

        /// <summary>
        /// Generates a board of cell from a dictionary of strategy and percentages
        /// </summary>
        /// <param name="strategyAndPercentages">Dictionary countaining the strategies and their percentage of appearence</param>
        public void generate(Dictionary<Strategy, int> strategyAndPercentages)
        {
            // Create a new random number generator
            Random rng = new Random();

            // Create a list of a hundred elements representing the repartition of strategies
            List<Strategy> strategyPopulation = new List<Strategy>();

            // Go through each possible strategy and percentage
            foreach (var strat in strategyAndPercentages)
            {
                // Fill the list with the current strategy the same number of times as the percentage
                for (int i = 0; i < strat.Value; i++)
                {
                    strategyPopulation.Add(strat.Key);
                }
            }

            // Go through each cell in the grid
            foreach (Cell cell in this.Cells)
            {
                // Choose a random strategy in the list and apply it to the current cell
                int rnd = rng.Next(strategyPopulation.Count);
                cell.updateStrategy(strategyPopulation[rnd]);
            }
        }

        /// <summary>
        /// Generates a board of cell from a list of strategy and percentages
        /// </summary>
        /// <param name="strats">List of strategies</param>
        /// <param name="percentages">List of percentages</param>
        public void generate(List<Strategy> strats, List<int> percentages)
        {
            // Fill a dictionary with strategies and percentages
            Dictionary<Strategy, int> stratAndPercentage = new Dictionary<Strategy, int>();

            int counter = 0;
            foreach (var strategy in strats)
            {
                stratAndPercentage.Add(strategy, percentages[counter]);
            }

            // Generate the board
            this.generate(stratAndPercentage);
        }

        /// <summary>
        /// Gets the cell at the given position in a toroidal fashion
        /// </summary>
        /// <param name="x">The x coordinate of the cell (on the board)</param>
        /// <param name="y">The y coordinate of the cell (on the board)</param>
        /// <returns></returns>
        public Cell getCell(int x, int y)
        {
            // Find the corrisponding point in a toroidal fashion if we go out of bounds
            Point point = getPointClampedInGrid(x, y);
            int newX = point.X;
            int newY = point.Y;

            // Return the correct cell
            return this.Cells[newY, newX];
        }

        /// <summary>
        /// Gets a point and wraps around in a toroidal fashion if the point is out of bounds.
        /// The coordinates are in grid format (see nbLines, nbCols)
        /// </summary>
        /// <param name="x">The x coordinate of a point on the grid</param>
        /// <param name="y">The y coordinate of a point on the grid</param>
        /// <returns></returns>
        public Point getPointClampedInGrid(int x, int y)
        {
            int newX = x;
            int newY = y;

            // Check if we are out of bounds width-wise
            if (newX >= this.NbCols)
            {
                // ex : 20 -> 20 - width
                newX = newX - Convert.ToInt32(this.NbCols);
            }

            if (newX < 0)
            {
                // ex : -2 -> width - 2
                newX = Convert.ToInt32(this.NbCols) + newX;
            }

            // Check if we are out of bounds height-wise
            if (newY >= this.NbLines)
            {
                // ex : 20 -> 20 - height
                newY = newY - Convert.ToInt32(this.NbLines);
            }

            if (newY < 0)
            {
                // ex : -2 -> height - 2
                newY = Convert.ToInt32(this.NbLines) + newY;
            }

            return new Point(newX, newY);
        }


        /// <summary>
        /// Find the current cell's nearest neighbors (default 8 per cell)
        /// </summary>
        /// <param name="cell">The cell used to search for neighbors</param>
        /// <returns></returns>
        public List<Cell> findCellNeighbors(Cell cell)
        {
            List<Cell> neighbors = new List<Cell>();

            // Go all around the cell to find its neighbors
            for (int y = cell.Y - NEAREST_NEIGHBOR_RANGE; y <= cell.Y + NEAREST_NEIGHBOR_RANGE; y++)
            {
                for (int x = cell.X - NEAREST_NEIGHBOR_RANGE; x <= cell.X + NEAREST_NEIGHBOR_RANGE; x++)
                {
                    // Avoid our own cell
                    if (!((x == cell.X) && (y == cell.Y)))
                    {
                        // Add the neighbor depending on the mode
                        switch (this.WrapMode)
                        {
                            case WrapMode.Default:
                                // In default mode, check if we are inside the grid
                                if ((x >= 0) && (y >= 0) && (x < this.NbCols) && (y < this.NbLines))
                                {
                                    neighbors.Add(this.getCell(x, y));
                                }
                                break;

                            case WrapMode.Torus:
                                neighbors.Add(this.getCell(x, y));
                                break;
                        }

                    }
                }
            }

            return neighbors;
        }


        /// <summary>
        /// Update the strategy of the cell that has been hit by the cursor
        /// </summary>
        /// <param name="x">The x coordinate in pixels</param>
        /// <param name="y">The y coordinate in pixels</param>
        /// <param name="strat">The strategy to apply to the cell if it is hit</param>
        public void onClick(int x, int y, Strategy strat)
        {
            foreach (Cell cell in this.Cells)
            {
                cell.onClick(x, y, strat);
            }
        }

        /// <summary>
        /// Set the color depending on the mode
        /// 
        /// When in strategy color mode  :  The color of the strategy is shown.
        /// When in move color mode      :  The color of the last move is shown.
        /// 
        /// </summary>
        /// <param name="mode">The color mode to use</param>
        public void setColorMode(ColorMode mode)
        {
            // Switch according to the mode
            switch (mode)
            {
                case ColorMode.Strategy:
                    this.setColorFromStrategy();
                    break;
                case ColorMode.Playing:
                    this.setColorFromMove();
                    break;
            }

            this.ColorMode = mode;
        }

        /// <summary>
        /// Sets the cell's colors from thier strategy
        /// </summary>
        private void setColorFromStrategy()
        {
            foreach (Cell cell in this.Cells)
            {
                cell.setColorFromStrategy();
            }
        }

        /// <summary>
        /// Sets the cell's colors from thier last move
        /// </summary>
        private void setColorFromMove()
        {
            foreach (Cell cell in this.Cells)
            {
                cell.setColorFromMove();
            }
        }


        /// <summary>
        /// Finds the number of times the given strategy appears on the board
        /// </summary>
        /// <param name="strategy">The strategy to look for</param>
        /// <returns></returns>
        public int findCountOfStrategy(Strategy strategy)
        {
            int count = 0;

            foreach (Cell cell in this.Cells)
            {
                // Find every cell that has the same type as the current strategy
                if (strategy.GetType() == cell.Strategy.GetType())
                {
                    count++;
                }
            }

            // Return the result rounded down to two decimal places
            return count;
        }

        /// <summary>
        /// Returns the average score of a strategy on the board
        /// </summary>
        /// <param name="strategy">The strategy to look for</param>
        /// <returns></returns>
        public double findAvgScoreOfStrategy(Strategy strategy)
        {
            double count = 0;
            int i = 0;

            foreach (Cell cell in this.Cells)
            {
                // Find every cell that has the same type as the current strategy
                if (strategy.GetType() == cell.Strategy.GetType())
                {
                    // Increment the total score and the count
                    count += cell.Score;
                    i++;
                }
            }

            // Find the percentage from the count
            count = (count / i);

            // Return the result rounded down to two decimal places
            return Math.Round(count, 2);
        }


        /// <summary>
        /// Serializes and saves grid data to a path
        /// </summary>
        /// <param name="path">Where to save the file on the user's disk</param>
        public void saveData(string path)
        {
            this.SerializableCells = this.Cells.asList();
            FileStream fs = new FileStream(path, FileMode.Create);
            XmlSerializer xs = new XmlSerializer(typeof(Grid));
            xs.Serialize(fs, this);
            fs.Close();
        }


        /// <summary>
        /// Serialize and saves grid data to the default location
        /// </summary>
        public void saveData()
        {
            this.saveData(DEFAULT_DATA_FILEPATH);
        }


        /// <summary>
        /// Load serialized data from a path
        /// </summary>
        /// <param name="path">Where to load the file on the user's disk</param>
        public void loadData(string path)
        {
            Grid newGrid;

            XmlSerializer xs = new XmlSerializer(typeof(Grid));
            using (StreamReader rd = new StreamReader(path))
            {
                newGrid = xs.Deserialize(rd) as Grid;
            }

            // rebuild the neighbors
            newGrid.Cells = newGrid.SerializableCells.asArrayOfArray(newGrid.NbLines, newGrid.NbCols);
            foreach (var cell in newGrid.Cells)
            {
                cell.Neighbors = newGrid.findCellNeighbors(cell);
            }

            // Set each of the values from the serialized data
            this.Width = newGrid.Width;
            this.Height = newGrid.Height;
            this.NbCols = newGrid.NbCols;
            this.NbLines = newGrid.NbLines;
            this.Cells = newGrid.Cells;
            this.PayoffMatrix = newGrid.PayoffMatrix;
            this.WrapMode = newGrid.WrapMode;
        }

        /// <summary>
        /// Loads the serialized data from the default location
        /// </summary>
        public void loadData()
        {
            this.loadData(DEFAULT_DATA_FILEPATH);
        }
        #endregion
    }
}
