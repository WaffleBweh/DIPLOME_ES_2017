using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilemmaCA
{
    public class TitForTat : IStrategy
    {
        #region fields
        #endregion

        #region properties
        #endregion

        #region constructors
        #endregion

        #region methods
        public void step(Cell cell, List<Cell> neighbors)
        {
            throw new NotImplementedException();
        }

        public System.Drawing.Color getColor()
        {
            return Color.FromArgb(231, 76, 60);
        }
        #endregion
    }
}
