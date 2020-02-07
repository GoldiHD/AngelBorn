

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
            AddBonus();
        }

        public void AddPoint()
        {
            _lvl++;
            AddBonus();
        }

        public void AddPoint(int Amount)
        {
            _lvl += Amount;
            AddBonus();
        }

        private void AddBonus()
        {
            if (_lvl < 0)
            {
                _lvl = 0;
            }
            ExtraAttack = 1 + _lvl / 3;
        }

        public void AddWeaponDamage(int _weaponDamage)
        {
            if (_weaponDamage > 0)
            {
                Buff += _weaponDamage;
            }
        }

        public void RemoveDamage(int _weaponDamage)
        {
            if(Buff - _weaponDamage >= 0)
            {
                Buff -= _weaponDamage;
            }
            else
            {
                Buff = 0;
            }
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
            AddBonus();
        }

        public void AddPoint()
        {
            _lvl++;
            AddBonus();
        }

        public void AddPoint(int Amount)
        {
            _lvl += Amount;
            AddBonus();
        }

        private void AddBonus()
        {
            if (_lvl < 0)
            {
                _lvl = 0;
            }
            Health = _lvl * 5;
            HealthCurrent = Health;
        }

        public void Heal(int amount)
        {
            if(amount > 0)
            {
                if(HealthCurrent + amount > Health)
                {
                    HealthCurrent = Health;
                }
                else
                {
                    HealthCurrent += amount;
                }
            }
        }

        public int TakeDamage(int damage)
        {
            if (damage >= 0)
            {
                if (HealthCurrent - damage >= 0)
                {
                    HealthCurrent -= damage;
                    return damage;
                }
                else
                {
                    HealthCurrent = 0;
                    return damage - (damage - HealthCurrent);
                }
            }
            return 0;
        }
    }

    public class Magic //mana
    {
        public int Mana { get; private set; }
        public int ManaCurrent { get; private set; }
        public int Buff { get; private set; }
        public int _lvl { get; private set; }
        public Magic(int lvl)
        {
            _lvl = lvl;
            AddBonus();
        }

        public void AddPoint()
        {
            _lvl++;
            AddBonus();
        }

        public void AddPoint(int Amount)
        {
            _lvl += Amount;
            AddBonus();
        }

        private void AddBonus()
        {
            if (_lvl < 0)
            {
                _lvl = 0;
            }
            Mana = _lvl * 5;
            ManaCurrent = Mana;
        }

        public void RegainMana(int amount)
        {
            if (amount > 0)
            {
                if (ManaCurrent + amount > Mana)
                {
                    ManaCurrent = Mana;
                }
                else
                {
                    ManaCurrent += amount;
                }
            }
        }

        public bool DrainMana(int amount)
        {
            if (amount >= 0)
            {
                if (ManaCurrent - amount >= 0)
                {
                    ManaCurrent -= amount;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
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
            AddBonus();
        }

        public void AddPoint()
        {
            _lvl++;
            AddBonus();
        }

        public void AddPoint(int Amount)
        {
            _lvl += Amount;
            AddBonus();
        }

        private void AddBonus()
        {
            if (_lvl < 0)
            {
                _lvl = 0;
            }
            critChanceInPercentage = _lvl / 2;
        }
    }
}
