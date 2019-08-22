using AngelBorn.Player.Inventory;
using AngelBorn.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngleBorn.World.NPCS
{
    class TileNPC : BaseTile
    {
        public string name { get; private set; }
        public int health { get; private set; }
        public bool Tradable { get; private set; }
        public InventoryManager inventory { get; private set; }

        public TileNPC(string _name, bool tradable, Cord _pos)
        {
            MyType = TileType.NPC;
            TileName = _name;
            Tradable = tradable;
            name = _name;
            Pos = _pos;
            inventory = new InventoryManager();
        }
    }
}
