using AngelBorn.Grapihcs;
using AngelBorn.Grapihcs.MapGra;
using AngelBorn.Tools;
using AngelBorn.World.Tiles;
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
                        statsD.Draw(CW.GetPos().X + (MapD.ViewSize.X * 2) + 6, 2);
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
                        SingleTon.GetMapManagerInstance().CurrentMap = CT.LoadMap();
                        ConsoleColor.
                    return true;
                    }
                    else
                    {
                        return false;
                    }

                default:
                    return false;
            }
        }
    }
}
