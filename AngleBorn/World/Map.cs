using AngelBorn.Tools;
using AngelBorn.World.Enemies;
using AngelBorn.World.Tiles;
using AngleBorn.World;
using AngleBorn.World.NPCS;
using AngleBorn.World.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AngelBorn.World
{
    class Map
    {

        public BaseTile SpawnPoint;
        public BaseTile MyTile;
        public BaseTile[,] Tiles;
        public BaseTile MapTile;
        public List<BaseTile> SetRooms = new List<BaseTile>();
        public Cord MapSize { get; private set; }
        public Map(Cord mapSize)
        {
            MapSize = mapSize;
            Tiles = new BaseTile[mapSize.X, mapSize.Y];
        }
        private List<BaseNPC> NPCS;
        public List<TileNPC> AllNPCs { get; private set; }
        private Cord Location;

        public Thread GenerateMapThread(List<BaseTile> tiles, List<CityTile> Locations, List<BaseCharacters> SpawnAbleEnemies, int amountOfDungeon)
        {

            Thread Generator;
            Generator = new Thread(new ParameterizedThreadStart(GenerateMap));
            MapData MD;
            MD.Locations = Locations;
            MD.tiles = tiles;
            MD.SpawnAbleEnemies = SpawnAbleEnemies;
            MD.AmountOfDungeonOrHouses = amountOfDungeon;
            Generator.Start(MD);

            return Generator;
        }

        public Thread GenerateMapThread(List<BaseTile> tiles, List<BaseCharacters> enemies, int chests)
        {
            Thread Generator;
            Generator = new Thread(new ParameterizedThreadStart(GenerateDungeon));
            MapData MD;
            MD.Locations = new List<CityTile>();
            MD.tiles = tiles;
            MD.SpawnAbleEnemies = enemies;
            MD.AmountOfDungeonOrHouses = chests;
            Generator.Start(MD);

            return Generator;
        }

        public Thread GenerateMapThread(List<BaseTile> tiles, List<BaseCharacters> npcs, int house, BaseTile ThisTile)
        {
            MyTile = ThisTile;
            Thread Generator;
            Generator = new Thread(new ParameterizedThreadStart(GenerateTown));
            MapData MD;
            MD.Locations = new List<CityTile>();
            MD.tiles = tiles;
            MD.SpawnAbleEnemies = npcs;
            MD.AmountOfDungeonOrHouses = house;
            Generator.Start(MD);

            return Generator;
        }

        private void GenerateDungeon(object MD)
        {
            MapData Temp = (MapData)MD;
            List<BaseTile> tiles = Temp.tiles;
            for (int y = 0; y < MapSize.Y; y++)
            {
                for (int x = 0; x < MapSize.X; x++)
                {
                    Tiles[x, y] = new BaseTile().CopyOf(tiles[1]);
                    Tiles[x, y].Pos = new Cord { X = x, Y = y };
                }
            }
            SpawnPoint = Tiles[0, 0];
        }

        private bool CheckHouse()
        {
            Location = new Cord { X = SingleTon.GetRandomNum(0, MapSize.X), Y = SingleTon.GetRandomNum(0, MapSize.Y) };
            List<Cord> CheckList = new List<Cord> { new Cord { X = Location.X - 1, Y = Location.Y }, new Cord { X = Location.X - 2, Y = Location.Y }, new Cord { X = Location.X - 2, Y = Location.Y - 1 }, new Cord { X = Location.X - 2, Y = Location.Y - 2 }, new Cord { X = Location.X - 2, Y = Location.Y - 3 }, new Cord { X = Location.X - 2, Y = Location.Y - 4 }, new Cord { X = Location.X - 1, Y = Location.Y - 4 }, new Cord { X = Location.X, Y = Location.Y - 4 }, new Cord { X = Location.X + 1, Y = Location.Y - 4 }, new Cord { X = Location.X + 2, Y = Location.Y - 4 }, new Cord { X = Location.X + 2, Y = Location.Y - 3 }, new Cord { X = Location.X + 2, Y = Location.Y - 2 }, new Cord { X = Location.X + 2, Y = Location.Y - 1 }, new Cord { X = Location.X + 2, Y = Location.Y }, new Cord { X = Location.X + 1, Y = Location.Y } };
            foreach (Cord element in CheckList)
            {
                if (MapSize.X <= element.X || 0 > element.X || MapSize.Y <= element.Y || 0 > element.Y)
                {
                    return false;
                }
                if (Tiles[element.X, element.Y].MyType != TileType.Normal)
                {
                    return false;
                }
            }
            return true;
        }

        private void CreateHouse(Cord cord, BaseTile Wall)
        {
            List<Cord> CheckList = new List<Cord> { new Cord { X = Location.X - 1, Y = Location.Y }, new Cord { X = Location.X - 2, Y = Location.Y }, new Cord { X = Location.X - 2, Y = Location.Y - 1 }, new Cord { X = Location.X - 2, Y = Location.Y - 2 }, new Cord { X = Location.X - 2, Y = Location.Y - 3 }, new Cord { X = Location.X - 2, Y = Location.Y - 4 }, new Cord { X = Location.X - 1, Y = Location.Y - 4 }, new Cord { X = Location.X, Y = Location.Y - 4 }, new Cord { X = Location.X + 1, Y = Location.Y - 4 }, new Cord { X = Location.X + 2, Y = Location.Y - 4 }, new Cord { X = Location.X + 2, Y = Location.Y - 3 }, new Cord { X = Location.X + 2, Y = Location.Y - 2 }, new Cord { X = Location.X + 2, Y = Location.Y - 1 }, new Cord { X = Location.X + 2, Y = Location.Y }, new Cord { X = Location.X + 1, Y = Location.Y } };
            foreach (Cord element in CheckList)
            {
                Tiles[element.X, element.Y] = Wall;
            }
            if (NPCS.Count >= 2)
            {
                int rand = SingleTon.GetRandomNum(0, 3);
                if (rand != 0)
                {
                    for (int b = 0; b < rand; ++b)
                    {
                        BaseNPC npc = NPCS[SingleTon.GetRandomNum(0, NPCS.Count)];
                        Cord pos = new Cord { X = SingleTon.GetRandomNum(Location.X - 1, Location.X + 2), Y = SingleTon.GetRandomNum(Location.Y - 3, Location.Y) };
                        Tiles[pos.X, pos.Y] = new TileNPC(npc.Name, true, pos);
                        AllNPCs.Add((TileNPC)Tiles[pos.X, pos.Y]);
                        NPCS.Remove(npc);
                    }
                }
            }
            else if (NPCS.Count == 1)
            {
                Cord pos = new Cord { X = SingleTon.GetRandomNum(Location.X - 1, Location.X + 2), Y = SingleTon.GetRandomNum(Location.Y - 3, Location.Y) };
                Tiles[pos.X, pos.Y] = new TileNPC(NPCS[0].Name, true, pos);
                NPCS.RemoveAt(0);
            }
        }

        private void GenerateTown(object MD)
        {
            AllNPCs = new List<TileNPC>();
            MapData Temp = (MapData)MD;
            List<BaseTile> tiles = Temp.tiles;
            NPCS = Temp.SpawnAbleEnemies.Select(x => (BaseNPC)x).ToList();

            for (int y = 0; y < MapSize.Y; y++)
            {
                for (int x = 0; x < MapSize.X; x++)
                {
                    Tiles[x, y] = new BaseTile().CopyOf(tiles[1]);
                    Tiles[x, y].Pos = new Cord { X = x, Y = y };
                }
            }
            for (int i = 0; i < Temp.AmountOfDungeonOrHouses; i++)
            {
                if (CheckHouse())
                {
                    CreateHouse(Location, Temp.tiles[0]);
                }
                else
                { i--; }
            }
            while (true)
            {
                Location = new Cord { X = SingleTon.GetRandomNum(0, MapSize.X), Y = SingleTon.GetRandomNum(0, MapSize.Y) };
                if (Tiles[Location.X, Location.Y].MyType == TileType.Normal)
                {
                    SpawnPoint = Tiles[Location.X, Location.Y];
                    return;
                }
            }
        }

        private void GenerateMap(object MD)
        {
            MapData Temp = (MapData)MD;
            List<BaseTile> tiles = Temp.tiles;
            List<CityTile> Locations = Temp.Locations;
            List<Enemy> SpawnAbleEnemies = Temp.SpawnAbleEnemies.Select(x => (Enemy)x).ToList();
            List<int> Sides;
            Cord Test;
            bool RoomFound = false;
            int SideToCheck;
            FillOutNull();
            Tiles[MapSize.X / 2, MapSize.Y / 2] = new Dungeon();
            SetRooms.Add(Tiles[MapSize.X / 2, MapSize.Y / 2]);
            Tiles[MapSize.X / 2, MapSize.Y / 2].Pos = new Cord { X = MapSize.X / 2, Y = MapSize.Y / 2 };
            Test = new Cord { X = SingleTon.GetRandomNum(0, MapSize.X), Y = SingleTon.GetRandomNum(0, MapSize.Y) };
            for (int i = 1; i < (((float)MapSize.X * (float)MapSize.Y) / 1.5f); i++)
            {
                Sides = new List<int> { 0, 1, 2, 3 };
                RoomFound = false;
                for (int x = 0; x < 4; x++)
                {
                    SideToCheck = SingleTon.GetRandomNum(0, Sides.Count);
                    switch (SideToCheck)
                    {
                        case 0:
                            if (Test.X + 1 < MapSize.X && Tiles[Test.X + 1, Test.Y].MyType == TileType.Inpassable)
                            {
                                Test.X++;
                                RoomFound = true;
                            }
                            else
                            {
                                Sides.Remove(SideToCheck);
                            }
                            break;

                        case 1:
                            if (Test.X - 1 >= 0 && Tiles[Test.X - 1, Test.Y].MyType == TileType.Inpassable)
                            {
                                Test.X--;
                                RoomFound = true;
                            }
                            else
                            {
                                Sides.Remove(SideToCheck);
                            }
                            break;

                        case 2:
                            if (Test.Y + 1 < MapSize.Y && Tiles[Test.X, Test.Y + 1].MyType == TileType.Inpassable)
                            {
                                Test.Y++;
                                RoomFound = true;
                            }
                            else
                            {
                                Sides.Remove(SideToCheck);
                            }
                            break;

                        case 3:
                            if (Test.Y - 1 >= 0 && Tiles[Test.X, Test.Y - 1].MyType == TileType.Inpassable)
                            {
                                Test.Y--;
                                RoomFound = true;
                            }
                            break;
                    }

                    if (RoomFound)
                    {
                        Tiles[Test.X, Test.Y] = new BaseTile().CopyOf(tiles[SingleTon.GetRandomNum(0, tiles.Count)]);
                        SetRooms.Add(Tiles[Test.X, Test.Y]);
                        Tiles[Test.X, Test.Y].Pos = Test;
                        break;
                    }
                    else if (x == 3)
                    {
                        if (SingleTon.GetRandomNum(0, 4) == 0)
                        {
                            SetRandomRoom(tiles);
                        }
                        else
                        {
                            Test = SetRelativeRoom();
                            i--;
                        }
                    }
                }
            }
            SetDungeons(Temp.AmountOfDungeonOrHouses);
            FillLocations(Locations);

        }

        public void SetPlayerSpawn()
        {
            Cord Location;
            while (true)
            {
                Location = new Cord { X = SingleTon.GetRandomNum(0, MapSize.X), Y = SingleTon.GetRandomNum(0, MapSize.Y) };
                if (Tiles[Location.X, Location.Y].MyType == TileType.Normal)
                {

                    SingleTon.GetCursorInstance().CurrentTile = Tiles[Location.X, Location.Y];
                    return;
                }
            }
        }

        private void SetRandomRoom(List<BaseTile> tiles)
        {
            bool RoomFound = false;
            Cord Test;
            do
            {
                int x = SingleTon.GetRandomNum(0, MapSize.X);
                int y = SingleTon.GetRandomNum(0, MapSize.Y);
                Test = new Cord { X = x, Y = y  };
                if (Tiles[Test.X, Test.Y].MyType == TileType.Inpassable)
                {
                    Tiles[Test.X, Test.Y] = new BaseTile().CopyOf(tiles[SingleTon.GetRandomNum(0, tiles.Count)]);
                    SetRooms.Add(Tiles[Test.X, Test.Y]);
                    Tiles[Test.X, Test.Y].Pos = new Cord { X = Test.X, Y = Test.Y };
                    RoomFound = true;
                }
            } while (!RoomFound);
        }

        private Cord SetRelativeRoom()
        {
            Cord NewCord;
            while (true)
            {
                NewCord = SetRooms[SingleTon.GetRandomNum(0, SetRooms.Count)].Pos;
                //NewCord = new Cord { X = SingleTon.GetRandomNum(0, MapSize.X), Y = SingleTon.GetRandomNum(0, MapSize.Y) };
                if (Tiles[NewCord.X, NewCord.Y].MyType == TileType.Normal)
                {
                    return NewCord;
                }
            }
        }

        private void SetDungeons(int amount)
        {
            Cord cord;
            bool roomFound;
            for (int i = 0; i < amount; i++)
            {
                roomFound = false;
                do
                {
                    cord = new Cord { X = SingleTon.GetRandomNum(0, MapSize.X), Y = SingleTon.GetRandomNum(0, MapSize.Y) };
                    if (Tiles[cord.X, cord.Y].MyType == TileType.Normal)
                    {
                        Tiles[cord.X, cord.Y] = new Dungeon();
                        Tiles[cord.X, cord.Y].Pos = cord;

                        roomFound = true;
                    }
                } while (!roomFound);
            }
        }


        private void FillLocations(List<CityTile> _Locations)
        {
            Cord cord;
            bool roomFound;
            for (int i = 0; i < _Locations.Count; i++)
            {
                roomFound = false;
                do
                {
                    cord = new Cord { X = SingleTon.GetRandomNum(0, MapSize.X), Y = SingleTon.GetRandomNum(0, MapSize.Y) };
                    if (Tiles[cord.X, cord.Y].MyType == TileType.Normal)
                    {
                        Tiles[cord.X, cord.Y] = new CityTile().CopyOf(_Locations[i]);
                        _Locations[i].Pos = cord;
                        Tiles[cord.X, cord.Y].Pos = cord;

                        roomFound = true;
                    }
                }
                while (!roomFound);

            }
        }

        private void FillOutNull()
        {
            BaseTile ImPassble = new BaseTile() { TileName = "Moutain", Walkable = false, MyType = TileType.Inpassable };
            //fill all the empthy areas with impassble things
            for (int x = 0; x < MapSize.X; x++)
            {
                for (int y = 0; y < MapSize.Y; y++)
                {
                    Tiles[x, y] = new BaseTile().CopyOf(ImPassble);
                    Tiles[x, y].Pos = new Cord { X = x, Y = y };
                }
            }
        }

        #region MovementChecking
        public bool CheckLocation(int x, int y)
        {
            if (x > -1 && x < MapSize.X && y > -1 && y < MapSize.Y)
            {
                if (Tiles[x, y].MyType != TileType.Inpassable)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

    }
    struct MapData
    {
        public List<BaseTile> tiles;
        public List<CityTile> Locations;
        public List<BaseCharacters> SpawnAbleEnemies;
        public int AmountOfDungeonOrHouses;
    }
}
