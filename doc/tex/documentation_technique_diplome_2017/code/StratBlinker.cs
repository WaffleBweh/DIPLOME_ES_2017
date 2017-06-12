/*
    Class           :   StratBlinker.cs
    Description     :   Blinker strategy, alternates between "defect" and "cooperate"
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
    public class StratBlinker : Strategy
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

            if (cell.History.Count % 2 == 0)
            {
                result = Move.Cooperate;
            }
            else
            {
                result = Move.Defect;
            }


            return result;
        }

        public override Color getColor()
        {
            return Color.FromArgb(155, 89, 182);
        }
        #endregion
    }
}
