using System;
using System.Collections.Generic;
using System.Text;

namespace AngelBorn.Player
{
    class Stats
    {
        public Power Power;
        public Vitallity Vitallity;
        public Magic Magic;
        public Luck Luck;

        public Stats(int pow, int vit, int mag, int luc)
        {
            Power = new Power(pow);
            Vitallity = new Vitallity(vit);
            Magic = new Magic(mag);
            Luck = new Luck(luc);
        }
    }

    public class Power //Attack damage
    {

        public int Buff { get; private set; }
        public int _lvl { get; private set; }
        public int ExtraAttack { get; private set; }
        public Power(int lvl)
        {
            
            _lvl = lvl;
            ExtraAttack = _lvl / 5;
        }
    }

    public class Vitallity //health
    {
        public int HealthCurrent { get; private set; }
        public int Health { get; private set; }

        public int Buff { get; private set; }
        public int _lvl { get; private set; }
        public Vitallity(int lvl)
        {
            _lvl = lvl;
            Health = _lvl * 5;
            HealthCurrent = Health;
        }
    }

    public class Magic //magic damage and mana
    {
        public int Mana { get; private set; }
        public int ManaCurrent { get; private set; }
        public int Buff { get; private set; }
        public int _lvl { get; private set; }
        public Magic(int lvl)
        {
            _lvl = lvl;
            Mana = _lvl * 5;
            ManaCurrent = Mana;
        }
    }

    public class Luck //crit and loot
    {

        public int Buff { get; private set; }
        public int _lvl { get; private set; }
        public int critChanceInPercentage { get; private set; }
        public Luck(int lvl)
        {
            _lvl = lvl;
            critChanceInPercentage = _lvl / 2;
        }
    }
}
