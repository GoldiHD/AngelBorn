using AngelBorn.Tools;
using AngelBorn.World.Tiles;
using System.Collections.Generic;
using System.Threading;

namespace AngelBorn.World
{
    class MapManager
    {
        public List<Map> Maps { get; private set; }
        public static List<BaseTile> Tiles;
        public Map CurrentMap;
        public List<CityTile> Towns;
        public List<Thread> MapCreators;
        public MapManager()
        {
            MapCreators = new List<Thread>();
            Cord Test;
            Tiles = new List<BaseTile>();
            Towns = new List<CityTile>();
            Maps = new List<Map>();
            CreateTiles();
            CreateMaps();
            while (true)
            {
                Test.X = SingleTon.GetRandomNum(0, Maps[0].MapSize.X);
                Test.Y = SingleTon.GetRandomNum(0, Maps[0].MapSize.Y);
                if (Maps[0].Tiles[Test.X, Test.Y] != null)
                {
                    SingleTon.GetCursorInstance().CurrentTile = Maps[0].Tiles[Test.X, Test.Y];
                    break;
                }

            }
            CurrentMap = Maps[0];


        }

        public void SetPlayerSpawn(int map)
        {
            Maps[0].SetPlayerSpawn();
        }

        private void CreateTiles()
        {
            //create tiles and towns
            Tiles.Add(new BaseTile() { MyType = TileType.Normal, TileName = "GrassPlain", Description = "An open field of grass, you're not likely to meet anyone here", Walkable = true });
            Tiles.Add(new BaseTile() { MyType = TileType.Normal, TileName = "Forest", Description = "Are normal forest you're likely to find things here", Walkable = true });
            //Tiles.Add()
            Towns.Add(new CityTile("Town"));



        }

        private void CreateMaps()
        {
            //World Map
            Maps.Add(new Map(new Cord() { X = 300, Y = 300 }));
            MapCreators.Add(Maps[Maps.Count - 1].GenerateMapThread(new List<BaseTile> { Tiles[0] }, new List<CityTile> { Towns[0], Towns[0], Towns[0], Towns[0], Towns[0], Towns[0], Towns[0], Towns[0], Towns[0], Towns[0], Towns[0], Towns[0], Towns[0], Towns[0], Towns[0], Towns[0], Towns[0], Towns[0], Towns[0], Towns[0], Towns[0], Towns[0], Towns[0], Towns[0], Towns[0], Towns[0], Towns[0], Towns[0], Towns[0], Towns[0], Towns[0], Towns[0], Towns[0], Towns[0], Towns[0], }, new List<Enemies.Enemy> { }));
        }
    }
}
