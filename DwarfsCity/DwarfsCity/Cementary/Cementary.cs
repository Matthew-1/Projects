using DwarfsCity.DwarfContener;
using DwarfsCity.MineContener;
using DwarfsCity.Reports;
using System;
using System.Collections.Generic;

namespace DwarfsCity
{
    public class Cementary
    {
        public static List<Dwarf> graves { get; private set; } = new List<Dwarf>();

        private static void AddKilledDwarfsToGraves(List<Dwarf> killedDwarfs)
        {
            foreach (var dwarf in killedDwarfs)
            {
                graves.Add(dwarf);
            }
        }

        public static void OnShaftExploded(object o, ShaftExplodedEventArgs dwarfs)
        {
            if (dwarfs.KilledDwarfs.Count == 0) return;
            Logger.GetInstance().AddLog("CEMENTARY:");

            AddKilledDwarfsToGraves(dwarfs.KilledDwarfs);

            Logger.GetInstance().AddLog("The mine exploded! The death Dwarfs: ");
            foreach (var killedDwarf in dwarfs.KilledDwarfs)
            {
                Logger.GetInstance().AddLog(killedDwarf.Attribute.ToString());

            }

            dwarfs.KilledDwarfs.Clear();
        }
    }
}