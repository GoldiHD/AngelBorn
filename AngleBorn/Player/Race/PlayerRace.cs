using AngelBorn.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace AngelBorn.Player.RaceFolder
{
    class PlayerRace
    {
        public static List<Race> races;

        public PlayerRace()
        {
            races = new List<Race>();
            races.Add(new Race("Human", 'H', 2,1,0,1));
            races.Add(new Race("Night Elf with big tar tars", 'E', 1,0,3,0));
            races.Add(new Race("Dwarf", 'D',1,3,0,0));
            races.Add(new Race("Goblin",'G',1,1,1,2));
        }
    }

    class Race
    {
        public string Name { get; private set; }
        public char selectSign { get; private set; }
        private int PowBonus;
        private int VitBonus;
        private int MagBonus;
        private int LuckBonus;

        public Race(string _name, char _sign, int p, int v, int m, int l)
        {
            Name = _name;
            selectSign = _sign;
            PowBonus = p;
            VitBonus = v;
            MagBonus = m;
            LuckBonus = l;
        }

        public void ApplyBonus()
        {
            SingleTon.GetPlayerController().Skills.Power.AddPoint(PowBonus);
            SingleTon.GetPlayerController().Skills.Vitallity.AddPoint(VitBonus);
            SingleTon.GetPlayerController().Skills.Magic.AddPoint(MagBonus);
            SingleTon.GetPlayerController().Skills.Luck.AddPoint(LuckBonus);
        }
    }
}
