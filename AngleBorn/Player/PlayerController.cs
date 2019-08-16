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
        public int Level = 1;
        public Stats Skills { get; private set; }
        private string _PlayerName;
        public PlayerInventory inventory;
        public string PlayerName
        {
            get { return _PlayerName; }
            set
            {
                if(_PlayerName == null)
                {
                    _PlayerName = value;
                }
            }
        }

        public PlayerController()
        {
            inventory = new PlayerInventory();
            Skills = new Stats(1,1,1,1);
        }

    }
}
