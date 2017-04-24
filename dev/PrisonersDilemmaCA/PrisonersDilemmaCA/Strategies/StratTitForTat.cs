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
            if (!(cell.LastMove == Move.None))
            {
                // The best score is the lowest one
                int minScore = neighbors[0].Score;
                foreach (Cell neighbor in neighbors)
                {
                    // Find the lowest score and copy the oppenents last move
                    if (minScore > neighbor.Score)
                    {
                        minScore = neighbor.Score;
                        result = neighbor.LastMove;
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
