using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngleBorn.Items
{
    class BaseItem
    {

        public bool UseInCombat { get; protected set; }
        public string name { get; protected set; }
        public int Id { get; protected set; }
        public int Value { get; protected set; }
        public bool Sellable { get; protected set; }
        public ItemType itemType { get; protected set; }
    }

    public enum ItemType
    {
        Weapons, Armor, Consumable, Trash, Shield
    }
}
