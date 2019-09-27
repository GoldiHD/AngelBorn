using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngleBorn.Items
{
    class ItemManager
    {
        public List<BaseItem> AllItems { get; protected set; }
        public ItemManager()
        {
            AllItems = new List<BaseItem>();
        }

        public void SetupItems()
        {
            //Items

            //Weapons
            AllItems.Add(new WeaponItem("Wooden Stick", ItemType.Weapons, 2, true, 2, 100));
            //Armor
            AllItems.Add(new ArmorItem("Leather Breastplate", ItemType.Armor, 20, false, 2, ArmorLocation.Chest));
            AllItems.Add(new ArmorItem("Leather Leggings", ItemType.Armor, 15, false, 2, ArmorLocation.Legs));
            AllItems.Add(new ArmorItem("Wooden Buckler Shield", ItemType.Shield, 15, false, 1, ArmorLocation.Offhand));
            //Consumable

            //Trash
        }
    }
}
