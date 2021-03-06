﻿using AngelBorn.Tools;
using AngleBorn.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace AngelBorn.Player.Inventory
{
    class InventoryManager
    {
        public List<BaseItem> Inventory { get; private set; }

        public ArmorItem HeadArmor;
        public ArmorItem ChestArmor;
        public ArmorItem PantsArmor;
        public ArmorItem ShoesArmor;
        public WeaponItem MainHand;
        public ArmorItem OffHand;
        private List<EquippableItem> GetAllEquipped
        {
            get
            {
                return new List<EquippableItem>() { HeadArmor, ChestArmor, PantsArmor, ShoesArmor, MainHand, OffHand };
            }
        }

    public bool CheckIfItemsIsEquipped(EquippableItem item)
        {
            foreach(EquippableItem element in GetAllEquipped)
            {
                if(element == item)
                {
                    return true;
                }
            }
            return false;
        }

        public int Gold { get; private set; }
        public void AddGold(int amount)
        {
            Gold += amount;
        }

        public bool SubtractGold(int amount)
        {
            if (Gold - amount >= 0)
            {
                Gold -= amount; ;
                return true;
            }
            else
            {
                return false;
            }
        }

        public InventoryManager()
        {
            Gold = 0;
            Inventory = new List<BaseItem>();
        }


    }
}
