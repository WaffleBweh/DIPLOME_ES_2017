/*
    Class           :   StratPavlov.cs
    Description     :   Identifies an opponents according to his moves and counters them
                        http://www.prisoners-dilemma.com/strategies.html

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
    public class StratAdaptativePavlov : Strategy
    {
        #region fields
        #region consts
        private const int DEFAULT_NB_OF_ANALYSING_TURNS = 7;
        #endregion

        private StratTitForTat _tft;
        private StratTitForTwoTats _tftt;
        private StratAlwaysDefect _ad;
        private Strategy _currentStrategy;

        private int _defectCount;
        #endregion

        #region properties
        public StratTitForTat Tft
        {
            get
            {
                return _tft;
            }

            set
            {
                _tft = value;
            }
        }

        public StratTitForTwoTats Tftt
        {
            get
            {
                return _tftt;
            }

            set
            {
                _tftt = value;
            }
        }

        public StratAlwaysDefect Ad
        {
            get
            {
                return _ad;
            }

            set
            {
                _ad = value;
            }
        }

        public Strategy CurrentStrategy
        {
            get
            {
                return _currentStrategy;
            }

            set
            {
                _currentStrategy = value;
            }
        }

        public int DefectCount
        {
            get
            {
                return _defectCount;
            }

            set
            {
                _defectCount = value;
            }
        }
        #endregion

        #region constructors
        public StratAdaptativePavlov()
        {
            this.Tft = new StratTitForTat();
            this.Tftt = new StratTitForTwoTats();
            this.Ad = new StratAlwaysDefect();
            this.CurrentStrategy = this.Tft;

            this.DefectCount = 0;
        }
        #endregion

        #region methods
        public override Move chooseMove(Cell cell, List<Cell> neighbors)
        {
            // Count the number of defectors before proceeding
            foreach (var neighbor in neighbors)
            {
                if (neighbor.History.Count > 0)
                {
                    if (neighbor.History.First() == Move.Defect)
                    {
                        this.DefectCount++;
                    }
                }
            }

            // We analyse other cells while playing tit for tat before we reach the threshold
            if (cell.History.Count < DEFAULT_NB_OF_ANALYSING_TURNS)
            {
                this.CurrentStrategy = this.Tft;
            }
            else
            {
                // Change our move only every x rounds
                if (cell.History.Count % DEFAULT_NB_OF_ANALYSING_TURNS == 0)
                {
                    // Find the average defect count over the number of analysing turns turns
                    this.DefectCount /= neighbors.Count;

                    // Choose a move according to the defect count
                    if (this.DefectCount > 4)
                    {
                        // Opponent always defects, we play always defect
                        this.CurrentStrategy = this.Ad;
                    }
                    else if (this.DefectCount == 3)
                    {
                        // Opponent is STFT, we play TFTT
                        this.CurrentStrategy = this.Tftt;
                    }
                    else if (this.DefectCount == 0)
                    {
                        // Opponent cooperates, we play TFT
                        this.CurrentStrategy = this.Tft;
                    }
                    else
                    {
                        // Classified as random strategy, we always defect
                        this.CurrentStrategy = this.Ad;
                    }

                    // When we are done analysing, we reset the counter
                    this.DefectCount = 0;
                }
            }

            // Return our current choice according to our strategy
            return this.CurrentStrategy.chooseMove(cell, neighbors);
        }

        public override Color getColor()
        {
            return Color.FromArgb(165, 214, 167);
        }
        #endregion
    }
}
