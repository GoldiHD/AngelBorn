using AngelBorn.Player.Abilities;
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
            playerClasses.Add(new BaseClass("Warrior", 'W'));
            playerClasses.Add(new BaseClass("Mage", 'M'));
            playerClasses.Add(new BaseClass("Rouge", 'R'));
            playerClasses.Add(new BaseClass("Hunter", 'H'));
        }
        
    }

    class BaseClass
    {
        private List<BaseAbilites> abilities;
        public string Name { get; private set; }
        public char selectSign { get; private set; }

        public BaseClass(string _name, char _sign)
        {
            Name = _name;
            selectSign = _sign;
        }
    }
}
