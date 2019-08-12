﻿using AngelBorn.Tools;
using AngelBorn.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace AngelBorn.Grapihcs.MapGra
{
    class MapDraw
    {
        private Map CurrentMap;
        public Cord ViewSize = new Cord() { X = 21 , Y = 21 }; //always take uneven numbers
        private Cord StartDrawingPos = new Cord();

        public void DrawMap()
        {
            CurrentMap = SingleTon.GetMapManagerInstance().CurrentMap;
            if (WithInBorder(Axis.Y))
            {
                StartDrawingPos.Y = SingleTon.GetCursorInstance().Pos.Y - ((ViewSize.Y / 2));
            }
            if(WithInBorder(Axis.X))
            {
                StartDrawingPos.X = SingleTon.GetCursorInstance().Pos.X - ((ViewSize.X / 2));
            }

            CW.SetPos(1, 1);
            CW.Write("[X: " + SingleTon.GetCursorInstance().Pos.X + " | Y: " + SingleTon.GetCursorInstance().Pos.Y + "]");
            CW.SetPos(1, 2);
            for (int y = 0; y < ViewSize.Y; y++)
            {
                for (int x = 0; x < ViewSize.X; x++)
                {

                    if (StartDrawingPos.X + x == SingleTon.GetCursorInstance().Pos.X && StartDrawingPos.Y + y == SingleTon.GetCursorInstance().Pos.Y)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(" O");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        switch (CurrentMap.Tiles[(StartDrawingPos.X + x), (StartDrawingPos.Y + y)].MyType)
                        {
                            case TileType.Inpassable:
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write(" #");
                                Console.ForegroundColor = ConsoleColor.White;
                                break;

                            case TileType.Normal:
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.Write(" ¤");
                                Console.ForegroundColor = ConsoleColor.White;
                                break;


                            case TileType.Town:
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.Write(" @");
                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                        }

                    }
                }
                CW.WriteLine("");
                CW.Write(" ");
            }


        }

        private bool WithInBorder(Axis axis)
        {
            if (axis == Axis.X)
            {
                if (SingleTon.GetCursorInstance().Pos.X + (ViewSize.X / 2) >= CurrentMap.MapSize.X - 1)
                {
                    StartDrawingPos.X = (SingleTon.GetCursorInstance().Pos.X - (ViewSize.X / 2)) + (CurrentMap.MapSize.X - (SingleTon.GetCursorInstance().Pos.X + (ViewSize.X / 2) + 1));
                    return false;
                }
                else if (SingleTon.GetCursorInstance().Pos.X - (ViewSize.X / 2) < 0)
                {
                    StartDrawingPos.X = 0;
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (axis == Axis.Y)
            {
                if (SingleTon.GetCursorInstance().Pos.Y + (ViewSize.Y / 2) > CurrentMap.MapSize.Y - 1)
                {
                    StartDrawingPos.Y = (SingleTon.GetCursorInstance().Pos.Y - (ViewSize.Y/2)) + (CurrentMap.MapSize.Y - (SingleTon.GetCursorInstance().Pos.Y + (ViewSize.Y/2) + 1));
                    return false;
                }
                else if (SingleTon.GetCursorInstance().Pos.Y - (ViewSize.Y / 2) < 0)
                {
                    StartDrawingPos.Y = 0;
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else return true;
        }

        private enum Axis
        {
            X, Y
        }
    }
}