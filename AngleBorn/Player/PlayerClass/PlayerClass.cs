using AngelBorn.Player.Abilities;
using AngelBorn.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace AngelBorn.Player.PlayerClass
{
    class PlayerClass
    {
        public static List<BaseClass> playerClasses { get; private set; }
        


        public PlayerClass()
        {
            playerClasses = new List<BaseClass>();
            playerClasses.Add(new BaseClass("Warrior", 'W', 0,2,0,0));
            playerClasses.Add(new BaseClass("Mage", 'M',0,0,2,0));
            playerClasses.Add(new BaseClass("Rouge", 'R',0,0,0,2));
            playerClasses.Add(new BaseClass("Hunter", 'H',2,0,0,0));
        }
        
    }

    class BaseClass
    {
        private List<BaseAbilites> abilities;
        public string Name { get; private set; }

        public char selectSign { get; private set; }
        private int PowBonus;
        private int VitBonus;
        private int MagBonus;
        private int LuckBonus;

        public BaseClass(string _name, char _sign, int p, int v, int m, int l)
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
