using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DwarfsCity.DwarfContener.DwarfEquipment;
using DwarfsCity.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DwarfCityTests
{
    [TestClass]
    public class RandomizerTests
    {
        [TestMethod]
        public void ProbabilityOfDigginng1_3Times()
        {
            //given, when, then
            int result = Randomizer.CountsOfDigging();

            Assert.IsTrue(result >=1 && result<=3);
        }

        [TestMethod]
        public void ValueOfDiggedItems_Between15and25()
        {
            //given
            Item mithril = Item.Mithril;
            Item gold = Item.Gold;
            Item silver = Item.Silver;
            Item dirtyGold = Item.DirtyGold;

            //when, then
            decimal result = Randomizer.ValueOfItem(mithril);
            Assert.IsTrue(result >= 15 && result <= 25);

            //when, then
            result = Randomizer.ValueOfItem(gold);
            Assert.IsTrue(result >= 10 && result <= 20);

            //when, then
            result = Randomizer.ValueOfItem(silver);
            Assert.IsTrue(result >= 5 && result <= 15);

            //when, then
            result = Randomizer.ValueOfItem(dirtyGold);
            Assert.IsTrue(result >= 1 && result <= 10);
        }

    }
}
