using DwarfsCity.DwarfContener;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DwarfsCity.DwarfContener.DwarfEquipment;
using System;
using System.Collections.Generic;
using System.Text;
using DwarfsCity;

namespace DwarfCityTests
{
    [TestClass]
    public class BankTests
    {
        [TestMethod]
        public void ShouldChangeItemsToMoneyWhenDwarfComeToBank()
        {
            // given
            Dwarf dwarf = new Dwarf();
            dwarf.Backpack.Items.Add(Item.DirtyGold);
            List<Dwarf> dwarfs = new List<Dwarf>();
            dwarfs.Add(dwarf);
            Bank bank = new Bank();

            // when
            bank.ExchangeItemsToMoney(dwarfs);
            decimal actual = dwarf.Backpack.Money;
            // then
            Assert.IsTrue(actual >= 1 && actual <= 5);
        }
    }
}
