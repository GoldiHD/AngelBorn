using AngelBorn.Player.Inventory;
using AngelBorn.Tools;
using AngleBorn.Items;
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
        public int MaxLevel;
        public int MinLevel;
        public int DamageMax;
        public int DamageMin;
        public int GoldMax;
        public int GoldMin;
        public int level;
        public int GoldDrop;
        public int Damage;
        public float FleeChance { get; private set; }
        public List<BaseTile> SpawnableTiles { get; private set; }
        public List<BaseItem> ItemDrops;


        public Enemy(int _totalhealth, int _damageMax, int _damageMin, int _minlevel , int _levelmax, string _name, int _goldMax, int _goldMin, int _xp, List<BaseTile> spawnableTiles, float _fleeChance, List<BaseItem> _droplist)
        {
            SpawnableTiles = spawnableTiles;
            Health = _totalhealth;
            DamageMax = _damageMax;
            DamageMin = _damageMin;
            GoldMax = _goldMax;
            GoldMin = _goldMin;
            Name = _name;
            ItemDrops = _droplist;
            Xp = _xp;
            FleeChance = _fleeChance;
            MaxHp = _totalhealth;
        }

        public Enemy()
        {

        }

        public Enemy(int health, int damage, int level, string name, int gold, int xp, float fleechance, List<BaseItem> itemdrops)
        {
            Health = health;
            MaxHp = health;
            Damage = damage;
            Level = level;
        }

        public Enemy Copy(Enemy origin)
        {
            Enemy enemy = new Enemy(origin.MaxHp, SingleTon.GetRandomNum(origin.DamageMin, origin.DamageMax), SingleTon.GetRandomNum(origin.MinLevel, origin.MaxLevel), origin.Name, SingleTon.GetRandomNum(origin.GoldMin, origin.GoldMax), origin.Xp, origin.FleeChance, origin.ItemDrops);
            return enemy;
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
    