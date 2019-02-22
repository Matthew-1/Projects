using System;
using System.Collections.Generic;
using DwarfsCity.DwarfContener;
using DwarfsCity.DwarfContener.DwarfEquipment;
using DwarfsCity.Reports;
using DwarfsCity.Tools;

namespace DwarfsCity
{
    public class Bank
    {

        public void ExchangeItemsToMoney(List<Dwarf> dwarfs)
        {
            decimal totalPayment = 0;
            Dictionary<Item, int> exchangedGoods = new Dictionary<Item, int>();
            foreach(Dwarf dwarf in dwarfs)
            {
                decimal payment = 0;
                for(int i=0;i<dwarf.Backpack.Items.Count;i++ )
                {
                    Item item = dwarf.Backpack.Items[i];
                    if (exchangedGoods.ContainsKey(item))
                        exchangedGoods[item] += 1;
                    else exchangedGoods[item] = 1;
                    decimal valueOfitem = Randomizer.ValueOfItem(item);
                    payment += valueOfitem;
                    dwarf.Backpack.Items.Remove(item);
                }
                dwarf.Backpack.Money += payment;
                totalPayment += payment;      
            }
            Logger.GetInstance().AddLog("BANK: ");
            foreach (Item item in exchangedGoods.Keys)
                Logger.GetInstance().AddLog($"Bank exchanged {exchangedGoods[item]} {item}");
            if(exchangedGoods.Keys.Count > 0)
                Logger.GetInstance().AddLog($"Total value of exchanged items: {Math.Round(totalPayment,2)}");
        }
    }
}