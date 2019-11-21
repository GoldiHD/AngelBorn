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
            AllItems.Add(new WeaponItem("Wooden Stick","A simple stick not worth much but might be enough", ItemType.Weapons, 2, true, 2));
            //Armor
            AllItems.Add(new ArmorItem("Leather Breastplate","A solid peice harden leather covering you chest", ItemType.Armor, 20, false, 2, ArmorLocation.Chest));
            AllItems.Add(new ArmorItem("Leather Leggings","", ItemType.Armor, 15, false, 2, ArmorLocation.Legs));
            AllItems.Add(new ArmorItem("Wooden Buckler Shield","A simple buckler", ItemType.Shield, 15, false, 1, ArmorLocation.Offhand));
            AllItems.Add(new ArmorItem("Wool Shirt", "A simple wool shirt with a few holes", ItemType.Armor, 2, false, 1, ArmorLocation.Chest));
            //Consumable
            
            //Trash
        }
    }
}
