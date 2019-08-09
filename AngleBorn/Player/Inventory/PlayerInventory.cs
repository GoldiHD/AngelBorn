using System;
using System.Collections.Generic;
using System.Text;

namespace AngelBorn.Player.Inventory
{
    class PlayerInventory
    {
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

        public PlayerInventory()
        {
            Gold = 0;
        }

    }
}
