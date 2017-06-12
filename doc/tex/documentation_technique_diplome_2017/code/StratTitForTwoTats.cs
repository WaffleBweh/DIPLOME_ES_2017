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
            Move result;
            bool hasToDefect = false;

            // If this wasn't our first round, we look at our neighbors, else we cooperate
            if (cell.History.Count > 1)
            {
                // If one of our neighbors defects twice in a row, we 
                foreach (Cell neighbor in neighbors)
                {
                    // Check if our neighbor has played at least 2 turns before proceeding
                    if (neighbor.History.Count >= 2)
                    {
                        if (neighbor.History.ElementAt(0) == Move.Defect && neighbor.History.ElementAt(1) == Move.Defect)
                        {
                            hasToDefect = true;
                            break;
                        }
                    }
                }
            }

            // Send back the correct result
            if (hasToDefect)
            {
                result = Move.Defect;
            }
            else
            {
                result = Move.Cooperate;
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
