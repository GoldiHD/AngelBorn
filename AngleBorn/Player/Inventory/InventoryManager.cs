﻿using AngleBorn.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace AngelBorn.Player.Inventory
{
    class InventoryManager
    {
        public List<BaseItem> Inventory = new List<BaseItem>();
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
        }

    }
}