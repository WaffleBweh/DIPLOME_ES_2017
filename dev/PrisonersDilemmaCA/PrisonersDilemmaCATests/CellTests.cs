using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrisonersDilemmaCA;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
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

        [TestMethod()]
        public void ImplicitConversionTest()
        {       
                                                                //  x    y      x    y
            Cell myCell = new Cell(1, 1, new PayoffMatrix());   // [10, 10] to [20, 20]
            myCell.Width = 10;
            myCell.Height = 10;
            Rectangle expected = new Rectangle(10, 10, 10, 10); // [10, 10] to [20, 20]
            Rectangle actual = myCell;

            Assert.AreEqual(expected.X, actual.X);
            Assert.AreEqual(expected.Y, actual.Y);
            Assert.AreEqual(expected.Width, actual.Width);
            Assert.AreEqual(expected.Height, actual.Height);
        }
    }
}
