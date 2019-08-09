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
            races.Add(new Race("Human", 'H'));
            races.Add(new Race("Elf", 'E'));
            races.Add(new Race("Dwarf", 'D'));
            races.Add(new Race("Goblin",'G'));
        }
    }

    class Race
    {
        public string Name { get; private set; }
        public char selectSign { get; private set; }

        public Race(string _name, char _sign)
        {
            Name = _name;
            selectSign = _sign;
        }
    }
}
