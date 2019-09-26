using AngelBorn.Menus;
using AngelBorn.Player.PlayerClass;
using AngelBorn.Player.RaceFolder;
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
            Console.Title = "Angelborn";
            Console.CursorVisible = false;
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            new PlayerClass();
            new PlayerRace();
            new IntroMenu().Run();
        }
    }
}
