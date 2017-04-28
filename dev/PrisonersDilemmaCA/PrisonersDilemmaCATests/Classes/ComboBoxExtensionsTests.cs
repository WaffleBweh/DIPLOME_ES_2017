using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrisonersDilemmaCA;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
namespace PrisonersDilemmaCA.Tests
{
    [TestClass()]
    public class ComboBoxExtensionsTests
    {
        [TestMethod()]
        public void AddStrategiesTest()
        {
            List<Strategy> availableStrategies = new List<Strategy>();
            availableStrategies.Add(new StratTitForTat());
            availableStrategies.Add(new StratAlwaysDefect());
            availableStrategies.Add(new StratAlwaysCooperate());

            ComboBox comboBox = new ComboBox();
            comboBox.AddStrategies(availableStrategies);

            int i = 0;
            foreach (Strategy strat in availableStrategies)
            {
                Assert.AreEqual(strat.ToString(), comboBox.Items[i].ToString());
                i++;
            }
        }
    }
}
