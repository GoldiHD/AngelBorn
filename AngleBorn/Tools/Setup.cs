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
            SingleTon.GetMapManagerInstance();
            Console.Title = "Angelborn";
            Console.CursorVisible = false;
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            new PlayerClass();
            new PlayerRace();
            new IntroMenu().Run();
        }
    }
}
