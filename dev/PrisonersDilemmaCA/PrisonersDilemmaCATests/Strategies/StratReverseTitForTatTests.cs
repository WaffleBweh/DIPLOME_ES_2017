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
    public class StratReverseTitForTatTests
    {
        [TestMethod()]
        public void chooseMoveTest()
        {
            // Initialize
            Grid myGrid = new Grid(100, 100, 10, 10, new PayoffMatrix());
            myGrid.onClick(5, 5, new StratReverseTitForTat());

            // Steps forward to get the last move in the history
            myGrid.step();

            Move expected = Move.Defect;

            // Compare the last move with what we expected
            Assert.AreEqual(expected, myGrid.Cells[0, 0].History.First());


            // Add a cooperator
            myGrid.onClick(15, 5, new StratAlwaysCooperate());
            expected = Move.Defect;
            myGrid.step();

            // Tit for tats doesn't respond and still defects
            Assert.AreEqual(expected, myGrid.Cells[0, 0].History.First());
            myGrid.step();
            expected = Move.Defect;

            // Add a defector
            myGrid.onClick(15, 5, new StratAlwaysDefect());
            expected = Move.Defect;
            myGrid.step();

            Assert.AreEqual(expected, myGrid.Cells[0, 0].History.First());
            myGrid.step();
            expected = Move.Defect;

            // Tit for tats does the inverse
            Assert.AreEqual(expected, myGrid.Cells[0, 0].History.First());
            myGrid.step();
            expected = Move.Defect;

            Assert.AreEqual(expected, myGrid.Cells[0, 0].History.First());
            myGrid.step();
        }
    }
}
