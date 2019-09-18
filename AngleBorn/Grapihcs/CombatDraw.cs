using AngelBorn.Tools;
using AngelBorn.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngleBorn.Grapihcs
{
    class CombatDraw
    {
        public static int IndexMenu;
        private string[] Cor = { "╔", "╗", "╝", "╚" };
        private string Side = "║";
        private string TopBot = "═";
        private string TopLine = "";
        private string BottomLine = "";
        private int LineHeightPos;
        public static ActionMenus MenuState = ActionMenus.Main;
        private static Cord ActionMenuStart;
        private static Cord LogPosStart;
        private static Cord StatsPosStart;
        private Cord Pos;
        public static List<string> ActiveMenuList;
        private List<string> MenuTextOptions = new List<string> { "Attack", "Items", "Magic", "Flee" };

        public void Draw(Cord _Pos)
        {
            CW.Clear();
            Pos = _Pos;
            LineHeightPos = 0;
            string BigLine = Side + " Round: " + SingleTon.GetPlayerController().CBM.Rounds + " " + Side;
            CW.Write(FilloutString(BigLine, true), Pos.X, Pos.Y + LineHeightPos);
            LineHeightPos++;
            CW.Write(BigLine, Pos.X, Pos.Y + LineHeightPos);
            LineHeightPos++;
            CW.Write(FilloutString(BigLine, false), Pos.X, Pos.Y + LineHeightPos);
            LineHeightPos++;
            BigLine = Side + " Name: " + SingleTon.GetPlayerController().PlayerName + " " + Side;
            CW.Write("", Pos.X, Pos.Y + LineHeightPos);
            LineHeightPos++;
            CW.Write(FilloutString(BigLine, true), Pos.X, Pos.Y + LineHeightPos);
            LineHeightPos++;
            CW.Write(BigLine, Pos.X, Pos.Y + LineHeightPos);
            LineHeightPos++;
            CW.Write(FilloutString(BigLine, false), Pos.X, Pos.Y + LineHeightPos);
            LineHeightPos += 2;
            StatsPosStart = new Cord { X = Pos.X, Y = Pos.Y + LineHeightPos };
            List<string> StatsBlockList = StatBlockDraw();
            string SizeBox = "";
            for (int i = 0; i < StatsBlockList.Count; i++)
            {
                if (StatsBlockList[i].Length > SizeBox.Length)
                {
                    SizeBox = StatsBlockList[i];
                }
            }
            CW.Write(FilloutString(SizeBox + " ", true), Pos.X, Pos.Y + LineHeightPos);
            LineHeightPos++;
            foreach (string element in StatsBlockList)
            {
                CW.Write(element, Pos.X, Pos.Y + LineHeightPos);
                CW.Write(Side, Pos.X + (SizeBox.Length), Pos.Y + LineHeightPos);
                LineHeightPos++;
            }
            CW.Write(FilloutString(SizeBox + " ", false), Pos.X, Pos.Y + LineHeightPos);
            LineHeightPos++;
            ActionMenuStart = new Cord { X = Pos.X, Y = Pos.Y + LineHeightPos };
            RedrawAcionMenu();
            LineHeightPos = 10 + ActionMenuStart.Y;
            LogPosStart = new Cord { X = Pos.X, Y = Pos.Y + LineHeightPos };
            ReDrawLog();

            //Other Side
            BigLine = Side + " Name: " + SingleTon.GetPlayerController().CBM.enemyFighting.Name + " " + Side;
            Pos = new Cord() { X = Console.WindowWidth - (BigLine.Length + 1), Y = Pos.Y + 4 };
            LineHeightPos = 0;
            CW.Write(FilloutString(BigLine, true), Pos.X, Pos.Y + LineHeightPos);
            LineHeightPos++;
            CW.Write(BigLine, Pos.X, Pos.Y + LineHeightPos);
            LineHeightPos++;
            CW.Write(FilloutString(BigLine, false), Pos.X, Pos.Y + LineHeightPos);


        }

        private List<string> StatBlockDraw()
        {
            List<string> DataReturn = new List<string>();
            DataReturn.Add(Side + " Health: " + SingleTon.GetPlayerController().Skills.Vitallity.HealthCurrent + "/" + SingleTon.GetPlayerController().Skills.Vitallity.Health + " ");
            DataReturn.Add(Side + " Mana: " + SingleTon.GetPlayerController().Skills.Magic.ManaCurrent + "/" + SingleTon.GetPlayerController().Skills.Magic.Mana + " ");
            DataReturn.Add(Side + " Damage: " + SingleTon.GetPlayerController().Skills.Power.ExtraAttack + " + " + SingleTon.GetPlayerController().Skills.Power.Buff + " ");
            DataReturn.Add(Side + " Armor: " + SingleTon.GetPlayerController().Armor + " ");
            return DataReturn;
        }

        public void ReDrawStats()
        {
            LineHeightPos = 0;
            string BigestText = "";
            List<string> StatTexts = new List<string>();
            StatTexts.Add(" Health: " + SingleTon.GetPlayerController().Skills.Vitallity.HealthCurrent + "/" + SingleTon.GetPlayerController().Skills.Vitallity.Health + " ");
            StatTexts.Add(" Mana: " + SingleTon.GetPlayerController().Skills.Magic.ManaCurrent + "/" + SingleTon.GetPlayerController().Skills.Magic.Mana + " ");
            StatTexts.Add(" Damage: " + SingleTon.GetPlayerController().Skills.Power.ExtraAttack + " + " + SingleTon.GetPlayerController().Skills.Power.Buff + " ");
            StatTexts.Add(" Armor: " + SingleTon.GetPlayerController().Armor + " ");
            foreach(string element in StatTexts)
            {
                if(element.Length > BigestText.Length)
                {
                    BigestText = element;
                }
            }

            CW.Write(FilloutString(BigestText, true), StatsPosStart.X, StatsPosStart.Y + LineHeightPos);
            LineHeightPos++;
            foreach(string element in StatTexts)
            {
                CW.Write(Side, StatsPosStart.X, StatsPosStart.Y + LineHeightPos);
                CW.Write(element, StatsPosStart.X + 1, StatsPosStart.Y + LineHeightPos);
                CW.Write(Side, StatsPosStart.X + (BigestText.Length - 1), StatsPosStart.Y + LineHeightPos);
                LineHeightPos++;
            }
            CW.Write(FilloutString(BigestText, true), StatsPosStart.X, StatsPosStart.Y + LineHeightPos);
        }

        public void RedrawAcionMenu()
        {
            string Filler = "oooo oooo oooo oooo oooo oooo";
            LineHeightPos = 0;
            switch(MenuState)
            {
                case ActionMenus.Ablilites:
                    ActiveMenuList = SingleTon.GetPlayerController().AquiredAbilites.Select(x => x.Name).ToList();
                    break;


                case ActionMenus.Items:
                    ActiveMenuList = SingleTon.GetPlayerController().inventory.Inventory.Where(x => x.UseInCombat == true).Select(x => x.name).ToList();
                    break;

                case ActionMenus.Main:
                    ActiveMenuList = MenuTextOptions;
                    CW.Write(FilloutString(Filler, true), ActionMenuStart.X, ActionMenuStart.Y + LineHeightPos);
                    LineHeightPos++;
                    int CurrentHeight = LineHeightPos;
                    for (int i = 0; i< MenuTextOptions.Count; i++)
                    {
                        if(IndexMenu == i)
                        {

                            CW.Write(" [" + MenuTextOptions[i] + "] ", ActionMenuStart.X + 1, ActionMenuStart.Y + LineHeightPos );
                            LineHeightPos++;
                        }

                        else
                        {
                            CW.Write("  " + MenuTextOptions[i] + " ", ActionMenuStart.X +1 , ActionMenuStart.Y + LineHeightPos);
                            LineHeightPos++;
                        }
                    }
                    for (int x = CurrentHeight; x < 11; x++)
                    {
                        CW.Write(Side, ActionMenuStart.X, ActionMenuStart.Y + CurrentHeight);
                        CW.Write(Side, ActionMenuStart.X + 28, ActionMenuStart.Y + CurrentHeight);
                        CurrentHeight++;
                    }
                    CW.Write(FilloutString(Filler, false), ActionMenuStart.X, ActionMenuStart.Y + 11);
                    break;
            }
        }

        public void ReDrawLog()
        {
            LineHeightPos = 0;
            string FillText ="";
            LineHeightPos = 0;

            for (int i = 0; i < Console.WindowWidth  - LogPosStart.X; i++)
            {
                FillText += "o";
            }
            CW.Write(FilloutString(FillText, true), LogPosStart.X, LogPosStart.Y+LineHeightPos);
            LineHeightPos++;
            int TimesToWrite;
            if (DrawInfoBox.Inputs.Count < 10)
            {
                TimesToWrite = DrawInfoBox.Inputs.Count;
            }
            else
            {
                TimesToWrite = 10;
            }
            for(int i = 0; i < TimesToWrite; i++)
            {
                CW.Write(Side, LogPosStart.X, LogPosStart.Y + LineHeightPos);
                CW.Write(DrawInfoBox.Inputs[i], LogPosStart.X + 2, LogPosStart.Y + LineHeightPos);
                CW.Write(Side, LogPosStart.X + (Console.WindowWidth - (LogPosStart.X + 1)), LogPosStart.Y + LineHeightPos);
                LineHeightPos++;
            }
            CW.Write(FilloutString(FillText, false), LogPosStart.X, LogPosStart.Y + LineHeightPos);
        }


        private string FilloutString(string InputString, bool Top)
        {
            string ReturnString = "";
            if (Top)
            {
                ReturnString += Cor[0];
                for (int x = 0; x < InputString.Length - 2; x++)
                {
                    ReturnString += TopBot;
                }
                ReturnString += Cor[1];
                return ReturnString;
            }
            else
            {
                ReturnString += Cor[3];
                for (int x = 0; x < InputString.Length - 2; x++)
                {
                    ReturnString += TopBot;
                }
                ReturnString += Cor[2];
                return ReturnString;
            }
        }


        public enum ActionMenus
        {
            Main, Items, Ablilites
        }
    }
}
