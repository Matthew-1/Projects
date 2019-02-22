using DwarfsCity.DwarfContener;
using System.Collections.Generic;

namespace DwarfsCity.MineContener
{
    public interface IForeman
    {
        void SendDwarfsToShaft(List<Dwarf> dwarfs, Shaft shaft);
    }
}