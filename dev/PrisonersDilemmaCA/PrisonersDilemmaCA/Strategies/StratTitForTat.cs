/*
    Class           :   StratTitForTat.cs
    Description     :   Tit-for-tat strategy
                        http://www.investopedia.com/terms/t/tit-for-tat.asp

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
    public class StratTitForTat : Strategy
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
                int minScore = neighbors[0].Score;
                result = neighbors[0].History.First();

                // The objective is to copy the opponent's move with the lowest score
                foreach (Cell neighbor in neighbors)
                {
                    // Find the opponents with the best move and copy it
                    if (minScore > neighbor.Score)
                    {
                        minScore = neighbor.Score;
                        result = neighbor.History.First();
                    }
                }
            }

            return result;
        }

        public override Color getColor()
        {
            return Color.FromArgb(200, 200, 200);
        }
        #endregion
    }
}
