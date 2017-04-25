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
        #region consts
        private const int DEFAULT_TEMPTATION_PAYOFF = 0;
        private const int DEFAULT_REWARD_PAYOFF = 1;
        private const int DEFAULT_PUNISHMENT_PAYOFF = 3;
        private const int DEFAULT_SUCKER_PAYOFF = 5;
        #endregion

        private int _reward;        // Reward payoff
        private int _sucker;        // Sucker's payoff
        private int _temptation;    // Tempatation payoff
        private int _punishment;    // Punishment payoff
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
        /// T better than R better than P better than S
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

        /// <summary>
        /// Default constructor
        /// </summary>
        public PayoffMatrix() : this(DEFAULT_TEMPTATION_PAYOFF, DEFAULT_REWARD_PAYOFF, DEFAULT_PUNISHMENT_PAYOFF, DEFAULT_SUCKER_PAYOFF)
        {
            // No code
        }
        #endregion

        #region methods
        /// <summary>
        /// Returns player1's payoff of a match.
        /// </summary>
        /// <param name="playerOneChoice"></param>
        /// <param name="playerTwoChoice"></param>
        /// <returns></returns>
        public int returnPayoff(Move playerOneChoice, Move playerTwoChoice)
        {
            int payoff = 0;

            switch (playerOneChoice)
            {
                case Move.Cooperate:
                    // Player 1 cooperates, Player 2 cooperates = Reward payoff
                    if (playerTwoChoice == Move.Cooperate)
                    {
                        payoff = this.Reward;
                    }
                    // Player 1 cooperates, Player 2 defects = Sucker's payoff
                    if (playerTwoChoice == Move.Defect)
                    {
                        payoff = this.Sucker;
                    }
                    break;

                case Move.Defect:
                    // Player 1 defects, Player 2 cooperates = Temptation payoff
                    if (playerTwoChoice == Move.Cooperate)
                    {
                        payoff = this.Temptation;
                    }

                    // Player 2 defects, Player 2 defects = Punishment payoff
                    if (playerTwoChoice == Move.Defect)
                    {
                        payoff = this.Punishment;
                    }
                    break;

                case Move.None:
                    // Return an error if one of the player didnt choose a move
                    throw new NotImplementedException();
            }

            return payoff;
        }

        /// <summary>
        /// Checks the validity of the matrix according to the rules :
        /// T better than R better than P better than S
        /// </summary>
        /// <param name="t"></param>
        /// <param name="r"></param>
        /// <param name="p"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool isValid(int t, int r, int p, int s)
        {
            bool result = false;

            // First condition of validity
            if ((t < r) && (r < p) && (p < s))
            {
                if (2 * r < t + s)
                {
                    result = true;
                }
            }

            return result;
        }

        /// <summary>
        /// Overloaded function that allows isValid to be used on the current object
        /// </summary>
        /// <returns></returns>
        public bool isValid()
        {
            return PayoffMatrix.isValid(this.Temptation, this.Reward, this.Punishment, this.Sucker);
        }

        #endregion
    }
}
