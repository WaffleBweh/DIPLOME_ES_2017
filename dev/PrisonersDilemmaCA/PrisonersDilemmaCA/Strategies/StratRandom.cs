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
    public class StratRandom : Strategy
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
            // Make a new unique random number generator
            Random rng = new Random(Guid.NewGuid().GetHashCode());

            // Make a list with the possible moves
            List<Move> availableMoves = new List<Move>();
            availableMoves.Add(Move.Cooperate);
            availableMoves.Add(Move.Defect);

            // Return a random element in the list
            return availableMoves[rng.Next(availableMoves.Count)];
        }

        public override Color getColor()
        {
            return Color.FromArgb(41, 128, 185);
        }
        #endregion
    }
}
