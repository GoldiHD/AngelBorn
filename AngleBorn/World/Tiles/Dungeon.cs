using AngelBorn.Tools;
using AngelBorn.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngleBorn.World.Tiles
{
    class Dungeon : BaseTile
    {
        public Map ParrentMap;
        public BaseTile DungeonTile;
        public Map DungeonMap;
        public Dungeon()
        {
            MyType = TileType.Dungeon;
            TileName = "Dungeon";
        }

        public Map LoadMap()
        {
            if(DungeonMap == null)
            {
                DungeonMap = SingleTon.GetMapManagerInstance().Dungeons[SingleTon.GetRandomNum(0, SingleTon.GetMapManagerInstance().Dungeons.Count)];
            }
            return DungeonMap;
        }
    }
}
