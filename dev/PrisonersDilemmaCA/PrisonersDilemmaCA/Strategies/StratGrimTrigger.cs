/*
    Class           :   StratGrimTrigger.cs
    Description     :   Grim trigger strategy, cooperates until some neighbor 
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
        private bool _wasBetrayed;
        #endregion

        #region properties
        public bool WasBetrayed
        {
            get { return _wasBetrayed; }
            set { _wasBetrayed = value; }
        }
        #endregion

        #region constructors
        public StratGrimTrigger()
        {
            this.WasBetrayed = false;
        }
        #endregion

        #region methods
        public override Move chooseMove(Cell cell, List<Cell> neighbors)
        {
            // Starts by cooperating
            Move result = Move.Cooperate;

            // Check if we were betrayed in the past
            if (WasBetrayed)
            {
                result = Move.Defect;
            }
            else
            {
                // If we didn't get betrayed yet, we look at our neighbors
                if (cell.History.Count > 1)
                {
                    // Look if we got betrayed by a neighbor after our first move
                    foreach (Cell neighbor in neighbors)
                    {
                        if (neighbor.History.First() == Move.Defect)
                        {
                            // If we are betrayed, we switch to a "Always Defect" strategy
                            this.WasBetrayed = true;
                            result = Move.Defect;
                            break;
                        }
                    }
                }
            }

            return result;
        }

        public override Color getColor()
        {
            return Color.FromArgb(52, 73, 94);
        }
        #endregion
    }
}
