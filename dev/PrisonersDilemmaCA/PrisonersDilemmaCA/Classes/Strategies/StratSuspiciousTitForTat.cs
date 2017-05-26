/*
    Class           :   StratTitForTat.cs
    Description     :   Same as Tit-for-tat strategy, but defects first
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
    public class StratSuspiciousTitForTat : Strategy
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
            Move result = Move.Defect;


            // If this wasn't our first round, we look at our neighbors
            if (cell.History.Count > 1)
            {
                // We initialise our variables with the first neighbor in the list
                result = neighbors[0].History.First();
                int min = neighbors[0].Score;

                foreach (Cell neighbor in neighbors)
                {
                    if (min > neighbor.Score)
                    {
                        min = neighbor.Score;
                        result = neighbor.History.First();
                    }
                }
            }

            return result;
        }

        public override Color getColor()
        {
            return Color.FromArgb(239, 154, 154);
        }
        #endregion
    }
}
