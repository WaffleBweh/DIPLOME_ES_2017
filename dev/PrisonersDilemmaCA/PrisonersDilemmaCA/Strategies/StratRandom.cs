/*
    Class           :   StratRandom.cs
    Description     :   Random strategy.
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
    public class StratRandom : IStrategy
    {
        #region fields
        #endregion

        #region properties
        #endregion

        #region constructors
        #endregion

        #region methods
        public Move chooseMove(Cell cell, List<Cell> neighbors)
        {
            throw new NotImplementedException();
        }

        public Color getColor()
        {
            return Color.FromArgb(41, 128, 185);
        }
        #endregion
    }
}
