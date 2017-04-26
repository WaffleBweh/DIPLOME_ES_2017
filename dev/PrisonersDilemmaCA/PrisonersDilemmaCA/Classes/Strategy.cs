/*
    Class           :   Strategy.cs
    Description     :   Strategy abstract class, Cf. Strategy design pattern.
    Author          :   SEEMULLER Julien
    Date            :   10.04.2017
*/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PrisonersDilemmaCA
{
    public abstract class Strategy : IComparable
    {
        #region methods
        /// <summary>
        /// Returns the next move of the cell based on its neighbors
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="neighbors"></param>
        /// <returns></returns>
        public abstract Move chooseMove(Cell cell, List<Cell> neighbors);

        /// <summary>
        /// Returns the color associated with the strategy
        /// </summary>
        /// <returns></returns>
        public abstract Color getColor();

        public override string ToString()
        {
            // Get the name of the current class
            string strategyName = this.GetType().Name;

            // Filter the name (remove "Strat" and use spaces insted of CamelCase)
            strategyName = Regex.Replace(strategyName, "(Strat)", "");
            strategyName = Regex.Replace(strategyName, "([a-z])([A-Z])", "$1 $2");

            return strategyName;
        }

        /// <summary>
        /// Used for sorting, alphanumerical sorting according to the name of the strategy
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            return this.ToString().CompareTo((obj as Strategy).ToString());
        }

        public double findPercentOnGrid(Grid grid)
        {
            double count = 0;

            foreach (Cell cell in grid.Cells)
            {
                // Find every cell that has the same type as the current strategy
                if (this.GetType() == cell.Strategy.GetType())
                {
                    count++;
                }
            }

            // Find the percentage from the count
            count = (count / (double)grid.Cells.Length) * 100;

            // Return the result rounded down to two decimal places
            return Math.Round(count, 2);
        }
        #endregion
    }
}
