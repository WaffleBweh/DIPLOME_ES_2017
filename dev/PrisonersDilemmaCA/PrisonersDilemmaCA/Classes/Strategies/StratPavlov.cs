/*
    Class           :   StratPavlov.cs
    Description     :   Identifies an opponents according to his moves and counters them
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
    public class StratPavlov : Strategy
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
            return Color.FromArgb(165, 214, 167);
        }
        #endregion
    }
}
