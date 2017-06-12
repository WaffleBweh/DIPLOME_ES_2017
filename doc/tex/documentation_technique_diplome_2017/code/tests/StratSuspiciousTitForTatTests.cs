using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrisonersDilemmaCA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilemmaCA.Tests
{
    [TestClass()]
    public class StratSuspiciousTitForTatTests
    {
        [TestMethod()]
        public void chooseMoveTest()
        {
            // Initialize
            Grid myGrid = new Grid(100, 100, 10, 10, new PayoffMatrix(), WrapMode.Default, new StratAlwaysCooperate());
            myGrid.onClick(5, 5, new StratSuspiciousTitForTat());
            Move expected = Move.Defect; // starts by defecting

            // Compare the last move with what we expected
            Assert.AreEqual(expected, myGrid.Cells[0, 0].History.First());


            // Add a cooperator
            myGrid.onClick(15, 5, new StratAlwaysCooperate());
            expected = Move.Defect;
            myGrid.step();

            // Tit for tat doesn't respond
            Assert.AreEqual(expected, myGrid.Cells[0, 0].History.First());
            myGrid.step();
            expected = Move.Cooperate;

            // Add a defector
            myGrid.onClick(15, 5, new StratAlwaysDefect());
            expected = Move.Cooperate;
            myGrid.step();

            Assert.AreEqual(expected, myGrid.Cells[0, 0].History.First());
            myGrid.step();
            expected = Move.Defect;

            Assert.AreEqual(expected, myGrid.Cells[0, 0].History.First());
            myGrid.step();
            expected = Move.Defect;

            // Tit for tats mimics the defector
            Assert.AreEqual(expected, myGrid.Cells[0, 0].History.First());
        }
    }
}