using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DwarfsCity.DwarfContener;
using DwarfsCity;
using DwarfsCity.ShopContener;
using DwarfsCity.DwarfContener.DwarfEquipment;

namespace DwarfCityTests
{
    [TestClass]
    public class ShopTests
    {
        
        [TestMethod]
        public void ShouldDwarfPayHalfMoneyWhenDwarfTypeIsFatherOrSingle()
        {
            //given
            List<Dwarf> dwarfs = new List<Dwarf>();
            Dwarf dwarfFather = new Dwarf();
            dwarfFather.Attribute = DwarfsCity.DwarfContener.Type.Father;
            dwarfFather.Backpack.Money = 1000;
            Dwarf dwarfSingle = new Dwarf();
            dwarfSingle.Attribute = DwarfsCity.DwarfContener.Type.Single;
            dwarfSingle.Backpack.Money = 1000;
            dwarfs.Add(dwarfFather);
            dwarfs.Add(dwarfSingle);
            Shop shop = new Shop();

            decimal expectedFatherMoney = dwarfFather.Backpack.Money / 2;
            decimal expectedSingleMoney = dwarfSingle.Backpack.Money / 2;
            //when
            shop.PerformShopping(dwarfs);

            // then
            decimal actualFatherMoney = dwarfFather.Backpack.Money;
            decimal actualSingleMoney = dwarfSingle.Backpack.Money;
            Assert.AreEqual(expectedFatherMoney, actualFatherMoney);
            Assert.AreEqual(expectedSingleMoney, actualSingleMoney);

        }
    }
}
