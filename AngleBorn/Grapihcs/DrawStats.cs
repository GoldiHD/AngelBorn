using AngelBorn.Tools;
using AngelBorn.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace AngelBorn.Grapihcs
{
    class DrawStats
    {

        public void Draw(int x, int y)
        {
            CW.SetPos(x, y);
            Draw();
        }
        public void Draw()
        {
            int line = 0;
            Cord Pos = CW.GetPos();
            int Lenght;
            string FillerLine = "│";
            string Firsslot = "│ Name: " + SingleTon.GetPlayerController().PlayerName + " │ Level: " + SingleTon.GetPlayerController().Level + " │ Job: " + SingleTon.GetPlayerController().PlayerClass.Name + " ";
            string SecSlot = "│ Race: " + SingleTon.GetPlayerController().PlayerRace.Name + " │ Health: " + SingleTon.GetPlayerController().Skills.Vitallity.HealthCurrent + "/" + SingleTon.GetPlayerController().Skills.Vitallity.Health + " │ Mana: " + SingleTon.GetPlayerController().Skills.Magic.ManaCurrent + "/" + SingleTon.GetPlayerController().Skills.Magic.Mana+ " ";
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
            CW.Write("│ S: " + "Base" + " │ " + "Buff" + " │ " + "Skil", Pos.X, Pos.Y + line);
            CW.Write("│", Pos.X + (Lenght), Pos.Y + line);
            line++;
            CW.Write("│ P: " + SingleTon.GetPlayerController().Skills.Power._lvl, Pos.X, Pos.Y + line);
            CW.Write(" │ " + SingleTon.GetPlayerController().Skills.Power.Buff, Pos.X + 10, Pos.Y + line);
            CW.Write(" │ " + SingleTon.GetPlayerController().Skills.Power.ExtraAttack, Pos.X + 17, Pos.Y + line);
            CW.Write("│", Pos.X + (Lenght), Pos.Y + line);
            line++;
            CW.Write("│ V: " + SingleTon.GetPlayerController().Skills.Vitallity._lvl, Pos.X, Pos.Y + line);
            CW.Write(" │ " + SingleTon.GetPlayerController().Skills.Vitallity.Buff, Pos.X + 10, Pos.Y + line);
            CW.Write(" │ " + SingleTon.GetPlayerController().Skills.Vitallity.Health, Pos.X + 17, Pos.Y + line);
            CW.Write("│", Pos.X + (Lenght), Pos.Y + line);
            line++;
            CW.Write("│ M: " + SingleTon.GetPlayerController().Skills.Magic._lvl, Pos.X, Pos.Y + line);
            CW.Write(" │ " + SingleTon.GetPlayerController().Skills.Magic.Buff, Pos.X + 10, Pos.Y + line);
            CW.Write(" │ " + SingleTon.GetPlayerController().Skills.Magic.Mana, Pos.X + 17, Pos.Y + line);
            CW.Write("│", Pos.X + (Lenght), Pos.Y + line);
            line++;
            CW.Write("│ L: " + SingleTon.GetPlayerController().Skills.Luck._lvl, Pos.X, Pos.Y + line);
            CW.Write(" │ " + SingleTon.GetPlayerController().Skills.Luck.Buff, Pos.X + 10, Pos.Y + line);
            CW.Write(" │ " + SingleTon.GetPlayerController().Skills.Luck.critChanceInPercentage, Pos.X + 17, Pos.Y + line);
            CW.Write("│", Pos.X + (Lenght), Pos.Y + line);
            line++;
            CW.WriteLine(FillerLine, Pos.X, Pos.Y + line);
        }
    }
}
