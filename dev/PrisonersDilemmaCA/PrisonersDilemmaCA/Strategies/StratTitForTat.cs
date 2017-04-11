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
    public class StratTitForTat : IStrategy
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
            return Color.FromArgb(200, 200, 200);
        }
        #endregion
    }
}
