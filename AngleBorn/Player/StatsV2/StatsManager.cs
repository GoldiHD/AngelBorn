using AngleBorn.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngleBorn.Player.StatsV2
{
    class StatsManager
    {
        public StatsBase temo = new StatsBase();
        StatsManager()
        {
            temo.Modifers.Add(new StatsModifer() { src = new WeaponItem("", "", ItemType.Weapons, 20, false, 0) });
        }
    }
}
