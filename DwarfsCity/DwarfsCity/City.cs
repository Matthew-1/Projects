using DwarfsCity.DwarfContener;
using DwarfsCity.MineContener;
using DwarfsCity.Reports;
using DwarfsCity.ShopContener;
using DwarfsCity.UI;
using System;
using System.Collections.Generic;
using System.Text;
using Type = DwarfsCity.DwarfContener.Type;

namespace DwarfsCity
{
    public class City
    {
        List<Dwarf> dwarfs = new List<Dwarf>();
        DisplayReport ui = new DisplayReport();
        //Start simulation
        public void Run()
        {
            //Create new instance hospital, mine, bank, guild, bar, shop, cementary
            Hospital hospital = new Hospital();
            Mine mine = new Mine();
            Bank bank = new Bank();
            Guild guild = new Guild();
            Bar bar = new Bar();
            Shop shop = new Shop();
            Cementary cementary = new Cementary();                      
            hospital.InitialNumberOfDwarfs(dwarfs, 10);


            for (int i = 0; i < 30; i++)
            {
                //Dwarfs go to minning -> return still alive dwarfs within resources
                Logger.GetInstance().AddLog($"DAY: {i + 1}");
                hospital.GiveBirthToDwarf(dwarfs);
                dwarfs = mine.StartWorking(dwarfs);                           
                bank.ExchangeItemsToMoney(dwarfs);
                guild.GetTaxesofAllDwarfs(dwarfs);
                bar.GiveAFoodToDwarfs(dwarfs);                    
                shop.PerformShopping(dwarfs);
                Logger.GetInstance().AddLog("");
            }
            ui.Display(Logger.GetInstance().GetLogs());
            Console.ReadKey();
        }

        public static void TheEndOfSimulation()
        {
            Console.ReadKey();
            Environment.Exit(0);
        }

        public List<Dwarf> GetDwarfs()
        {            
            return dwarfs;
        }        
    }
}
