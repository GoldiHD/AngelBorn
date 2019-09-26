using AngelBorn.Player.Abilities;
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
        public List<BaseAbilites> AquiredAbilites = new List<BaseAbilites>();
        public int Level { get; private set; }
        public int Xp { get; private set; }
        public int NextLevelXP { get; private set; }
        public Stats Skills { get; private set; }
        private string _PlayerName;
        public InventoryManager Inventory { get; private set; }
        public int Armor = 0;
        public CombatManager CBM { get; private set; }

        public int Skillpoint { get; private set; }
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

        public void LevelUp()
        {
            Xp = 0;
            NextLevelXP = (int)(((float)Level * 1.25f) * 2) + 10;
            Level++;
        }

        public PlayerController()
        {
            CBM = new CombatManager();
            Level = 1;
            Inventory = new InventoryManager();
            Skills = new Stats(1, 1, 1, 1);
            Xp = 0;
            NextLevelXP = (int)(((float)Level * 1.25f) * 2) + 10;
        }

    }
}