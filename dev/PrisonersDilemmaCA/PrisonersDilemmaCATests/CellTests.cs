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
    public class CellTests
    {
        [TestMethod()]
        public void DesignatedConstructorTest()
        {
            int x = 0; int y = 0;
            Cell myCell = new Cell(x, y, new StratTitForTat(), new PayoffMatrix());

            Assert.AreEqual(x, myCell.X);
            Assert.AreEqual(y, myCell.Y);
            Assert.AreEqual(new StratTitForTat().GetType(), myCell.Strategy.GetType());
        }

        [TestMethod()]
        public void ConvenianceConstructorTest()
        {
            int x = 0; int y = 0;
            Cell myCell = new Cell(x, y, new PayoffMatrix());

            Assert.AreEqual(x, myCell.X);
            Assert.AreEqual(y, myCell.Y);
        }
    }
}
