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
            AllItems.Add(new WeaponItem("Wooden Stick", ItemType.Weapons, 2, true, 2, 1f));
            //Armor

            //Consumable

            //Trash
        }
    }
}
