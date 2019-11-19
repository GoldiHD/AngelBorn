using AngelBorn.Grapihcs;
using AngelBorn.Grapihcs.MapGra;
using AngelBorn.Player.PlayerClass;
using AngelBorn.Player.RaceFolder;
using AngelBorn.Tools;
using AngelBorn.World;
using AngleBorn.Grapihcs;
using AngleBorn.Menus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AngelBorn.Menus
{
    class IntroMenu
    {
        public static bool test = true;

        public void Run()
        {
            if (test)
            {
                SingleTon.GetPlayerController().PlayerClass = PlayerClass.playerClasses[0];
                SingleTon.GetPlayerController().PlayerRace = PlayerRace.races[0];
                SingleTon.GetPlayerController().PlayerName = "";
                List<char> LoadingSym = new List<char> { '|', '/', '-', '\\' };
                int x = 0;
                Console.Clear();
                while (true)
                {

                    if (SingleTon.GetMapManagerInstance().MapCreators[0].IsAlive)
                    {

                        if (x == LoadingSym.Count)
                        {
                            x = 0;
                        }
                        CW.Write("Loading..." + LoadingSym[x],0, 0);
                        x++;
                    }
                    else
                    {
                        break;
                    }
                    Thread.Sleep(200);
                }
                new PlayManager().Run();
            }
            else
            {
                bool Return;
                CW.Clear();
                CW.WriteSlowNL("You wake up in darkness, the last thing you remember was your life slowly dissapering from your body after saving your best friend from getting crushed to death by a car", 20);
                CW.WriteSlowNL("Even with the light faded there is still something out there", 20);
                CW.WriteSlowNL("Suddenly a text appere in front of you...", 20);
                CW.ReadKey();
                CW.Clear();
                CW.WriteSlowNL("You unlocked \"Adventure\" would you like to continue on this path [y/n]\nSaying no will resualt in your heart stopping in 0.2 seconds", 20);
                Return = false;
                while (!Return)
                {
                    switch (CW.ReadKey().KeyChar)
                    {
                        case 'Y':
                        case 'y':
                            Return = true;
                            break;

                        case 'n':
                        case 'N':
                            Environment.Exit(0);
                            break;

                        default:
                            CW.Clear();
                            CW.WriteLine("You unlocked \"Adventure\" would you like to continue on this path [y/n]\nSaying no will resualt in your heart stopping in 0.2 seconds");
                            break;
                    }
                }
                CW.Clear();
                CW.WriteSlowNL("Welcome hero, what shall I call you by", 20);
                CW.WriteSlow("Name:", 20);
                SingleTon.GetPlayerController().PlayerName = CW.Readline();
                CW.WriteSlowNL("", 20);
                CW.Clear();
                Return = false;
                do
                {
                    CW.Clear();
                    CW.WriteSlowNL("Now Please select a Race from this list", 20);
                    for (int i = 0; i < PlayerRace.races.Count; i++)
                    {
                        CW.WriteLine(PlayerRace.races[i].Name + " [" + PlayerRace.races[i].selectSign + "]");
                    }
                    char input = CW.ReadKey().KeyChar;
                    for (int i = 0; i < PlayerRace.races.Count; i++)
                    {
                        if (Char.ToLower(input) == Char.ToLower(PlayerRace.races[i].selectSign))
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
                    for (int i = 0; i < PlayerClass.playerClasses.Count; i++)
                    {

                        if (Char.ToLower(input) == Char.ToLower(PlayerClass.playerClasses[i].selectSign))
                        {
                            SingleTon.GetPlayerController().PlayerClass = PlayerClass.playerClasses[i];
                            SingleTon.GetPlayerController().PlayerClass.ApplyBonus();
                            Return = true;
                        }
                    }
                } while (!Return);

                List<char> LoadingSym = new List<char> { '|', '/', '-', '\\' };
                int x = 0;

                while (true)
                {

                    if (SingleTon.GetMapManagerInstance().MapCreators[0].IsAlive)
                    {
                        Console.Clear();
                        if (x == LoadingSym.Count)
                        {
                            x = 0;
                        }
                        Console.Write("Loading..." + LoadingSym[x]);
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
                CW.WriteLine("Controls: \nArrows to move\n[S] to open stat block\n@ is villages\n[Ø]is a dungeon\n[Enter] to enter villages or dungeons\n[X] is people\n[Escape] to exit a dungeon or villager");
                CW.Write("Press anything to continue");
                CW.ReadKey();
                CW.Clear();
                new PlayManager().Run();

            }
        }
    }
}
