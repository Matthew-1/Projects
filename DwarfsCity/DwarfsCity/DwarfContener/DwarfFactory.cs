using DwarfsCity.DwarfContener.DwarfEquipment;
using DwarfsCity.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfsCity.DwarfContener
{
    public class DwarfFactory
    {
        public static Dwarf CreateADwarf(Type attribute, decimal money = 0, List<Item> items = null)
        {
            var newDwarf = new Dwarf() { Attribute = attribute };

            newDwarf.Backpack.Items = items;
            newDwarf.Backpack.Money = money;

            if (items == null)
                newDwarf.Backpack.Items = new List<Item>();

            return newDwarf;
        }

        public static List<Dwarf> CreateMultipleDwarfs(int numberOfDwarfs, Type attribute, 
            decimal money = 0, List<Item> items = null)
        {
            var listOfDwarfs = new List<Dwarf>();

            for (int i = 0; i < numberOfDwarfs; i++)
            {
                listOfDwarfs.Add(CreateADwarf(attribute, money, items));
            }

            return listOfDwarfs;
        }

        public static Dwarf CreateARandomDwarf_RandomAttribute()
        {
            Type attribute = Randomizer.TypeOfBornDwarf();
            Dwarf newBornDwarf = CreateADwarf(attribute);

            return newBornDwarf;
        }

        public static List<Dwarf> CreateMultipleRandomDwarfs_RandomAttributes(int numberOfDwarfs)
        {
            var listOfDwarfs = new List<Dwarf>();

            for (int i = 0; i < numberOfDwarfs; i++)
            {
                listOfDwarfs.Add(CreateARandomDwarf_RandomAttribute());
            }

            return listOfDwarfs;
        }
    }
}
