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

        [TestMethod()]
        public void onClickTest()
        {
            Cell myCell = new Cell(1, 1, new PayoffMatrix());
            StratRandom rndStrat = new StratRandom();

            myCell.Width = 15;
            myCell.Height = 15;

            // Click outside the cell
            myCell.onClick(60, 60, rndStrat);

            // Compare the strategies names (SHOULD BE NOT EQUAL)
            Assert.AreNotEqual(rndStrat.ToString(), myCell.Strategy.ToString());

            // Click inside the cell
            myCell.onClick(20, 20, rndStrat);

            // Compare the strategies names (SHOULD BE EQUAL)
            Assert.AreEqual(rndStrat.ToString(), myCell.Strategy.ToString());
        }
    }
}
