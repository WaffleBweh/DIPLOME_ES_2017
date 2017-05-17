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
    public class StratAlwaysDefectTests
    {
        [TestMethod()]
        public void chooseMoveTest()
        {
            // Initialize
            GridModel myGrid = new GridModel(200, 200, 10, 10, new PayoffMatrix());
            myGrid.onClick(5, 5, new StratAlwaysDefect());
            Move expected = Move.Defect;

            // Compare the last move with what we expected
            Assert.AreEqual(expected, myGrid.Cells[0, 0].History.First());
        }


    }
}
