using AngelBorn.Tools;
using AngelBorn.World.Enemies;
using AngelBorn.World.Tiles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AngelBorn.World
{
    class Map
    {
        public BaseTile[,] Tiles;
        public Cord MapSize { get; private set; }
        public Map(Cord mapSize)
        {
            MapSize = mapSize;
            Tiles = new BaseTile[mapSize.X, mapSize.Y];
        }

        public Thread GenerateMapThread(List<BaseTile> tiles, List<CityTile> Locations, List<Enemy> SpawnAbleEnemies)
        {

            Thread Generator;
            Generator = new Thread(new ParameterizedThreadStart(GenerateMap));
            MapData MD;
            MD.Locations = Locations;
            MD.tiles = tiles;
            MD.SpawnAbleEnemies = SpawnAbleEnemies;
            Generator.Name = "Map";
            Generator.Start(MD);

            return Generator;
        }

        void GenerateMap(object MD)
        {
            List<BaseTile> FullArray = new List<BaseTile>();
            MapData Temp = (MapData)MD;
            List<BaseTile> tiles = Temp.tiles;
            List<CityTile> Locations = Temp.Locations;
            List<Enemy> SpawnAbleEnemies = Temp.SpawnAbleEnemies;
            List<int> Sides;
            Cord Test;
            bool RoomFound = false;
            int SideToCheck;
            FillOutNull();
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
            FillLocations(Locations);
        }

        public void SetPlayerSpawn()
        {
            Cord Location;
            while(true)
            {
                Location = new Cord { X = SingleTon.GetRandomNum(0, MapSize.X), Y = SingleTon.GetRandomNum(0, MapSize.Y) };
                if(Tiles[Location.X, Location.Y].MyType == TileType.Normal)
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
                Test = new Cord { X = SingleTon.GetRandomNum(0, MapSize.X), Y = SingleTon.GetRandomNum(0, MapSize.Y) };
                if (Tiles[Test.X, Test.Y].MyType == TileType.Inpassable)
                {
                    Tiles[Test.X, Test.Y] = new BaseTile().CopyOf(tiles[SingleTon.GetRandomNum(0, tiles.Count)]);
                    Tiles[Test.X, Test.Y].Pos = new Cord { X = Test.X, Y = Test.Y };
                    RoomFound = true;
                }
            } while (!RoomFound);
        }

        private Cord SetRelativeRoom()
        {
            Cord NewCord;
            while(true)
            {
                NewCord = new Cord { X = SingleTon.GetRandomNum(0, MapSize.X), Y = SingleTon.GetRandomNum(0, MapSize.Y) };
                if(Tiles[NewCord.X, NewCord.Y].MyType == TileType.Normal)
                {
                    return NewCord;
                }
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
                        Tiles[cord.X, cord.Y] = new CityTile().CopyOf(_Locations[i], this);
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
            if(x > 0 && x < MapSize.X && y > 0 && y < MapSize.Y)
            {
                if(Tiles[x,y].MyType != TileType.Inpassable)
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
        public List<Enemy> SpawnAbleEnemies;
    }
}
