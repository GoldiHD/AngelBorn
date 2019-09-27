using AngelBorn.Menus;
using AngelBorn.Player.PlayerClass;
using AngelBorn.Player.RaceFolder;
using AngleBorn.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace AngelBorn.Tools
{
    class Setup
    {
        public void Start()
        {
            SingleTon.SetRandomKey();
            SingleTon.GetMapManagerInstance();
            SingleTon.GetRandomNum(0, 2);
            SingleTon.GetItemManager().SetupItems();
            StartingEquipment();
            Console.Title = "Angelborn";
            Console.CursorVisible = false;
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            new PlayerClass();
            new PlayerRace();
            new IntroMenu().Run();
        }

        private void StartingEquipment()
        {
            SingleTon.GetPlayerController().Inventory.Inventory.Add(SingleTon.GetItemManager().AllItems.Find(x => x.name == "Wooden Stick"));
            if(SingleTon.GetPlayerController().Inventory.Inventory[0] is WeaponItem weaponItem)
            {
                weaponItem.Equip();
            }
        }
    }
}
