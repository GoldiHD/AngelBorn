using AngelBorn.Tools;
using AngelBorn.World;
using AngelBorn.World.Enemies;
using AngleBorn.Grapihcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngleBorn.Player
{
    class CombatManager
    {
        public int Rounds { get; private set; }
        public Enemy enemyFighting { get; private set; } 

        public CombatManager()
        {
            CombatDraw.MenuState = CombatDraw.ActionMenus.Main;
            enemyFighting = SingleTon.GetEnemies().enemies[0];
        }

        public bool CheckForEnemy(BaseTile Tile)
        {
            List<Enemy> enemiesToPick = SingleTon.GetEnemies().enemies.Where(x => x.SpawnableTiles.Any(y => y.TileName == Tile.TileName)).ToList();
            return true;
        }
    }
}
