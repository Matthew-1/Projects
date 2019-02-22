using DwarfsCity.DwarfContener;
using DwarfsCity.Reports;
using DwarfsCity.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using Type = DwarfsCity.DwarfContener.Type;

namespace DwarfsCity
{
    public class Hospital
    {

        public void GiveBirthToDwarf(List<Dwarf> dwarfs)
        {
            Logger.GetInstance().AddLog("HOSPITAL:");

            if (Randomizer.IsDwarfBorn())
            {
                dwarfs.Add(DwarfFactory.CreateARandomDwarf_RandomAttribute());
                Logger.GetInstance().AddLog($"New {dwarfs.Last().Attribute} dwarf was born!");
            }

            Logger.GetInstance().AddLog("No dwarf was born");


        }

        public void InitialNumberOfDwarfs(List<Dwarf> dwarfs,int initalNumberOfDwarfs = 0)
        {
            var listOfDwarfs = DwarfFactory.CreateMultipleRandomDwarfs_RandomAttributes(initalNumberOfDwarfs);

            foreach (var dwarf in listOfDwarfs)
            {
                dwarfs.Add(dwarf);
            }
        }

    }
}