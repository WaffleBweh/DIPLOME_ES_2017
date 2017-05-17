/*
    Class           :   GridController.cs
    Description     :   Main controller (MVC)
    Author          :   SEEMULLER Julien
    Date            :   17.05.2017
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
    public class GridController
    {
        #region fields
        private const string DEFAULT_DATA_FILENAME = "grid_data.xml";

        private GridModel _grid;
        private PayoffMatrix _payoffMatrix;
        private List<Strategy> _availableStrategies;
        #endregion

        #region properties
        public GridModel Grid
        {
            get { return _grid; }
            set { _grid = value; }
        }

        public PayoffMatrix PayoffMatrix
        {
            get { return _payoffMatrix; }
            set { _payoffMatrix = value; }
        }

        public List<Strategy> AvailableStrategies
        {
            get { return _availableStrategies; }
            set { _availableStrategies = value; }
        }
        #endregion

        #region constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public GridController(int width, int height, int nbLines, int nbCols, WrapMode wrapmode)
        {
            // Make a list of all our available strategies
            this.AvailableStrategies = new List<Strategy>();

            // To add more strategies, add them to the list
            this.AvailableStrategies.Add(new StratRandom());
            this.AvailableStrategies.Add(new StratTitForTat());
            this.AvailableStrategies.Add(new StratBlinker());
            this.AvailableStrategies.Add(new StratAlwaysCooperate());
            this.AvailableStrategies.Add(new StratAlwaysDefect());
            this.AvailableStrategies.Add(new StratTitForTwoTats());
            this.AvailableStrategies.Add(new StratGrimTrigger());
            this.AvailableStrategies.Add(new StratFortress());

            // Sort the list
            this.AvailableStrategies.Sort();

            // Initialize the payoff matrix with default values
            this.PayoffMatrix = new PayoffMatrix();

            // Create our grid
            this.Grid = new GridModel(width, height, nbLines, nbCols, this.PayoffMatrix, wrapmode);
        }
        #endregion

        #region methods
        /// <summary>
        /// Steps forward in time
        /// </summary>
        public void step()
        {
            this.Grid.step();
        }


        /// <summary>
        /// Generates a grid randomly from a dictionary of the available
        /// strategies and thier proportions
        /// </summary>
        /// <param name="strategyAndPercentages"></param>
        public void generate(Dictionary<Strategy, int> strategyAndPercentages)
        {
            this.Grid.generate(strategyAndPercentages);
        }


        /// <summary>
        /// Update the strategy of the cell that has been hit by the cursor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="strat"></param>
        public void onClick(int x, int y, Strategy strat)
        {
            this.Grid.onClick(x, y, strat);
        }


        /// <summary>
        /// Set the color depending on the mode
        /// 
        /// When in strategy color mode  :  The color of the strategy is shown.
        /// When in move color mode      :  The color of the last move is shown.
        /// 
        /// </summary>
        /// <param name="mode"></param>
        public void setColorMode(ColorMode mode)
        {
            this.Grid.setColorMode(mode);
        }


        /// <summary>
        /// Finds the number of times the given strategy appears on the board
        /// </summary>
        /// <param name="strategy"></param>
        /// <returns></returns>
        public int findCountOfStrategy(Strategy strategy)
        {
            return this.Grid.findCountOfStrategy(strategy);
        }


        /// <summary>
        /// Returns the average score of a strategy on the grid
        /// </summary>
        /// <param name="strategy"></param>
        /// <returns></returns>
        public double findAvgScoreOfStrategy(Strategy strategy)
        {
            return this.Grid.findAvgScoreOfStrategy(strategy);
        }


        /// <summary>
        /// Returns the current colormode of the grid
        /// </summary>
        /// <returns></returns>
        public ColorMode getColorMode()
        {
            return this.Grid.ColorMode;
        }

        /// <summary>
        /// Serializes and saves grid data to a path
        /// </summary>
        /// <param name="path"></param>
        public void saveData(string path)
        {
            this.Grid.SerializableCells = this.Grid.Cells.asList();
            FileStream fs = new FileStream(path, FileMode.Create);
            XmlSerializer xs = new XmlSerializer(typeof(GridModel));
            xs.Serialize(fs, this);
            fs.Close();
        }


        /// <summary>
        /// Serialize and saves grid data to the default location
        /// </summary>
        public void saveData()
        {
            this.saveData(DEFAULT_DATA_FILENAME);
        }


        /// <summary>
        /// Load serialized data from a path
        /// </summary>
        /// <param name="path"></param>
        public GridModel loadData(string path)
        {
            GridModel newGrid;
            XmlSerializer xs = new XmlSerializer(typeof(GridModel));
            using (StreamReader rd = new StreamReader(path))
            {
                newGrid = xs.Deserialize(rd) as GridModel;
            }

            return newGrid;
        }

        /// <summary>
        /// Loads the serialized data from the default location
        /// </summary>
        public GridModel loadData()
        {
            return this.loadData(DEFAULT_DATA_FILENAME);
        }


        /// <summary>
        /// TO REMOVE - DRAWING FROM MODEL
        /// </summary>
        /// <param name="g"></param>
        public void draw(Graphics g){
            this.Grid.draw(g);
        }
        #endregion
    }
}
