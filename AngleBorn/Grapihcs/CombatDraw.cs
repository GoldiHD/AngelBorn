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
        private readonly string Side = "║";
        private int LineHeightPos;
        public static ActionMenus MenuState = ActionMenus.Main;
        private static Cord ActionMenuStart;
        private static Cord LogPosStart;
        private static Cord StatsPosStart;
        private Cord Pos;
        public static List<string> ActiveMenuList;
        private readonly List<string> MenuTextOptions = new List<string> { "Attack", "Items", "Abilites", "Flee" };

        public void Draw(Cord _Pos)
        {
            CW.Clear();
            Pos = _Pos;
            LineHeightPos = 0;
            string BigLine = Side + " Round: " + SingleTon.GetPlayerController().CBM.Rounds + " " + Side;
            CW.FillOutStringBorder(BigLine, true, Pos.X, Pos.Y + LineHeightPos);
            LineHeightPos++;
            CW.Write(BigLine, Pos.X, Pos.Y + LineHeightPos);
            LineHeightPos++;
            CW.FillOutStringBorder(BigLine, false, Pos.X, Pos.Y + LineHeightPos);
            LineHeightPos++;
            BigLine = Side + " Name: " + SingleTon.GetPlayerController().PlayerName + " " + Side;
            CW.Write("", Pos.X, Pos.Y + LineHeightPos);
            LineHeightPos++;
            CW.FillOutStringBorder(BigLine, true, Pos.X, Pos.Y + LineHeightPos);
            LineHeightPos++;
            CW.Write(BigLine, Pos.X, Pos.Y + LineHeightPos);
            LineHeightPos++;
            CW.FillOutStringBorder(BigLine, false, Pos.X, Pos.Y + LineHeightPos);
            LineHeightPos += 2;
            StatsPosStart = new Cord { X = Pos.X, Y = Pos.Y + LineHeightPos };
            ReDrawStats();
            LineHeightPos += 9;
            ActionMenuStart = new Cord { X = Pos.X, Y = Pos.Y + LineHeightPos };
            RedrawAcionMenu();
            LineHeightPos = 10 + ActionMenuStart.Y;
            LogPosStart = new Cord { X = Pos.X, Y = Pos.Y + LineHeightPos };
            ReDrawLog();

            //Other Side
            BigLine = Side + " Name: " + SingleTon.GetPlayerController().CBM.enemyFighting.Name + " " + Side;
            Pos = new Cord() { X = Console.WindowWidth - (BigLine.Length + 1), Y = Pos.Y + 4 };
            LineHeightPos = 0;
            CW.FillOutStringBorder(BigLine, true, Pos.X, Pos.Y + LineHeightPos);
            LineHeightPos++;
            CW.Write(BigLine, Pos.X, Pos.Y + LineHeightPos);
            LineHeightPos++;
            CW.FillOutStringBorder(BigLine, false, Pos.X, Pos.Y + LineHeightPos);
        }

        public void ReDrawStats()
        {
            LineHeightPos = 0;
            string BigestText = "";
            List<string> StatTexts = new List<string>();
            StatTexts.Add(" Health: " + SingleTon.GetPlayerController().Skills.Vitallity.HealthCurrent + "/" + SingleTon.GetPlayerController().Skills.Vitallity.Health + "  ");
            StatTexts.Add(" Mana: " + SingleTon.GetPlayerController().Skills.Magic.ManaCurrent + "/" + SingleTon.GetPlayerController().Skills.Magic.Mana + "  ");
            StatTexts.Add(" Damage: " + SingleTon.GetPlayerController().Skills.Power.ExtraAttack + " + " + SingleTon.GetPlayerController().Skills.Power.Buff + "  ");
            StatTexts.Add(" Armor: " + SingleTon.GetPlayerController().Armor + " ");
            foreach (string element in StatTexts)
            {
                if (element.Length > BigestText.Length)
                {
                    BigestText = element + " ";
                }
            }

            CW.FillOutStringBorder(BigestText, true, StatsPosStart.X, StatsPosStart.Y + LineHeightPos);
            LineHeightPos++;
            foreach (string element in StatTexts)
            {
                CW.Write(Side, StatsPosStart.X, StatsPosStart.Y + LineHeightPos);
                CW.Write(element, StatsPosStart.X + 1, StatsPosStart.Y + LineHeightPos);
                CW.Write(Side, StatsPosStart.X + (BigestText.Length - 1), StatsPosStart.Y + LineHeightPos);
                LineHeightPos++;
            }
            CW.FillOutStringBorder(BigestText, false, StatsPosStart.X, StatsPosStart.Y + LineHeightPos);

            //enemy

            LineHeightPos = 0;
            BigestText = "";
            StatTexts.Clear();
            StatTexts.Add(" Health: " + SingleTon.GetPlayerController().CBM.enemyFighting.Health + "/" + SingleTon.GetPlayerController().CBM.enemyFighting.MaxHp + "  ");
            StatTexts.Add(" Damage: " + SingleTon.GetPlayerController().CBM.enemyFighting.Damage + "  ");
            StatTexts.Add(" ");
            StatTexts.Add(" ");
            foreach (string element in StatTexts)
            {
                if (element.Length > BigestText.Length)
                {
                    BigestText = element + " ";
                }
            }
            int Lenght = StatsPosStart.X + (Console.WindowWidth - (StatsPosStart.X + 1 + BigestText.Length));
            CW.FillOutStringBorder(BigestText, true,Lenght, StatsPosStart.Y + LineHeightPos);
            LineHeightPos++;
            foreach (string element in StatTexts)
            {
                CW.Write(Side, Lenght, StatsPosStart.Y + LineHeightPos);
                CW.Write(element, Lenght + 1, StatsPosStart.Y + LineHeightPos);
                CW.Write(Side, Lenght + (BigestText.Length - 1), StatsPosStart.Y + LineHeightPos);
                LineHeightPos++;
            }
            CW.FillOutStringBorder(BigestText, false, Lenght, StatsPosStart.Y + LineHeightPos);

          }

        public void RedrawAcionMenu()
        {
            string Filler = "oooo oooo oooo oooo oooo oooo";
            LineHeightPos = 0;
            switch (MenuState)
            {
                case ActionMenus.Ablilites:
                    ActiveMenuList = SingleTon.GetPlayerController().AquiredAbilites.Select(x => x.Name).ToList();
                    break;


                case ActionMenus.Items:
                    ActiveMenuList = SingleTon.GetPlayerController().Inventory.Inventory.Where(x => x.UseInCombat == true).Select(x => x.name).ToList();
                    break;

                case ActionMenus.Main:
                    ActiveMenuList = MenuTextOptions;
                    CW.FillOutStringBorder(Filler, true, ActionMenuStart.X, ActionMenuStart.Y + LineHeightPos);
                    LineHeightPos++;
                    int CurrentHeight = LineHeightPos;
                    for (int i = 0; i < MenuTextOptions.Count; i++)
                    {
                        if (IndexMenu == i)
                        {

                            CW.Write(" [" + MenuTextOptions[i] + "] ", ActionMenuStart.X + 1, ActionMenuStart.Y + LineHeightPos);
                            LineHeightPos++;
                        }

                        else
                        {
                            CW.Write("  " + MenuTextOptions[i] + " ", ActionMenuStart.X + 1, ActionMenuStart.Y + LineHeightPos);
                            LineHeightPos++;
                        }
                    }
                    for (int x = CurrentHeight; x < 11; x++)
                    {
                        CW.Write(Side, ActionMenuStart.X, ActionMenuStart.Y + CurrentHeight);
                        CW.Write(Side, ActionMenuStart.X + 28, ActionMenuStart.Y + CurrentHeight);
                        CurrentHeight++;
                    }
                    CW.FillOutStringBorder(Filler, false, ActionMenuStart.X, ActionMenuStart.Y + 11);
                    break;
            }
        }

        public void ReDrawLog()
        {
            LineHeightPos = 0;
            string FillText = "";
            LineHeightPos = 0;

            for (int i = 0; i < Console.WindowWidth - LogPosStart.X; i++)
            {
                FillText += "o";
            }
            CW.FillOutStringBorder(FillText, true, LogPosStart.X, LogPosStart.Y + LineHeightPos);
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
            for (int i = 0; i < TimesToWrite; i++)
            {
                CW.Write(Side, LogPosStart.X, LogPosStart.Y + LineHeightPos);
                CW.Write(DrawInfoBox.Inputs[i], LogPosStart.X + 2, LogPosStart.Y + LineHeightPos);
                CW.Write(Side, LogPosStart.X + (Console.WindowWidth - (LogPosStart.X + 1)), LogPosStart.Y + LineHeightPos);
                LineHeightPos++;
            }
            CW.FillOutStringBorder(FillText, false, LogPosStart.X, LogPosStart.Y + LineHeightPos);
        }
        public enum ActionMenus
        {
            Main, Items, Ablilites
        }
    }
}
