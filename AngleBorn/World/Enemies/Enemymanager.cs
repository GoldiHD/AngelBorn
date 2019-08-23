using System;
using System.Collections.Generic;
using System.Text;

namespace AngelBorn.World.Enemies
{
    class EnemyManager
    {
        public List<Enemy> enemies { get; private set; }
        public EnemyManager()
        {
            enemies = new List<Enemy>();
            enemies.Add(new Enemy(10,2,1,1,"Tsar",5,1,1));
            enemies.Add(new Enemy(10, 2, 1, 1, "Tzu", 5, 1, 1));
            enemies.Add(new Enemy(10, 2, 1, 1, "Tzi", 5, 1, 1));
        }
    }
}
