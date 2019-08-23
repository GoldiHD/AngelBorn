using AngelBorn.Player.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngleBorn.World
{
    class BaseCharacters
    {
        public InventoryManager inventory { get; protected set; }
        public int Health { get; protected set; }
        public string Name { get; protected set; }
    }
}
