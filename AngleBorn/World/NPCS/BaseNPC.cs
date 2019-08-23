using AngelBorn.Player.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngleBorn.World.NPCS
{
    class BaseNPC : BaseCharacters
    {
        public bool Trade;

        public BaseNPC(string _name, int health, bool _trade)
        {
            Name = _name;
            Health = health;
            Trade = _trade;
        }

        public BaseNPC() { }

    }
}
