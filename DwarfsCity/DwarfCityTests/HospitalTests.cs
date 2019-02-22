using System;
using System.Collections.Generic;
using System.Text;
using DwarfsCity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DwarfCityTests
{
    [TestClass]
    public class HospitalTests
    {
        [TestMethod]
        public void GiveBirthToNewDwarfInInitialiseRun_New10DwarfsInListOfDwarfs()
        {
            //given
            City city = new City();
            Hospital hospital = new Hospital();

            //when
            hospital.InitialNumberOfDwarfs(city.GetDwarfs(), 10);

            //then
            Assert.AreEqual(10, city.GetDwarfs().Count);
  
        }


    }
}
