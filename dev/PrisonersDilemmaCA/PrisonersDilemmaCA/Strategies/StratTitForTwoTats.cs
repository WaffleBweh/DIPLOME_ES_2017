/*
    Class           :   StratTitForTwoTat.cs
    Description     :   Tit-for-two-tats strategy, copies a neighbors if 
                        he plays the same move twice in a row.

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
    public class StratTitForTwoTats : Strategy
    {
        #region fields
        #endregion

        #region properties
        #endregion

        #region constructors
        #endregion

        #region methods
        public override Move chooseMove(Cell cell, List<Cell> neighbors)
        {
            // Cooperates on first move, then copies his best openent
            Move result = Move.Cooperate;


            // If this wasn't our first round, we look at our neighbors
            if (cell.History.Count > 1)
            {
                // We initialise our variables with the first neighbor in the list
                result = cell.History.First();
                int min = cell.Score;

                foreach (Cell neighbor in neighbors)
                {
                    if (min > neighbor.Score)
                    {
                        min = neighbor.Score;
                        // If one of our neighbors makes a move twice in a row we copy it
                        if (neighbor.History.ElementAt(0) == neighbor.History.ElementAt(1))
                        {
                            result = neighbor.History.First();
                        }
                    }
                }
            }


            return result;
        }

        public override Color getColor()
        {
            return Color.FromArgb(100, 100, 100);
        }
        #endregion
    }
}
