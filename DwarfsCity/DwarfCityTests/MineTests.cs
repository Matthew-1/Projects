using DwarfsCity;
using DwarfsCity.DwarfContener;
using DwarfsCity.MineContener;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Type = DwarfsCity.DwarfContener.Type;

namespace DwarfCityTests
{
    [TestClass]
    public class MineTests
    {
        [TestMethod]
        public void ShaftShouldHaveExistAttrEqualsFalseWhenOnTheShaftIsSaboteur()
        {
            //Given
            List<Dwarf> saboteurDwarf = new List<Dwarf>() { new Dwarf() { Attribute = DwarfsCity.DwarfContener.Type.Saboteur } };
            Shaft shaft = new Shaft();

            Foreaman foreaman = new Foreaman();


            //When
            foreaman.SendDwarfsToShaft(saboteurDwarf, shaft);

            //Then
            Assert.AreEqual(shaft.Exist, false);

        }

        [TestMethod]
        public void ShouldReturn7AliveDwarfsWhenIsSended12DwarfsAnd8DwarfIsSabouteur()
        {
            //Given
            List<Dwarf> dwarfs = new List<Dwarf>();
            Mine mine = new Mine();
            Hospital hospital = new Hospital();
            hospital.InitialNumberOfDwarfs(dwarfs, 11);
            dwarfs.Insert(3, DwarfFactory.CreateADwarf(Type.Saboteur));

            //When
            dwarfs = mine.StartWorking(dwarfs);

            //Then
            Assert.AreEqual(dwarfs.Count, 7);

        }

        [TestMethod]
        public void WhenInShaftIsSaboteurGravesShouldHaveAtLeastOneKilledDwarf()
        {
            //Given
            List<Dwarf> dwarfs = new List<Dwarf>();
            Mine mine = new Mine();
            Hospital hospital = new Hospital();
            hospital.InitialNumberOfDwarfs(dwarfs, 11);

            dwarfs.Insert(8, new Dwarf() { Attribute = DwarfsCity.DwarfContener.Type.Saboteur });

            int result = 0;

            //When
            dwarfs = mine.StartWorking(dwarfs);

            result = Cementary.graves.Count;

            //Then

            Assert.IsTrue(result >= 1);

        }
    }
}
