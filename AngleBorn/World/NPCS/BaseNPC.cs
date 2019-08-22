using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngleBorn.World.NPCS
{
    class BaseNPC : BaseCharacters
    {
        public string name { get; private set; }
        public int Health { get; private set; }

        public BaseNPC(string _name, int health, bool Trade)
        {
            name = _name;
            Health = health;
           
        }

        public BaseNPC() { }

    }
}
