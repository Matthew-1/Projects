using DwarfsCity;
using DwarfsCity.DwarfContener;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfCityTests
{
    [TestClass]
    public class GuildTests
    {
        [TestMethod]
        public void ShouldReturnTaxesForOneDwarf()
        {
            List<Dwarf> Dwarfs = new List<Dwarf>();
            Dwarfs.Add(new Dwarf());
            Dwarfs[0].Backpack.Money = 5;
            Guild guild = new Guild();
            guild.GetTaxesofAllDwarfs(Dwarfs);
            decimal expected = 1;
            decimal result = guild.TheSumOfTaxesOnOneDay;           
            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        public void ShouldReturnDwarfMoneyAfterTaxes()
        {
            List<Dwarf> Dwarfs = new List<Dwarf>();
            Dwarfs.Add(new Dwarf());
            Dwarfs[0].Backpack.Money = 5;
            Guild guild = new Guild();
            decimal expected = 4;          
            guild.GetTaxesofAllDwarfs(Dwarfs);
            decimal result = Dwarfs[0].Backpack.Money;
            Assert.AreEqual(expected, result);

        }
    }
}
