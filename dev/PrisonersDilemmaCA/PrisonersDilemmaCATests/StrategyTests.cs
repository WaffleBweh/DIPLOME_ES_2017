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
    public class StrategyTests
    {
        [TestMethod()]
        public void ToStringTest()
        {
            StratAlwaysCooperate actual1 = new StratAlwaysCooperate();
            string expected1 = "Always Cooperate";

            StratAlwaysDefect actual2 = new StratAlwaysDefect();
            string expected2 = "Always Defect";

            StratBlinker actual3 = new StratBlinker();
            string expected3 = "Blinker";

            StratRandom actual4 = new StratRandom();
            string expected4 = "Random";

            Assert.AreEqual(expected1, actual1.ToString());
            Assert.AreEqual(expected2, actual2.ToString());
            Assert.AreEqual(expected3, actual3.ToString());
            Assert.AreEqual(expected4, actual4.ToString());
        }

        [TestMethod()]
        public void CompareToTest()
        {
            // The strategies are sorted by name
            int expected = 0;
            StratAlwaysCooperate strat1 = new StratAlwaysCooperate();
            StratAlwaysCooperate strat2 = new StratAlwaysCooperate();

            Assert.AreEqual(expected, strat1.CompareTo(strat2));

            expected = -1;
            StratAlwaysDefect strat3 = new StratAlwaysDefect();

            Assert.AreEqual(expected, strat1.CompareTo(strat3));

            expected = 1;

            Assert.AreEqual(expected, strat3.CompareTo(strat1));
        }
    }
}
