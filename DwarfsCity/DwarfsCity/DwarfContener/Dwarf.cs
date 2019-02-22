using DwarfsCity.DwarfContener.DwarfEquipment;
using DwarfsCity.Reports;
using DwarfsCity.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DwarfsCity.DwarfContener
{
    public class Dwarf
    {
        //Field
        public Backpack Backpack = new Backpack();
        public Type Attribute { get; set; }
        

        public void AddItemsToBackpack(Item item)
        {
            Backpack.Items.Add(item);
        }

        public List<Item> GiveItemsFromBackpack()
        {
            return Backpack.Items;    
        }

    
        public void SetAttribute(Type attribute)
        {
            Attribute = attribute;
        }

        public int Digging()
        {
            int extractionsProducts = 0;
            for (int i = 0; i < Randomizer.CountsOfDigging(); i++)
            {
                //Digging minerals by ratio  -> 5% mithril, 15% gold 35% silver, 45% dirty gold
                var toDigging = Randomizer.ItemDigged();
                Backpack.Items.Add(toDigging);
                extractionsProducts++;
            }

            return extractionsProducts;
        }
    }
}
