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
        public int Damage { get; private set; }
        public int Level { get; private set; }
        public int Xp { get; private set; }
        public int MaxHp { get; private set; }

        public float FleeChance { get; private set; }
        public List<BaseTile> SpawnableTiles { get; private set; }


        public Enemy(int _health, int _damageMax, int _damageMin, int _level, string _name, int _goldMax, int _goldMin, int _xp, List<BaseTile> spawnableTiles, float _fleeChance)
        {
            SpawnableTiles = spawnableTiles;
            inventory = new InventoryManager();
            Health = _health;
            Damage = SingleTon.GetRandomNum(_damageMin, _damageMax+1);
            Level = _level;
            Name = _name;
            inventory.AddGold(SingleTon.GetRandomNum(_goldMin, _goldMax + 1));
            Xp = _xp;
            FleeChance = _fleeChance;
            MaxHp = Health;
        }

        public void TakeDamage(int inputDamage)
        {
            if(inputDamage >= 0)
            {
                if(Health - inputDamage >= 0)
                {
                    Health -= inputDamage;
                }
                else
                {
                    Health = 0;
                }
            }
        }
    }
}
    