/*
    Class           :   StratAlwaysDefect.cs
    Description     :   Always defects strategy
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
    public class StratAlwaysDefect : Strategy
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
            return Move.Defect;
        }

        public override Color getColor()
        {
            return Color.FromArgb(192, 57, 43);
        }
        #endregion
    }
}
