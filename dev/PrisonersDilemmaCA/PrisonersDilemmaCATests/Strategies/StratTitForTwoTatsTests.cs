using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrisonersDilemmaCA;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace PrisonersDilemmaCA.Tests
{
    [TestClass()]
    public class StratTitForTwoTatsTests
    {
        [TestMethod()]
        public void chooseMoveTest()
        {
            // Initialize
            GridModel myGrid = new GridModel(100, 100, 10, 10, new PayoffMatrix());
            myGrid.onClick(5, 5, new StratTitForTwoTats());
            Move expected = Move.Cooperate;

            // Compare the last move with what we expected
            Assert.AreEqual(expected, myGrid.Cells[0, 0].History.First());


            // Add a cooperator
            myGrid.onClick(15, 5, new StratAlwaysCooperate());
            expected = Move.Cooperate;
            myGrid.step();

            // Tit for two tats doesn't respond
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

            // Tit for two tats mimics the defector after 2 moves
            Assert.AreEqual(expected, myGrid.Cells[0, 0].History.First());
            myGrid.step();
            expected = Move.Defect;

            Assert.AreEqual(expected, myGrid.Cells[0, 0].History.First());
            myGrid.step();
        }
    }
}
