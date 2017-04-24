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
    public class StratGrimTrigger : Strategy
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
            throw new NotImplementedException();
        }

        public override Color getColor()
        {
            return Color.FromArgb(52, 73, 94);
        }
        #endregion
    }
}
