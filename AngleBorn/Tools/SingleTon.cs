using AngelBorn.Player;
using AngelBorn.World;
using AngelBorn.World.Enemies;
using System;
using System.Collections.Generic;
using System.Text;

namespace AngelBorn.Tools
{
    class SingleTon
    {
        private static PlayerController PlayerController;
        private static Cursor cursor;
        private static MapManager mapManager;
        private static EnemyManager enemies;
        private static Random RNG;

        public static PlayerController GetPlayerController()
        {
            if(PlayerController == null)
            {
                PlayerController = new PlayerController();
            }
            return PlayerController;
        }

        public static MapManager GetMapManagerInstance()
        {
            if (mapManager == null)
            {
                mapManager = new MapManager();
            }
            return mapManager;
        }

        public static Cursor GetCursorInstance()
        {
            if (cursor == null)
            { 
                cursor = new Cursor();
            }
            return cursor;
        }

        public static int GetRandomNum(int first, int sec)
        {
            if(RNG == null)
            {
                RNG = new Random(DateTime.Now.Millisecond);
            }
            return RNG.Next(first, sec);
        }

        public static EnemyManager GetEnemies()
        {
            if(enemies == null)
            {
                enemies = new EnemyManager();
            }
            return enemies;
        }
    }
}
