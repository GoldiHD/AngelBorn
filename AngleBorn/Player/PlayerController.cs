using AngelBorn.Player.Inventory;
using AngelBorn.Player.PlayerClass;
using AngelBorn.Player.RaceFolder;
using AngleBorn.Items;
using AngleBorn.Player;
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
        public InventoryManager inventory { get; private set; }
        public List<BaseItem> Equipment = new List<BaseItem>();
        public int Armor = 0;
        public CombatManager CBM { get; private set; }
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
            CBM = new CombatManager();
            Level = 1;
            inventory = new InventoryManager();
            Skills = new Stats(1, 1, 1, 1);
            Xp = 0;
        }

    }
}
