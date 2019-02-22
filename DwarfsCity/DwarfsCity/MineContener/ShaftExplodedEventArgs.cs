using DwarfsCity.DwarfContener;
using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfsCity.MineContener
{
    public class ShaftExplodedEventArgs: EventArgs
    {
        public List<Dwarf> KilledDwarfs { get; set; }
    }
}
