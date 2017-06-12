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
    public class PayoffMatrixTests
    {
        [TestMethod()]
        public void DesignatedConstructorTest()
        {
            int t = 5; int r = 3; int p = 2; int s = 0;
            PayoffMatrix myMatrix = new PayoffMatrix(t, r, p, s);

            Assert.AreEqual(t, myMatrix.Temptation);
            Assert.AreEqual(r, myMatrix.Reward);
            Assert.AreEqual(p, myMatrix.Punishment);
            Assert.AreEqual(s, myMatrix.Sucker);
        }

        [TestMethod()]
        public void returnPayoffTest()
        {
            // Test the 4 cases
            int t = 5; int r = 3; int p = 2; int s = 0;
            PayoffMatrix myMatrix = new PayoffMatrix(t, r, p, s);

            // TEMPTATION   (Defect - Cooperate)
            Assert.AreEqual(t, myMatrix.returnPayoff(Move.Defect, Move.Cooperate));

            // REWARD       (Cooperate - Cooperate)
            Assert.AreEqual(r, myMatrix.returnPayoff(Move.Cooperate, Move.Cooperate));

            // PUNISHMENT   (Defect - Defect)
            Assert.AreEqual(p, myMatrix.returnPayoff(Move.Defect, Move.Defect));

            // SUCKER       (Cooperate - Defect)
            Assert.AreEqual(s, myMatrix.returnPayoff(Move.Cooperate, Move.Defect));
        }

        [TestMethod()]
        public void isValidStaticTest()
        {
            int t = 0; int r = 1; int p = 3; int s = 5;

            Assert.AreEqual(true, PayoffMatrix.isValid(t, r, p, s));
            r = 0;
            Assert.AreEqual(false, PayoffMatrix.isValid(t, r, p, s));
            r = 1;
            Assert.AreEqual(true, PayoffMatrix.isValid(t, r, p, s));

        }

        [TestMethod()]
        public void isValidConvenianceTest()
        {
            int t = 0; int r = 1; int p = 3; int s = 5;
            PayoffMatrix myMatrix = new PayoffMatrix(t, r, p, s);

            Assert.AreEqual(true, myMatrix.isValid());
            myMatrix.Reward = 0;
            Assert.AreEqual(false, myMatrix.isValid());
            myMatrix.Reward = 1;
            Assert.AreEqual(true, myMatrix.isValid());
        }
    }
}
