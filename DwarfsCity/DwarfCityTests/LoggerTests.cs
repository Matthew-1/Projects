using DwarfsCity.Reports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfCityTests
{
    [TestClass]
    public class LoggerTests
    {
        [TestMethod]
        public void ShouldReturnLogsWhenLogsExist()
        {
            // given
            Logger logger = Logger.GetInstance();
            logger.ClearData();
            string log = "Dwarf Father bought Alcohol";
            List<string> expectedLogs = new List<string>() { log };
            
            // when
            logger.AddLog(log);

            // then
            var actualLogs = logger.GetLogs();
            CollectionAssert.AreEqual(expectedLogs, actualLogs);



        }
    }
}
