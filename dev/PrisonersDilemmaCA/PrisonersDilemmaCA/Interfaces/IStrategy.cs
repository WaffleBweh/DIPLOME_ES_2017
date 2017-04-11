/*
    Class           :   IStrategy.cs
    Description     :   Strategy interface, Cf. Strategy design pattern.
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
    public interface IStrategy
    {
        #region methods
        Move chooseMove(Cell cell, List<Cell> neighbors);
        Color getColor();
        #endregion
    }
}
