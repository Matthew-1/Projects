using System;
using System.Collections.Generic;
using System.Text;
using DwarfsCity.DwarfContener;
using DwarfsCity.DwarfContener.DwarfEquipment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Type = DwarfsCity.DwarfContener.Type;

namespace DwarfCityTests
{
    [TestClass]
    public class DwarfFactoryTests
    {
        [TestMethod]
        public void CreateOneDwarfOfEachType_FatherSonLazySaboteur()
        {
            var father = DwarfFactory.CreateADwarf(Type.Father);
            var single = DwarfFactory.CreateADwarf(Type.Single);
            var lazy = DwarfFactory.CreateADwarf(Type.Lazy);
            var saboteur = DwarfFactory.CreateADwarf(Type.Saboteur);

            Assert.IsTrue(father.Attribute == Type.Father);
            Assert.IsTrue(single.Attribute == Type.Single);
            Assert.IsTrue(lazy.Attribute == Type.Lazy);
            Assert.IsTrue(saboteur.Attribute == Type.Saboteur);

        }

        [TestMethod]
        public void CreateADwarfWith10MoneyAndMithrilInBackpack()
        {
            
            var dwarf = DwarfFactory.CreateADwarf(Type.Father,money:10,items:new List<Item>() { Item.Mithril });
            

            Assert.IsTrue(dwarf.Attribute == Type.Father);
            Assert.IsTrue(dwarf.Backpack.Money == 10);
            Assert.IsTrue(dwarf.Backpack.Items[0] == Item.Mithril);
           
        }

        [TestMethod]
        public void Create10DwarfsOfFatherType()
        {
 
            var fathers = DwarfFactory.CreateMultipleDwarfs(numberOfDwarfs: 10, attribute: Type.Father);
            

            Assert.IsTrue(fathers[0].Attribute == Type.Father);
            Assert.IsTrue(fathers.Count == 10);
            

        }
    }
}
