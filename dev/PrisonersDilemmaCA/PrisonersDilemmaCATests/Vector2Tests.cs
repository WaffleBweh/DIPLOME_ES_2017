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
    public class Vector2Tests
    {
        [TestMethod()]
        public void Vector2Test()
        {
            int x = 12; int y = 30;
            Vector2 myVector2 = new Vector2(x, y);

            Assert.AreEqual(x, myVector2.X);
            Assert.AreEqual(y, myVector2.Y);
        }
    }
}
