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
    public class StratFortressTests
    {
        [TestMethod()]
        public void chooseMoveTest()
        {
            // Initialize
            Grid myGrid = new Grid(200, 200, 10, 10, new PayoffMatrix());
            myGrid.onClick(5, 5, new StratFortress());

            Move expected = Move.Defect;

            // Compare the last move with what we expected
            Assert.AreEqual(expected, myGrid.Cells[0, 0].History.First());
            myGrid.step();
            expected = Move.Defect;

            Assert.AreEqual(expected, myGrid.Cells[0, 0].History.First());
            myGrid.step();
            expected = Move.Defect;

            Assert.AreEqual(expected, myGrid.Cells[0, 0].History.First());
            myGrid.step();
            expected = Move.Cooperate;

            Assert.AreEqual(expected, myGrid.Cells[0, 0].History.First());

        }
    }
}
