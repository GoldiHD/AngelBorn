using AngelBorn.Player.Inventory;
using AngelBorn.Player.PlayerClass;
using AngelBorn.Player.RaceFolder;
using System;
using System.Collections.Generic;
using System.Text;

namespace AngelBorn.Player
{
    class PlayerController
    {
        public int Steps;
        public BaseClass PlayerClass;
        public Race PlayerRace;
        public int Level { get; private set; }
        public int Xp { get; private set; }
        public Stats Skills { get; private set; }
        private string _PlayerName;
        public InventoryManager inventory;
        public string PlayerName
        {
            get { return _PlayerName; }
            set
            {
                if (_PlayerName == null)
                {
                    _PlayerName = value;
                }
            }
        }

        public void AddXP(int amount)
        {
            if(amount > 0)
            {
                Xp += amount;
            }
        }

        public PlayerController()
        {
            Level = 1;
            inventory = new InventoryManager();
            Skills = new Stats(1, 1, 1, 1);
            Xp = 0;
        }

    }
}
