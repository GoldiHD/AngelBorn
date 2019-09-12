using AngelBorn.Tools;
using AngelBorn.World.Enemies;
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
            enemyFighting = SingleTon.GetEnemies().enemies[0];
        }
    }
}
