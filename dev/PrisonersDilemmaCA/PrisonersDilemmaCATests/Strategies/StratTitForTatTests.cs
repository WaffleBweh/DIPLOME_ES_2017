﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrisonersDilemmaCA;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace PrisonersDilemmaCA.Tests
{
    [TestClass()]
    public class StratTitForTatTests
    {
        [TestMethod()]
        public void chooseMoveTest()
        {
            // Initialize
            Grid myGrid = new Grid(100, 100, 10, 10, new PayoffMatrix());

            // Steps forward to get the last move in the history
            myGrid.step();

            Move expected = Move.Cooperate;

            // Compare the last move with what we expected
            Assert.AreEqual(expected, myGrid.Cells[0, 0].History.First());


            // Add a cooperator
            myGrid.onClick(15, 5, new StratAlwaysCooperate());
            expected = Move.Cooperate;
            myGrid.step();

            // Tit for tats doesn't respond
            Assert.AreEqual(expected, myGrid.Cells[0, 0].History.First());
            myGrid.step();
            expected = Move.Cooperate;

            // Add a defector
            myGrid.onClick(15, 5, new StratAlwaysDefect());
            expected = Move.Cooperate;
            myGrid.step();

            Assert.AreEqual(expected, myGrid.Cells[0, 0].History.First());
            myGrid.step();
            expected = Move.Cooperate;

            // Tit for tats mimics the defector
            Assert.AreEqual(expected, myGrid.Cells[0, 0].History.First());
            myGrid.step();
            expected = Move.Defect;

            Assert.AreEqual(expected, myGrid.Cells[0, 0].History.First());
            myGrid.step();
        }
    }
}
