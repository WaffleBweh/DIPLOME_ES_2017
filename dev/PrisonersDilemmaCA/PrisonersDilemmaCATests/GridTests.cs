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
    public class GridTests
    {
        [TestMethod()]
        public void DesignatedConstructorTest()
        {
            GridModel myGrid = new GridModel(50, 100, 10, 20, new PayoffMatrix());

            // Check if we have the correct number of cells
            int expectedNbCells = 10 * 20;
            Assert.AreEqual(expectedNbCells, myGrid.Cells.Length);

            // Check if the values sent are correct
            Assert.AreEqual(50, myGrid.Width);
            Assert.AreEqual(100, myGrid.Height);
            Assert.AreEqual(10, myGrid.NbLines);
            Assert.AreEqual(20, myGrid.NbCols);
        }

        [TestMethod()]
        public void getPointClampedInGridTest()
        {
            GridModel myGrid = new GridModel(100, 100, 10, 10, new PayoffMatrix());

            // Values to send through the function
            int sentX1 = 12;
            int sentY1 = 10;
            int sentX2 = -2;
            int sentY2 = -1;

            // Get our positions
            Point actual1 = myGrid.getPointClampedInGrid(sentX1, sentY1);
            Point actual2 = myGrid.getPointClampedInGrid(sentX2, sentY2);
            Point expected1 = new Point(2, 0);
            Point expected2 = new Point(8, 9);

            // Check for equality
            Assert.AreEqual(expected1.X, actual1.X);
            Assert.AreEqual(expected1.Y, actual1.Y);

            Assert.AreEqual(expected2.X, actual2.X);
            Assert.AreEqual(expected2.Y, actual2.Y);
        }

        [TestMethod()]
        public void getCellTest()
        {
            GridModel myGrid = new GridModel(100, 100, 10, 10, new PayoffMatrix());
            Cell actual;

            // Values to send through the function
            int x1 = 10;
            int y1 = 10;
            int x2 = 11;
            int y2 = 7;
            int x3 = -1;
            int y3 = -1;

            int expectedX1 = 0;
            int expectedY1 = 0;

            int expectedX2 = 1;
            int expectedY2 = 7;

            int expectedX3 = 9;
            int expectedY3 = 9;

            // Compare 1
            actual = myGrid.getCell(x1, y1);
            Assert.AreEqual(expectedX1, actual.X);
            Assert.AreEqual(expectedY1, actual.Y);

            // Compare 2
            actual = myGrid.getCell(x2, y2);
            Assert.AreEqual(expectedX2, actual.X);
            Assert.AreEqual(expectedY2, actual.Y);

            // Compare 3
            actual = myGrid.getCell(x3, y3);
            Assert.AreEqual(expectedX3, actual.X);
            Assert.AreEqual(expectedY3, actual.Y);
        }

        [TestMethod()]
        public void findCellNeighborsTest()
        {
            GridModel myGrid = new GridModel(100, 100, 20, 20, new PayoffMatrix());
            List<Cell> actual = myGrid.findCellNeighbors(myGrid.getCell(11,0));

            // Test the actual number of neighbors
            // 1) Find the width of the "grid" around our cell (neighbor grid)
            // 2) Find the area of the grid and substract our own cell (in the center)
            int diameterOfNeighborGrid = (GridModel.NEAREST_NEIGHBOR_RANGE * 2) + 1;
            int expectedCount = (diameterOfNeighborGrid * diameterOfNeighborGrid) - 1;

            Assert.AreEqual(expectedCount, actual.Count);
        }
    }
}
