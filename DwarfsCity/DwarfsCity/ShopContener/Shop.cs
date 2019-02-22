using DwarfsCity.DwarfContener;
using DwarfsCity.Reports;
using System.Collections.Generic;
namespace DwarfsCity.ShopContener
{
    public class Shop
    {
        public void PerformShopping(List<Dwarf> dwarfs)
        {
            decimal totalCostOfSales = 0;
            int fathers = 0;
            int singles = 0;
            foreach(Dwarf dwarf in dwarfs)
            {
                if(dwarf.Attribute == Type.Father || dwarf.Attribute == Type.Single)
                {
                    decimal price = dwarf.Backpack.Money / 2;
                    dwarf.Backpack.Money /= 2;
                    totalCostOfSales += price;
                    if (dwarf.Attribute == Type.Father) fathers++;
                    else singles++;
                }
            }
            string message = $"Dwarfs spent {System.Math.Round(totalCostOfSales,2)}. Alcohol purchased: {singles} , Food purchased: {fathers}";
            Logger.GetInstance().AddLog("SHOP:");
            Logger.GetInstance().AddLog(message);
        }
       
    }
}