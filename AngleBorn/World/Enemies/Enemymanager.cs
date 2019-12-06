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
            enemies.Add(new Enemy(10,2,1,1,5,"Tsar",5,1,1, new List<BaseTile>() { MapManager.Tiles[0], MapManager.Tiles[1], MapManager.Tiles[2]}, 0.2f, new List<AngleBorn.Items.BaseItem>()));
            enemies.Add(new Enemy(10, 2, 1, 1,5, "Tzu", 5, 1, 1, new List<BaseTile>() { MapManager.Tiles[0], MapManager.Tiles[2]}, 0.5f, new List<AngleBorn.Items.BaseItem>()));
            enemies.Add(new Enemy(10, 2, 1, 1,5, "Tzi", 5, 1, 1, new List<BaseTile>() { MapManager.Tiles[0], MapManager.Tiles[4] }, 0.3f, new List<AngleBorn.Items.BaseItem>()));
            enemies.Add(new Enemy(20, 3, 0, 2,8, "Goblin", 8, 4, 2, new List<BaseTile>() { MapManager.Tiles[3] }, 0.15f, new List<AngleBorn.Items.BaseItem>()));
            enemies.Add(new Enemy(50, 5, 3, 5,10, "Troll", 20, 10, 5, new List<BaseTile> { MapManager.Tiles[3] }, 0.05f, new List<AngleBorn.Items.BaseItem>()));
        }
    }
}
