﻿using AngelBorn.Tools;
using AngelBorn.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace AngelBorn.Grapihcs
{
    class DrawStats
    {
        public static int Lenght = 0;
        public void Draw(int x, int y)
        {
            CW.SetPos(x, y);
            Draw();
        }
        public void Draw()
        {
            int line;
            line = 0;
            Cord Pos = CW.GetPos();
            string FillerLine = "│";
            string Firsslot = "│ Name: " + SingleTon.GetPlayerController().PlayerName + " │ Level: " + SingleTon.GetPlayerController().Level + " │ Job: " + SingleTon.GetPlayerController().PlayerClass.Name + " ";
            string SecSlot = "│ Race: " + SingleTon.GetPlayerController().PlayerRace.Name + " │ Health: " + SingleTon.GetPlayerController().Skills.Vitallity.HealthCurrent + "/" + SingleTon.GetPlayerController().Skills.Vitallity.Health + " │ Mana: " + SingleTon.GetPlayerController().Skills.Magic.ManaCurrent + "/" + SingleTon.GetPlayerController().Skills.Magic.Mana + " ";
            if (Firsslot.Length > SecSlot.Length)
            {
                Lenght = Firsslot.Length;
                for (int i = 1; i < Firsslot.Length; i++)
                {
                    FillerLine += "─";
                }
            }
            else
            {
                Lenght = SecSlot.Length;
                for (int i = 1; i < SecSlot.Length; i++)
                {
                    FillerLine += "─";
                }
            }
            FillerLine += "│";
            CW.Write(FillerLine, Pos.X, Pos.Y + line);
            line++;
            if (Firsslot.Length > SecSlot.Length)
            {
                CW.Write(Firsslot + "│", Pos.X, Pos.Y + line);
                line++;
                CW.Write(SecSlot, Pos.X, Pos.Y + line);
                CW.WriteLine("│", Pos.X + (Lenght), Pos.Y + line);
                line++;
            }
            else
            {
                CW.Write(Firsslot, Pos.X, Pos.Y + line);
                CW.WriteLine("│", Pos.X + (Lenght), Pos.Y + line);
                line++;
                CW.Write(SecSlot + "│", Pos.X, Pos.Y + line);
                line++;
            }
            CW.Write(FillerLine, Pos.X, Pos.Y + line);
            line++;
            CW.Write("│ Skil: " + "Base" + " │ " + "Buff" + " │ " + "Skil", Pos.X, Pos.Y + line);
            CW.Write("│", Pos.X + (Lenght), Pos.Y + line);
            line++;
            CW.Write("│ Powe: " + SingleTon.GetPlayerController().Skills.Power._lvl, Pos.X, Pos.Y + line);
            CW.Write(" │ " + SingleTon.GetPlayerController().Skills.Power.Buff, Pos.X + 12, Pos.Y + line);
            CW.Write(" │ " + SingleTon.GetPlayerController().Skills.Power.ExtraAttack, Pos.X + 19, Pos.Y + line);
            CW.Write("│", Pos.X + (Lenght), Pos.Y + line);
            line++;
            CW.Write("│ Vita: " + SingleTon.GetPlayerController().Skills.Vitallity._lvl, Pos.X, Pos.Y + line);
            CW.Write(" │ " + SingleTon.GetPlayerController().Skills.Vitallity.Buff, Pos.X + 12, Pos.Y + line);
            CW.Write(" │ " + SingleTon.GetPlayerController().Skills.Vitallity.Health, Pos.X + 19, Pos.Y + line);
            CW.Write("│", Pos.X + (Lenght), Pos.Y + line);
            line++;
            CW.Write("│ Magi: " + SingleTon.GetPlayerController().Skills.Magic._lvl, Pos.X, Pos.Y + line);
            CW.Write(" │ " + SingleTon.GetPlayerController().Skills.Magic.Buff, Pos.X + 12, Pos.Y + line);
            CW.Write(" │ " + SingleTon.GetPlayerController().Skills.Magic.Mana, Pos.X + 19, Pos.Y + line);
            CW.Write("│", Pos.X + (Lenght), Pos.Y + line);
            line++;
            CW.Write("│ Luck: " + SingleTon.GetPlayerController().Skills.Luck._lvl, Pos.X, Pos.Y + line);
            CW.Write(" │ " + SingleTon.GetPlayerController().Skills.Luck.Buff, Pos.X + 12, Pos.Y + line);
            CW.Write(" │ " + SingleTon.GetPlayerController().Skills.Luck.critChanceInPercentage, Pos.X + 19, Pos.Y + line);
            CW.Write("│", Pos.X + (Lenght), Pos.Y + line);
            line++;
            CW.WriteLine(FillerLine, Pos.X, Pos.Y + line);
            line++;
            CW.Write("│ XP: " + SingleTon.GetPlayerController().Xp + "/" + SingleTon.GetPlayerController().NextLevelXP, Pos.X, Pos.Y + line);
            CW.Write("│", Pos.X + (Lenght), Pos.Y + line);
            line++;
            CW.Write("│ |" + CalculateLevelProgress()+ "|", Pos.X, Pos.Y + line);
            CW.Write("│", Pos.X + (Lenght), Pos.Y + line);
            line++;
            CW.WriteLine(FillerLine, Pos.X, Pos.Y + line);
        }

        private string CalculateLevelProgress()
        {
            string ProgressionString = "";
            float Percentage;
            try
            {
                Percentage = ((float)SingleTon.GetPlayerController().Xp / (float)SingleTon.GetPlayerController().NextLevelXP) * 100f;
            }
            catch
            {
                Percentage = 0;
            }

            for (int i = 0; i < ((int)Percentage / 5); i++)
            {
                ProgressionString += "=";
            }
            int lenght = ProgressionString.Length;
            for (int x = 0; x < 20 - lenght; x++)
            {
                ProgressionString += "-";
            }

            return ProgressionString;
        }
    }
}
