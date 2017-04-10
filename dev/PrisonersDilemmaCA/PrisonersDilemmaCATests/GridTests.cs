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
    public class GridTests
    {
        [TestMethod()]
        public void DesignatedConstructorTest()
        {
            Grid myGrid = new Grid(50, 100, 10, 20);

            // Check if we have the correct number of cells
            int expectedNbCells = 10 * 20;
            Assert.AreEqual(expectedNbCells, myGrid.Cells.Count);

            // Check if the values sent are correct
            Assert.AreEqual(50, myGrid.Width);
            Assert.AreEqual(100, myGrid.Height);
            Assert.AreEqual(10, myGrid.NbLines);
            Assert.AreEqual(20, myGrid.NbCols);
        }

        [TestMethod()]
        public void getPointClampedInGridTest()
        {
            Grid myGrid = new Grid(100, 100, 10, 10);

            // Values to send through the function
            int sentX1 = 12;
            int sentY1 = 10;
            int sentX2 = -2;
            int sentY2 = -1;

            // Get our positions
            Vector2 actual1 = myGrid.getPointClampedInGrid(sentX1, sentY1);
            Vector2 actual2 = myGrid.getPointClampedInGrid(sentX2, sentY2);
            Vector2 expected1 = new Vector2(2, 0);
            Vector2 expected2 = new Vector2(8, 9);

            // Check for equality
            Assert.AreEqual(expected1.X, actual1.X);
            Assert.AreEqual(expected1.Y, actual1.Y);

            Assert.AreEqual(expected2.X, actual2.X);
            Assert.AreEqual(expected2.Y, actual2.Y);
        }

        [TestMethod()]
        public void getCellTest()
        {
            Grid myGrid = new Grid(100, 100, 10, 10);
            Cell actual;

            // Values to send through the function
            int x1 = 10;
            int y1 = 10;
            int x2 = 11;
            int y2 = 7;

            int expectedX1 = 0;
            int expectedY1 = 0;

            int expectedX2 = 1;
            int expectedY2 = 7;

            // Compare 1
            actual = myGrid.getCell(x1, y1);
            Assert.AreEqual(expectedX1, actual.X);
            Assert.AreEqual(expectedY1, actual.Y);

            // Compare 2
            actual = myGrid.getCell(x2, y2);
            Assert.AreEqual(expectedX2, actual.X);
            Assert.AreEqual(expectedY2, actual.Y);
        }

        [TestMethod()]
        public void findCellNeighborsTest()
        {
            Grid myGrid = new Grid(100, 100, 10, 10);
            List<Cell> actual = myGrid.findCellNeighbors(myGrid.getCell(11,0));
            int expectedCount = 8 * Grid.NEAREST_NEIGHBOR_RANGE;

            Assert.AreEqual(expectedCount, actual.Count);
        }
    }
}
