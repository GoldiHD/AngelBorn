using AngelBorn.Tools;
using AngelBorn.World.Enemies;
using AngelBorn.World.Tiles;
using AngleBorn.World;
using AngleBorn.World.NPCS;
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
        public List<Map> Dungeons { get; private set; }
        public List<BaseNPC> NPCS = new List<BaseNPC>();
        public EnemyManager EM;

        public MapManager()
        {
            Dungeons = new List<Map>();
            MapCreators = new List<Thread>();
            Cord Test;
            Tiles = new List<BaseTile>();
            Towns = new List<CityTile>();
            Maps = new List<Map>();
            CreateNPCS();
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
            /*0*/Tiles.Add(new BaseTile() { TileName = "Moutain", Walkable = false, MyType = TileType.Inpassable, MinChanceMonster = 0f, MaxChanceMonster = 0f });
            /*1*/Tiles.Add(new BaseTile() { MyType = TileType.Normal, TileName = "GrassPlain", Description = "An open field of grass, you're not likely to meet anyone here", Walkable = true, MinChanceMonster = 0.01f, MaxChanceMonster = 0.02f});
            /*2*/Tiles.Add(new BaseTile() { MyType = TileType.Normal, TileName = "Forest", Description = "Are normal forest you're likely to find things here", Walkable = true, MinChanceMonster = 0.005f, MaxChanceMonster = 0.02f });
            /*3*/Tiles.Add(new BaseTile() { MyType = TileType.Normal, TileName = "Dungeon Floor", Description = "a dusty floor in the in a wet and cold dungeon", Walkable = true, MinChanceMonster =  0.02f, MaxChanceMonster = 0.025f});
            /*4*/Tiles.Add(new BaseTile() { MyType = TileType.Normal, TileName = "Swamp", Description = "A swampy area submerged in water and ", Walkable = true, MinChanceMonster = 0.015f, MaxChanceMonster = 0.023f });
            /*5*/Tiles.Add(new BaseTile() { MyType = TileType.Normal, TileName = "Road", Description = "A lonely road between cites, you may spot the random farmer on his way", MinChanceMonster = 0.002f, MaxChanceMonster = 0.0021f });
            /*6*/Tiles.Add(new BaseTile() { MyType = TileType.Normal, TileName = "Healing Fountain", Description = "A magical healing fountain, one of these can be found in every town", MinChanceMonster = 0, MaxChanceMonster = 0f });
        }

        private void CreateNPCS()
        {
            NPCS.Add(new BaseNPC("Sam", 30, true));
            NPCS.Add(new BaseNPC("Julian", 30, false));
            NPCS.Add(new BaseNPC("Linus", 30, false));
            NPCS.Add(new BaseNPC("Emmy", 30, false));
            NPCS.Add(new BaseNPC("Elly", 30, false));
            NPCS.Add(new BaseNPC("Carla", 30, false));
            NPCS.Add(new BaseNPC("Wella", 30, false));
            NPCS.Add(new BaseNPC("Iola", 30, false));
        }

        private void CreateMaps()
        {
            //Dungeons
            Dungeons.Add(new Map(new Cord { X = 40, Y = 40 }));
            Dungeons.Add(new Map(new Cord { X = 30, Y = 30 }));
            Dungeons.Add(new Map(new Cord { X = 38, Y = 28 }));
            Dungeons.Add(new Map(new Cord { X = 64, Y = 70 }));

            

            //World Map
            Maps.Add(new Map(new Cord() { X = 300, Y = 300 }));
            Maps.Add(new Map(new Cord() { X = 50, Y = 50 }));
            Maps.Add(new Map(new Cord() { X = 70, Y = 50 }));
            Maps.Add(new Map(new Cord() { X = 60, Y = 30 }));
            Maps.Add(new Map(new Cord() { X = 100, Y = 100 }));
            Maps.Add(new Map(new Cord() { X = 25, Y = 25 }));
            Maps.Add(new Map(new Cord() { X = 60, Y = 60 }));
            Maps.Add(new Map(new Cord() { X = 40, Y = 80 }));
            Maps.Add(new Map(new Cord() { X = 60, Y = 70 }));
            Maps.Add(new Map(new Cord() { X = 30, Y = 25 }));
            Maps.Add(new Map(new Cord() { X = 30, Y = 30 }));

            Towns.Add(new CityTile("Rakli", Maps[0], Maps[1]));
            Towns.Add(new CityTile("Guthram", Maps[0], Maps[2]));
            Towns.Add(new CityTile("Dewsbury", Maps[0], Maps[3]));
            Towns.Add(new CityTile("Vaxhamn", Maps[0], Maps[4]));
            Towns.Add(new CityTile("Glossop", Maps[0], Maps[5]));
            Towns.Add(new CityTile("Hvita", Maps[0], Maps[6]));
            Towns.Add(new CityTile("Auggriz", Maps[0], Maps[7]));
            Towns.Add(new CityTile("Torkuth", Maps[0], Maps[8]));
            Towns.Add(new CityTile("Taxned", Maps[0], Maps[9]));
            Towns.Add(new CityTile("Kunzud", Maps[0], Maps[10]));

            MapCreators.Add(Maps[0].GenerateMapThread(new List<BaseTile> { Tiles[1], Tiles[2], Tiles[4], Tiles[5] }, new List<CityTile> { Towns[0],  Towns[1], Towns[2], Towns[3], Towns[4]}, new List<BaseCharacters>(), 20));
            //Cites
            MapCreators.Add(Maps[1].GenerateMapThread(new List<BaseTile> { Tiles[0], Tiles[1], Tiles[6] }, new List<BaseCharacters> { NPCS[0]}, 15, Towns[0]));
            MapCreators.Add(Maps[2].GenerateMapThread(new List<BaseTile> { Tiles[0], Tiles[1], Tiles[6] }, new List<BaseCharacters> { NPCS[0]},20, Towns[1]));
            MapCreators.Add(Maps[3].GenerateMapThread(new List<BaseTile> { Tiles[0], Tiles[1], Tiles[6] }, new List<BaseCharacters> { NPCS[0]},10, Towns[2]));
            MapCreators.Add(Maps[4].GenerateMapThread(new List<BaseTile> { Tiles[0], Tiles[1], Tiles[6] }, new List<BaseCharacters> { NPCS[0]},30, Towns[3]));
            MapCreators.Add(Maps[5].GenerateMapThread(new List<BaseTile> { Tiles[0], Tiles[1], Tiles[6] }, new List<BaseCharacters> { NPCS[0]},4, Towns[4]));
            MapCreators.Add(Maps[6].GenerateMapThread(new List<BaseTile> { Tiles[0], Tiles[1], Tiles[6] }, new List<BaseCharacters> { NPCS[0] }, 4, Towns[5]));
            MapCreators.Add(Maps[7].GenerateMapThread(new List<BaseTile> { Tiles[0], Tiles[1], Tiles[6] }, new List<BaseCharacters> { NPCS[0] }, 4, Towns[6]));
            MapCreators.Add(Maps[8].GenerateMapThread(new List<BaseTile> { Tiles[0], Tiles[1], Tiles[6] }, new List<BaseCharacters> { NPCS[0] }, 4, Towns[7]));
            MapCreators.Add(Maps[9].GenerateMapThread(new List<BaseTile> { Tiles[0], Tiles[1], Tiles[6] }, new List<BaseCharacters> { NPCS[0] }, 4, Towns[8]));
            MapCreators.Add(Maps[10].GenerateMapThread(new List<BaseTile> { Tiles[0], Tiles[1], Tiles[6] }, new List<BaseCharacters> { NPCS[0] }, 4, Towns[9]));

            EM = new EnemyManager();

            //Dungeons
            MapCreators.Add(Dungeons[0].GenerateMapThread(new List<BaseTile> { Tiles[0], Tiles[3] }, new List<BaseCharacters> { EM.enemies[0], EM.enemies[1], EM.enemies[2]}, 5));
            MapCreators.Add(Dungeons[1].GenerateMapThread(new List<BaseTile> { Tiles[0], Tiles[3] }, new List<BaseCharacters> { EM.enemies[0], EM.enemies[1], EM.enemies[2] }, 5));
            MapCreators.Add(Dungeons[2].GenerateMapThread(new List<BaseTile> { Tiles[0], Tiles[3] }, new List<BaseCharacters> { EM.enemies[0], EM.enemies[1], EM.enemies[2] }, 5));
            MapCreators.Add(Dungeons[3].GenerateMapThread(new List<BaseTile> { Tiles[0], Tiles[3] }, new List<BaseCharacters> { EM.enemies[0], EM.enemies[1], EM.enemies[2] }, 5));
        }
    }
}
