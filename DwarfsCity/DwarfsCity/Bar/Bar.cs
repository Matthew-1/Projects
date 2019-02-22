using DwarfsCity.DwarfContener.DwarfEquipment;
using DwarfsCity;
using System;
using System.Collections.Generic;
using System.Linq;
using DwarfsCity.DwarfContener;
using DwarfsCity.Reports;
using DwarfsCity.UI;

namespace DwarfsCity
{
    public class Bar
    {
        public int SupplyofFood { get; set; } = 200;    
        public int GivenFoodToDwarfsDuringOneDay { get; set; }
        DisplayReport ui = new DisplayReport();
        public void GiveAFoodToDwarfs(List<Dwarf> Dwarfs) 
        {           
            GivenFoodToDwarfsDuringOneDay = AmountOfFoodGiven(Dwarfs.Count);
            SupplyofFood = SupplyofFood - Dwarfs.Count;
            Logger.GetInstance().AddLog("BAR:");
            ReportBar();          
        }

        private int AmountOfFoodGiven(int DwarfsCount)
        {
            if (DwarfsCount > SupplyofFood)
                return (DwarfsCount - SupplyofFood);
            else
                return DwarfsCount;
        }

        private void ReportBar()
        {
            if (SupplyofFood < 0)
            {
                ThereIsNoMoreFood();
            }
            else if (SupplyofFood <= 10)
            {
                ThereIsADelivery();
            }
            else
                AllDwarfsEatADinner();        }

        private void AllDwarfsEatADinner()
        {
            GiveReport("Today " + GivenFoodToDwarfsDuringOneDay + " dwarfs get a portion of food. Actual amount of supply in Bar: " + SupplyofFood + ".");
        }

        private void ThereIsADelivery()
        {
            this.SupplyofFood += 30;
            GiveReport("Today " + GivenFoodToDwarfsDuringOneDay + " dwarfs get a portion of food. There is a delivery food to bar. Actual amount of supply in Bar: " + SupplyofFood + ".");

        }
        private void ThereIsNoMoreFood()
        {
            GiveReport("There is no more food in bar. Only " + GivenFoodToDwarfsDuringOneDay + " dwarfs get a portion of food. \nThe simulation is over.");
            ui.Display(Logger.GetInstance().GetLogs());
            City.TheEndOfSimulation();
        }

        public void GiveReport(string message)
        {
            Logger.GetInstance().AddLog(message);
        }
    }
}