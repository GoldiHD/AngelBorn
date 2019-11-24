using AngelBorn.Player.Inventory;
using AngelBorn.Tools;
using AngleBorn.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace AngelBorn.World.Enemies
{
    class Enemy : BaseCharacters
    {
        public int Level { get; private set; }
        public int Xp { get; private set; }
        public int MaxHp { get; private set; }

        private int DamageMax;
        private int DamageMin;
        private int GoldMax;
        private int GoldMin;
        public int Damage { get; private set; }
        public float FleeChance { get; private set; }
        public List<BaseTile> SpawnableTiles { get; private set; }


        public Enemy(int _health, int _damageMax, int _damageMin, int _level, string _name, int _goldMax, int _goldMin, int _xp, List<BaseTile> spawnableTiles, float _fleeChance)
        {
            SpawnableTiles = spawnableTiles;
            inventory = new InventoryManager();
            Health = _health;
            DamageMax = _damageMax;
            DamageMin = _damageMin;
            GoldMax = _goldMax;
            GoldMin = _goldMin;
            Level = _level;
            Name = _name;
            inventory.AddGold(SingleTon.GetRandomNum(_goldMin, _goldMax + 1));
            Xp = _xp;
            FleeChance = _fleeChance;
            MaxHp = Health;
        }

        public void EndCombat()
        {
            Health = MaxHp;
        }

        public void SetDamage()
        {
            Damage = SingleTon.GetRandomNum(DamageMin, DamageMax+1);
        }

        public int GetGold()
        {
            return SingleTon.GetRandomNum(GoldMin, GoldMax+1);
        }

        public int TakeDamage(int inputDamage)
        {
            if(inputDamage >= 0)
            {
                if(Health - inputDamage >= 0)
                {
                    Health -= inputDamage;
                    return inputDamage;
                }
                else
                {
                    Health = 0;
                    return inputDamage - (inputDamage- Health);
                }
            }
            return 0;
        }
    }
}
    