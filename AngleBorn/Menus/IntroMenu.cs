using AngelBorn.Grapihcs;
using AngelBorn.Grapihcs.MapGra;
using AngelBorn.Player.PlayerClass;
using AngelBorn.Player.RaceFolder;
using AngelBorn.Tools;
using AngleBorn.Menus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AngelBorn.Menus
{
    class IntroMenu
    {
        public void Run()
        {
            bool Return;
            CW.Clear();
            CW.WriteSlowNL("Welcome hero, what shall I call you by", 50);
            CW.WriteSlow("Name:",20);
            SingleTon.GetPlayerController().PlayerName = CW.Readline();
            CW.WriteSlowNL("", 20);
            CW.Clear();
            Return = false;
            do
            {
                CW.Clear();
                CW.WriteSlowNL("Now Please select a Race from this list", 20);
                for(int i = 0; i < PlayerRace.races.Count; i++)
                {
                    CW.WriteLine(PlayerRace.races[i].Name + " [" + PlayerRace.races[i].selectSign + "]");
                }
                char input = CW.ReadKey().KeyChar;
                for(int i = 0; i < PlayerRace.races.Count; i++)
                {
                    if(Char.ToLower(input) == Char.ToLower(PlayerRace.races[i].selectSign))
                    {
                        SingleTon.GetPlayerController().PlayerRace = PlayerRace.races[i];
                        SingleTon.GetPlayerController().PlayerRace.ApplyBonus();
                        Return = true;
                    }
                }
            } while (!Return);

            Return = false;

            do
            {
                CW.Clear();
                CW.WriteSlowNL("Now Please select a class from this list", 20);
                for (int i = 0; i < PlayerClass.playerClasses.Count; i++)
                {
                    CW.WriteLine(PlayerClass.playerClasses[i].Name + " [" + PlayerClass.playerClasses[i].selectSign + "]");
                }
                char input = CW.ReadKey().KeyChar;
                for (int i = 0; i < PlayerRace.races.Count; i++)
                {
                    if (Char.ToLower(input) == Char.ToLower(PlayerClass.playerClasses[i].selectSign))
                    {
                        SingleTon.GetPlayerController().PlayerClass = PlayerClass.playerClasses[i];
                        SingleTon.GetPlayerController().PlayerClass.ApplyBonus();
                        Return = true;
                    }
                }
            } while (!Return);

            List<char> LoadingSym = new List<char>{'|','/','-','\\'};
            int x = 0;

            while(true)
            {
                
                if (SingleTon.GetMapManagerInstance().MapCreators[0].IsAlive)
                {
                    Console.Clear();
                    if(x == LoadingSym.Count)
                    {
                        x = 0;
                    }
                    Console.Write("Loading..."+ LoadingSym[x]);
                    x++;
                }
                else
                {
                    break;
                }
                Thread.Sleep(200);
            }
            SingleTon.GetMapManagerInstance().SetPlayerSpawn(0);
            CW.Clear();
            CW.WriteSlowNL("Welcome to the adventure", 20);
            CW.WriteLine("Controls: \nArrows to move\n[S] to open stat block\n@ is villages\n[Ø]is a dungeon\nuse enter to enter villages or dungeons");
            CW.Write("Press anything to continue");
            CW.ReadKey();
            CW.Clear();
            new PlayManager().Run();

            //just temp to show the map and testing
            //MapDraw draw = new MapDraw();
            //Console.Clear();
            //draw.DrawMap();
            //new DrawStats().Draw();
            //Console.ReadKey();
        }
    }
}
