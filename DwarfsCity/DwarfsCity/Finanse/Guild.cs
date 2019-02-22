using DwarfsCity.DwarfContener;
using DwarfsCity.Reports;
using System;
using System.Collections.Generic;

namespace DwarfsCity
{
    public class Guild
    {
        public decimal GeneralGuildFunds { get; set; }
        public decimal TheSumOfTaxesOnOneDay { get; set; }     

        public void GetTaxesofAllDwarfs(List<Dwarf> dwarfs)
        {
            TheSumOfTaxesOnOneDay = 0;
            foreach (Dwarf dwarf in dwarfs)
            {
                decimal TaxesOfGuild = TaxesCalculator(dwarf);
                EarningsCalculator(dwarf, TaxesOfGuild);              
            }            
            ReportGuild();
        }

        private void EarningsCalculator(Dwarf dwarf,decimal taxes)
        {
                decimal EarnedMoney = dwarf.Backpack.Money - taxes;
                dwarf.Backpack.Money = EarnedMoney;
        }

        private decimal TaxesCalculator(Dwarf dwarf)
        {           
            decimal taxes = 0.20m * dwarf.Backpack.Money;
            TheSumOfTaxesOnOneDay += taxes;
            GeneralGuildFunds += TheSumOfTaxesOnOneDay;
            return taxes;
        }

        private void ReportGuild()
        {
             GiveReport("Today all dwarfs pay " + Math.Round(TheSumOfTaxesOnOneDay,2) + " taxes. \nThe current state of the guild account is " + Math.Round(GeneralGuildFunds,2) + ".");    
        }

        public void GiveReport(string message)
        {
            Logger.GetInstance().AddLog("GUILD:");
            Logger.GetInstance().AddLog(message);
        }
    }
   
}