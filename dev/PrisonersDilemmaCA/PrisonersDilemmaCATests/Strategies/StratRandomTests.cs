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
    public class StratRandomTests
    {
        [TestMethod()]
        public void chooseMoveTest()
        {
            // Initialize
            GridModel myGrid = new GridModel(100, 100, 10, 10, new PayoffMatrix());
            myGrid.onClick(5, 5, new StratRandom());

            // Compare the last move with what we expected
            Move actual = myGrid.Cells[0, 0].History.First();
            Assert.AreEqual(true, ((actual == Move.Defect) || (actual == Move.Cooperate)));
        }
    }
}
