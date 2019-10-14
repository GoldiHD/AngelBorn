using AngelBorn.Grapihcs;
using AngelBorn.Grapihcs.MapGra;
using AngelBorn.Menus;
using AngelBorn.Tools;
using AngelBorn.World;
using AngelBorn.World.Tiles;
using AngleBorn.Grapihcs;
using AngleBorn.Menus;
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
                        return CheckForMonster();
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
                        return CheckForMonster();
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
                        return CheckForMonster();
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
                        return CheckForMonster();
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
                        DrawInfoBox.AddToBox("You have entered " + CT.CityName);
                        CT.LoadMap().MapTile = SingleTon.GetCursorInstance().CurrentTile;
                        SingleTon.GetCursorInstance().CurrentTile = CT.CityMap.SpawnPoint;
                        SingleTon.GetMapManagerInstance().CurrentMap = CT.LoadMap();
                        CW.Clear();
                        return true;
                    }
                    else if (SingleTon.GetCursorInstance().CurrentTile is Dungeon)
                    {
                        Dungeon DG = (Dungeon)SingleTon.GetCursorInstance().CurrentTile;
                        DrawInfoBox.AddToBox("You have entered a dungeon");
                        DG.ParrentMap = SingleTon.GetMapManagerInstance().CurrentMap;
                        SingleTon.GetMapManagerInstance().CurrentMap = DG.LoadMap();
                        DG.DungeonMap.MyTile = SingleTon.GetCursorInstance().CurrentTile;
                        SingleTon.GetCursorInstance().CurrentTile = DG.LoadMap().SpawnPoint;
                        PlayManager.State = PlayerState.Dungeon;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case ConsoleKey.Escape:
                    CityTile cityTile = (CityTile)SingleTon.GetMapManagerInstance().CurrentMap.MapTile;
                    if (cityTile != null && cityTile.ParrentMap != null)
                    {
                        SingleTon.GetCursorInstance().CurrentTile = SingleTon.GetMapManagerInstance().CurrentMap.MapTile;
                        cityTile = (CityTile)SingleTon.GetMapManagerInstance().CurrentMap.MapTile;
                        SingleTon.GetMapManagerInstance().CurrentMap = cityTile.ParrentMap;
                    }
                    return true;

                case ConsoleKey.O:
                    if (IntroMenu.test)
                    {
                        PlayManager.State = PlayerState.Combat;
                        new CombatDraw().Draw(new Cord { X = 2, Y = 2 });
                        CW.ReadKey();
                    }
                    return false;

                case ConsoleKey.I:
                    PlayManager.State = PlayerState.Inventory;
                    CW.Clear();
                    new InventoryDraw().Draw();
                    return false;

                default:
                    return false;
            }
        }


        public bool MovementInDungeon()
        {
            Input = CW.ReadKey();
            switch (Input.Key)
            {
                case ConsoleKey.UpArrow:
                    if (SingleTon.GetMapManagerInstance().CurrentMap.CheckLocation(SingleTon.GetCursorInstance().CurrentTile.Pos.X, SingleTon.GetCursorInstance().CurrentTile.Pos.Y - 1))
                    {
                        SingleTon.GetCursorInstance().CurrentTile = SingleTon.GetMapManagerInstance().CurrentMap.Tiles[SingleTon.GetCursorInstance().CurrentTile.Pos.X, SingleTon.GetCursorInstance().CurrentTile.Pos.Y - 1];
                        SingleTon.GetPlayerController().Steps++;
                        return CheckForMonster();
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
                        return CheckForMonster();
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
                        return CheckForMonster();
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
                        return CheckForMonster();
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

                case ConsoleKey.Escape:
                    Dungeon DG = (Dungeon)SingleTon.GetMapManagerInstance().CurrentMap.MyTile;
                    if (DG != null && DG.ParrentMap != null)
                    {

                        SingleTon.GetCursorInstance().CurrentTile = DG.DungeonMap.MyTile;
                        SingleTon.GetMapManagerInstance().CurrentMap = DG.ParrentMap;
                        PlayManager.State = PlayerState.WorldMap;
                    }
                    return true;

                default:
                    return false;
            }
        }

        public bool CheckForMonster()
        {
            if (SingleTon.PercentChance(SingleTon.GetCursorInstance().CurrentTile.ChanceAtMonsters))
            {
                PlayManager.State = PlayerState.Combat;
                SingleTon.GetPlayerController().CBM.CheckForEnemy(SingleTon.GetCursorInstance().CurrentTile);
                DrawInfoBox.AddToBox("You have encountered a " + SingleTon.GetPlayerController().CBM.enemyFighting.Name);
                new CombatDraw().Draw(new Cord { X = 2, Y = 2 });
                return false;
            }
            else
            {
                return true;
            }
        }

        public CombatMenuReturn CombatMenuNavigation()
        {
            switch (CW.ReadKey().Key)
            {
                case ConsoleKey.UpArrow:
                    if (CombatDraw.IndexMenu > 0)
                    {
                        CombatDraw.IndexMenu--;
                    }
                    return CombatMenuReturn.Menu;

                case ConsoleKey.DownArrow:
                    if (CombatDraw.ActiveMenuList.Count - 1 > CombatDraw.IndexMenu && CombatDraw.IndexMenu < 10)
                    {
                        CombatDraw.IndexMenu++;
                    }
                    return CombatMenuReturn.Menu;

                case ConsoleKey.Enter:
                    switch (CombatDraw.MenuState)
                    {
                        case CombatDraw.ActionMenus.Ablilites:

                            break;

                        case CombatDraw.ActionMenus.Items:

                            break;

                        case CombatDraw.ActionMenus.Main:
                            switch (CombatDraw.IndexMenu)
                            {
                                case 0:
                                    DrawInfoBox.AddToBox("You attacked " + SingleTon.GetPlayerController().CBM.enemyFighting.Name);
                                    SingleTon.GetPlayerController().CBM.enemyFighting.TakeDamage(SingleTon.GetPlayerController().Skills.Power.Buff + SingleTon.GetPlayerController().Skills.Power.ExtraAttack);
                                    SingleTon.GetPlayerController().CBM.enemyFighting.SetDamage();
                                    SingleTon.GetPlayerController().Skills.Vitallity.TakeDamage(SingleTon.GetPlayerController().CBM.enemyFighting.Damage);
                                    if(SingleTon.GetPlayerController().Skills.Vitallity.HealthCurrent == 0)
                                    {
                                       
                                    }
                                    else if(SingleTon.GetPlayerController().CBM.enemyFighting.Health == 0)
                                    {
                                        if (SingleTon.GetCursorInstance().CurrentTile.MyType == TileType.Dungeon)
                                        {
                                            PlayManager.State = PlayerState.Dungeon;
                                        }
                                        else if (SingleTon.GetCursorInstance().CurrentTile.MyType == TileType.Normal)
                                        {
                                            PlayManager.State = PlayerState.WorldMap;
                                        }
                                        SingleTon.GetPlayerController().AddXP(SingleTon.GetPlayerController().CBM.enemyFighting.Xp);
                                        SingleTon.GetPlayerController().Inventory.AddGold(SingleTon.GetPlayerController().CBM.enemyFighting.GetGold());
                                        SingleTon.GetPlayerController().CBM.enemyFighting.EndCombat();
                                        CW.Clear();
                                        MapD.DrawMap();
                                        return CombatMenuReturn.None;
                                    }
                                    break;

                                case 1:
                                    CombatDraw.MenuState = CombatDraw.ActionMenus.Items;
                                    break;

                                case 2:
                                    CombatDraw.MenuState = CombatDraw.ActionMenus.Ablilites;
                                    break;

                                case 3:
                                    DrawInfoBox.AddToBox("You tried to flee from " + SingleTon.GetPlayerController().CBM.enemyFighting.Name);
                                    if (SingleTon.PercentChance(SingleTon.GetPlayerController().CBM.enemyFighting.FleeChance))
                                    {
                                        DrawInfoBox.AddToBox("You succeded and escaped " + SingleTon.GetPlayerController().CBM.enemyFighting.Name);
                                        if (SingleTon.GetCursorInstance().CurrentTile.MyType == TileType.Dungeon)
                                        {
                                            PlayManager.State = PlayerState.Dungeon;
                                        }
                                        else if(SingleTon.GetCursorInstance().CurrentTile.MyType == TileType.Normal)
                                        {
                                            PlayManager.State = PlayerState.WorldMap;
                                        }
                                        CW.Clear();
                                        MapD.DrawMap();
                                        return CombatMenuReturn.None;
                                    }
                                    else
                                    {
                                        DrawInfoBox.AddToBox("You failed and didn't escape " + SingleTon.GetPlayerController().CBM.enemyFighting.Name);
                                    }
                                    break;
                            }
                            break;
                    }
                    return CombatMenuReturn.All;

                case ConsoleKey.H:
                    SingleTon.GetPlayerController().Skills.Vitallity.Heal(1000);
                    return CombatMenuReturn.None;
                default:
                    return CombatMenuReturn.None;
            }
        }
    }
    public enum CombatMenuReturn
    {
        None, All, Log, LogAndStatBlock, StatAndMenu, Menu, LogStatMenu
    }
}
