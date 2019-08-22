using AngelBorn.Grapihcs;
using AngelBorn.Grapihcs.MapGra;
using AngelBorn.Tools;
using AngelBorn.World;
using AngelBorn.World.Tiles;
using AngleBorn.Grapihcs;
using AngleBorn.World.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngleBorn.Player
{
    class Movement 
    {
        private ConsoleKeyInfo Input;
        private MapDraw MapD = new MapDraw();
        private DrawStats statsD = new DrawStats();
        private bool DrawStats = false;
        public bool CheckMoveMent()
        {
            Input = CW.ReadKey();
            switch (Input.Key)
            {
                case ConsoleKey.UpArrow:
                    if (SingleTon.GetMapManagerInstance().CurrentMap.CheckLocation(SingleTon.GetCursorInstance().CurrentTile.Pos.X, SingleTon.GetCursorInstance().CurrentTile.Pos.Y - 1))
                    {
                        SingleTon.GetCursorInstance().CurrentTile = SingleTon.GetMapManagerInstance().CurrentMap.Tiles[SingleTon.GetCursorInstance().CurrentTile.Pos.X, SingleTon.GetCursorInstance().CurrentTile.Pos.Y - 1];
                        SingleTon.GetPlayerController().Steps++;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case ConsoleKey.DownArrow:
                    if (SingleTon.GetMapManagerInstance().CurrentMap.CheckLocation(SingleTon.GetCursorInstance().CurrentTile.Pos.X, SingleTon.GetCursorInstance().CurrentTile.Pos.Y + 1))
                    {
                        SingleTon.GetCursorInstance().CurrentTile = SingleTon.GetMapManagerInstance().CurrentMap.Tiles[SingleTon.GetCursorInstance().CurrentTile.Pos.X, SingleTon.GetCursorInstance().CurrentTile.Pos.Y + 1];
                        SingleTon.GetPlayerController().Steps++;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case ConsoleKey.LeftArrow:
                    if (SingleTon.GetMapManagerInstance().CurrentMap.CheckLocation(SingleTon.GetCursorInstance().CurrentTile.Pos.X - 1, SingleTon.GetCursorInstance().CurrentTile.Pos.Y))
                    {
                        SingleTon.GetCursorInstance().CurrentTile = SingleTon.GetMapManagerInstance().CurrentMap.Tiles[SingleTon.GetCursorInstance().CurrentTile.Pos.X - 1, SingleTon.GetCursorInstance().CurrentTile.Pos.Y];
                        SingleTon.GetPlayerController().Steps++;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case ConsoleKey.RightArrow:
                    if (SingleTon.GetMapManagerInstance().CurrentMap.CheckLocation(SingleTon.GetCursorInstance().CurrentTile.Pos.X + 1, SingleTon.GetCursorInstance().CurrentTile.Pos.Y))
                    {
                        SingleTon.GetCursorInstance().CurrentTile = SingleTon.GetMapManagerInstance().CurrentMap.Tiles[SingleTon.GetCursorInstance().CurrentTile.Pos.X + 1, SingleTon.GetCursorInstance().CurrentTile.Pos.Y];
                        SingleTon.GetPlayerController().Steps++;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case ConsoleKey.S:
                    DrawStats = !DrawStats;
                    if (DrawStats)
                    {
                        statsD.Draw(CW.GetPos().X + (MapDraw.ViewSize.X * 2) + 6, 2);
                        return false;
                    }
                    else
                    {
                        CW.Clear();
                        return true;
                    }

                case ConsoleKey.Enter:
                    if (SingleTon.GetCursorInstance().CurrentTile is CityTile)
                    {
                        CityTile CT = (CityTile)SingleTon.GetCursorInstance().CurrentTile;
                        DrawInfoBox.Inputs.Add("You have entered " + CT.CityName); 
                        CT.LoadMap().MapTile = SingleTon.GetCursorInstance().CurrentTile;
                        SingleTon.GetCursorInstance().CurrentTile = CT.CityMap.SpawnPoint;
                        SingleTon.GetMapManagerInstance().CurrentMap = CT.LoadMap();
                        CW.Clear();
                        return true;
                    }
                    else if (SingleTon.GetCursorInstance().CurrentTile is Dungeon)
                    {
                        Dungeon DG = (Dungeon)SingleTon.GetCursorInstance().CurrentTile;
                        DrawInfoBox.Inputs.Add("You have entered a dungeon");
                        DG.LoadMap().MapTile = SingleTon.GetCursorInstance().CurrentTile;
                        SingleTon.GetCursorInstance().CurrentTile = DG.DungeonMap.SpawnPoint;
                        SingleTon.GetMapManagerInstance().CurrentMap = DG.LoadMap();
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case ConsoleKey.Escape:
                    CityTile cityTile = (CityTile)SingleTon.GetMapManagerInstance().CurrentMap.MapTile;
                    if (cityTile == null || cityTile.ParrentMap != null)
                    {
                        SingleTon.GetCursorInstance().CurrentTile = SingleTon.GetMapManagerInstance().CurrentMap.MapTile;
                        cityTile = (CityTile)SingleTon.GetMapManagerInstance().CurrentMap.MapTile;
                        SingleTon.GetMapManagerInstance().CurrentMap = cityTile.ParrentMap;
                    }
                    return true;

                default:
                    return false;
            }
        }
    }
}
