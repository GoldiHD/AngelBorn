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
        }

        public bool CheckForEnemy(BaseTile Tile)
        {
            List<Enemy> enemiesToPick = SingleTon.GetEnemies().enemies.Where(x => x.SpawnableTiles.Any(y => y.TileName == Tile.TileName)).Where(x => x.MinLevel < SingleTon.GetPlayerController().Level && x.MaxLevel > SingleTon.GetPlayerController().Level).ToList();
            if (enemiesToPick.Count != 0)
            {
                enemyFighting = new Enemy().Copy(enemiesToPick[SingleTon.GetRandomNum(0, enemiesToPick.Count)]);
            }
            return true;
        }
    }
}

