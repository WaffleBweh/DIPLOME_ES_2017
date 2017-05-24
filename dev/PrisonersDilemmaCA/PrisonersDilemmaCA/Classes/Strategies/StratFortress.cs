/*
    Class           :   StratFortress.cs
    Description     :   Fortress strategy, tries to find neighbors using fortress 
                        and cooperates with them.
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
    public class StratFortress : Strategy
    {
        #region fields
        private bool _hasFoundPartners;
        #endregion

        #region properties
        public bool HasFoundPartners
        {
            get { return _hasFoundPartners; }
            set { _hasFoundPartners = value; }
        }
        #endregion

        #region constructors
        public StratFortress()
        {
            this.HasFoundPartners = false;
        }
        #endregion

        #region methods
        public override Move chooseMove(Cell cell, List<Cell> neighbors)
        {
            Move result = Move.Defect;

            // Strats by playing the sequence "defect, defect, cooperate"
            switch (cell.History.Count)
            {
                case 0:
                    result = Move.Defect;
                    break;
                case 1:
                    result = Move.Defect;
                    break;
                case 2:
                    result = Move.Defect;
                    break;
                case 3:
                    result = Move.Cooperate;
                    break;
                // On the fourth and following turns, we look at our neighbors and see if there are
                // other "Fortress" players
                default:

                    foreach (Cell neighbor in neighbors)
                    {
                        if (neighbor.History.Count >= 3)
                        {
                            if (neighbor.History.ElementAt(0) == Move.Cooperate)
                            {
                                if (neighbor.History.ElementAt(1) == Move.Defect)
                                {
                                    if (neighbor.History.ElementAt(2) == Move.Defect)
                                    {
                                        this.HasFoundPartners = true;
                                    }
                                }
                            }
                        }
                    }

                    // If we have found other fortress players, we cooperate, else we always defect
                    if (HasFoundPartners)
                    {
                        result = Move.Cooperate;
                    }
                    else
                    {
                        result = Move.Defect;
                    }

                    break;
            }


            return result;
        }

        public override Color getColor()
        {
            return Color.FromArgb(230, 126, 34);
        }
        #endregion
    }
}
