/*
    Class           :   PayoffMatrix.cs
    Description     :   Class used to modelize the prisoner's dilemma payoff matrix
    Author          :   SEEMULLER Julien
    Date            :   10.04.2017
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilemmaCA
{
    public class PayoffMatrix
    {
        #region fields
        private int _reward;
        private int _sucker;
        private int _temptation;
        private int _punishment;
        #endregion

        #region properties
        public int Reward
        {
            get { return _reward; }
            set { _reward = value; }
        }

        public int Sucker
        {
            get { return _sucker; }
            set { _sucker = value; }
        }

        public int Temptation
        {
            get { return _temptation; }
            set { _temptation = value; }
        }

        public int Punishment
        {
            get { return _punishment; }
            set { _punishment = value; }
        }
        #endregion

        #region constructors
        /// <summary>
        /// Designated constructor
        /// 
        /// Rules :
        /// T > R > P > S
        /// T + S > 2R
        /// </summary>
        /// <param name="t">Temptation payoff</param>
        /// <param name="r">Reward payoff</param>
        /// <param name="p">Punishment payoff</param>
        /// <param name="s">Sucker's payoff</param>
        public PayoffMatrix(int t, int r, int p, int s)
        {
            this.Temptation = t;
            this.Reward = r;
            this.Punishment = p;
            this.Sucker = s;
        }
        #endregion

        #region methods
        #endregion
    }
}
