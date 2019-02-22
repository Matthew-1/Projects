using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfsCity.DwarfContener.DwarfEquipment
{
    public class Backpack
    {
        //Fields
        public decimal Money { get; set; }
        public List<Item> Items { get; set; }

        public Backpack()
        {
            Money = 0;
            Items = new List<Item>();
        }

    }
}
