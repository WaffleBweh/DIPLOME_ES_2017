/*
    Class           :   Enum.cs
    Description     :   Replaces values with a more verbose alternative
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
    // The different moves a cell can play
    public enum Move { Cooperate, Defect }

    // Defines if the color of the cell is from its actions or strategy
    public enum ColorMode { Strategy, Playing }

    // Defines if we wrap around the board to find neighbors (like a torus)
    public enum WrapMode { Default, Torus }
}
