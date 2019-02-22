using DwarfsCity.DwarfContener;
using DwarfsCity.Reports;
using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfsCity.MineContener
{
    public class Shaft
    {
        public List<Dwarf> dwarfs { get; set; } = new List<Dwarf>();
        public bool Exist { get; set; } = true;


        public delegate void ShaftExplodedEvendHandler(object o, ShaftExplodedEventArgs e);
        public event ShaftExplodedEvendHandler ShaftExploded;

        public virtual void OnShaftExploded()
        {
            if (ShaftExploded != null && Exist == false)
            {
                ShaftExploded(this, new ShaftExplodedEventArgs() { KilledDwarfs = dwarfs });
            }
        }

        public void ChangeShaftExistStatusToDestroyed()
        {
            Exist = false;
            OnShaftExploded();
        }

    }
}
