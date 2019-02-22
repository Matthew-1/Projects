using DwarfsCity.DwarfContener.DwarfEquipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Type = DwarfsCity.DwarfContener.Type;

namespace DwarfsCity.Tools
{
    public class Randomizer:IRandomizer
    {
        private static IRandomizer _randomizer = new Randomizer();

        public int GetChanceRatio(int min = 1,int max = 100)
        {
            Random rand = new Random();
            return rand.Next(min, max); 
        }

        public static bool IsDwarfBorn()
        {
            if (_randomizer.GetChanceRatio() == 5)
                return true;
            else
                return false;
        }

        public static Type TypeOfBornDwarf()
        {
            int probability = _randomizer.GetChanceRatio();

            if (Enumerable.Range(1, 33).Contains(probability))
                return Type.Father;
            else if (Enumerable.Range(33, 66).Contains(probability))
                return Type.Single;
            else if (Enumerable.Range(66, 98).Contains(probability))
                return Type.Lazy;
            else
                return Type.Saboteur;
        }

        public static decimal ValueOfItem(Item item)
        {
            int valueIncrease = _randomizer.GetChanceRatio(0,10);

            switch(item)
            {
                case Item.Mithril:
                    return 15 + valueIncrease;
                case Item.Gold:
                    return 10 + valueIncrease;
                case Item.Silver:
                    return 5 + valueIncrease;
                case Item.DirtyGold:
                    valueIncrease = _randomizer.GetChanceRatio(0, 4);
                    return 1 + valueIncrease;
            }

            return -1;
        }

        public static Item ItemDigged()
        {
            int probability = _randomizer.GetChanceRatio();

            if (Enumerable.Range(1, 5).Contains(probability))
                return Item.Mithril;
            else if (Enumerable.Range(5, 20).Contains(probability))
                return Item.Gold;
            else if (Enumerable.Range(20, 55).Contains(probability))
                return Item.Silver;
            else 
                return Item.DirtyGold;

        }

        public static int CountsOfDigging()
        {
            return _randomizer.GetChanceRatio(1, 3);
        }

    }
}
