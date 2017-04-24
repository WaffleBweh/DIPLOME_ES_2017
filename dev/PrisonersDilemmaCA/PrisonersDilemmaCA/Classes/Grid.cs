﻿/*
    Class           :   Grid.cs
    Description     :   Stores the cells of the cellular automaton
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
    public class Grid
    {
        #region fields

        #region consts
        public const int NEAREST_NEIGHBOR_RANGE = 1;
        #endregion

        private Cell[,] _cells;
        private int _width;
        private int _height;
        private int _nbLines;
        private int _nbCols;
        private PayoffMatrix _payoffMatrix;
        #endregion

        #region properties
        public Cell[,] Cells
        {
            get { return _cells; }
            set { _cells = value; }
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
        #endregion

        #region constructors
        /// <summary>
        /// Designated constructor
        /// </summary>
        /// <param name="width">The width of the grid in pixels</param>
        /// <param name="height">The height of the grid in pixels</param>
        /// <param name="nbCols">The number of columns of the grid</param>
        /// <param name="nbLines">The number of lines of the grid</param>
        public Grid(int width, int height, int nbLines, int nbCols, PayoffMatrix matrix)
        {
            this.Width = width;
            this.Height = height;
            this.NbLines = nbLines;
            this.NbCols = nbCols;
            this.PayoffMatrix = matrix;

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
                    Cell tmpCell = new Cell(x, y, this.PayoffMatrix);

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
        /// <param name="g"></param>
        public void draw(Graphics g)
        {
            // Draw each cell
            foreach (Cell cell in this.Cells)
            {
                cell.draw(g);
            }

            // Get the cell width (take the first one in the list
            int cellWidth = this.Cells[0, 0].Width;
            int cellHeight = this.Cells[0, 0].Height;

            // Draw the lines
            for (int y = 0; y <= this.NbLines; y++)
            {
                int startX = 0;
                int startY = y * cellHeight;
                int endX = this.Width;
                int endY = y * cellHeight;

                // If we are on the last line, account for the 1 extra pixel
                if (y == this.NbLines)
                {
                    startY -= 1;
                    endY -= 1;
                }

                g.DrawLine(Pens.Black, startX, startY, endX, endY);
            }

            // Draw the columns
            for (int x = 0; x <= this.NbCols; x++)
            {
                int startX = x * cellWidth;
                int startY = 0;
                int endX = x * cellWidth;
                int endY = this.Height;

                // If we are on the last line, account for the 1 extra pixel
                if (x == this.NbCols)
                {
                    startX -= 1;
                    endX -= 1;
                }

                g.DrawLine(Pens.Black, startX, startY, endX, endY);
            }
        }

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
                cell.Strategy = strategyPopulation[rnd];
            }
        }

        /// <summary>
        /// Gets the cell at the given position in a toroidal fashion
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Cell getCell(int x, int y)
        {
            // Find the corrisponding point in a toroidal fashion if we go out of bounds
            Vector2 point = getPointClampedInGrid(x, y);
            int newX = point.X;
            int newY = point.Y;

            // Return the correct cell
            return this.Cells[newY, newX];
        }

        /// <summary>
        /// Gets a point and wraps around in a toroidal fashion if the point
        /// is out of bounds
        /// </summary>
        /// <param name="x">The x coordinate of the point to check</param>
        /// <param name="y">The x coordinate of the point to check</param>
        /// <returns></returns>
        public Vector2 getPointClampedInGrid(int x, int y)
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

            return new Vector2(newX, newY);
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
                        // Add the neighbor
                        neighbors.Add(this.getCell(x, y));
                    }
                }
            }

            return neighbors;
        }


        /// <summary>
        /// Update the strategy of the cell that has been hit by the cursor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="strat"></param>
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
        /// <param name="mode"></param>
        public void setColorMode(ColorMode mode)
        {
            // Switch according to the mode
            switch (mode)
            {
                case ColorMode.Strategy:
                    this.setColorFromStrategy();
                    break;
                case ColorMode.Move:
                    this.setColorFromMove();
                    break;
            }
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
        #endregion
    }
}
