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
    public class ColorExtensionsTests
    {
        [TestMethod()]
        public void ToHexTest()
        {
            Color actual = Color.FromArgb(255,255,255);
            string expected = "#FFFFFF";
            Assert.AreEqual(expected, actual.ToHex());

            actual = Color.FromArgb(0, 0, 0);
            expected = "#000000";
            Assert.AreEqual(expected, actual.ToHex());
        }

        [TestMethod()]
        public void ToHexTransparentTest()
        {
            Color actual = Color.FromArgb(255, 255, 255, 255);
            string expected = "#FFFFFFFF";
            Assert.AreEqual(expected, actual.ToHex(255));

            actual = Color.FromArgb(255, 0, 0, 0);
            expected = "#FF000000";
            Assert.AreEqual(expected, actual.ToHex(255));
        }

        [TestMethod()]
        public void ToRGBTest()
        {
            Color actual = Color.FromArgb(255, 255, 255);
            string expected = "RGB(255,255,255)";
            Assert.AreEqual(expected, actual.ToRGB());

            actual = Color.FromArgb(0, 0, 0);
            expected = "RGB(0,0,0)";
            Assert.AreEqual(expected, actual.ToRGB());
        }
    }
}
