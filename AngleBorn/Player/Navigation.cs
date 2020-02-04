using AngelBorn.Grapihcs;
using AngelBorn.Grapihcs.MapGra;
using AngelBorn.Menus;
using AngelBorn.Tools;
using AngelBorn.World;
using AngelBorn.World.Tiles;
using AngleBorn.Grapihcs;
using AngleBorn.Items;
using AngleBorn.Menus;
using AngleBorn.World.Tiles;
using System;

namespace AngleBorn.Player
{
    class Navigation
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
                
                SingleTon.GetPlayerController().CBM.CheckForEnemy(SingleTon.GetCursorInstance().CurrentTile);
                if (SingleTon.GetPlayerController().CBM.enemyFighting != null)
                {
                    PlayManager.State = PlayerState.Combat;
                    DrawInfoBox.AddToBox("You have encountered a " + SingleTon.GetPlayerController().CBM.enemyFighting.Name);
                    new CombatDraw().Draw(new Cord { X = 2, Y = 2 });
                    return false;
                }
                return true;
            }
            else
            {
                return true;
            }
        }

        public InventoryMenuReturn InventoryNavigation()
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.UpArrow:

                    if (InventoryDraw.InventoryIndex <= 1)
                    {
                        InventoryDraw.InventoryIndex = SingleTon.GetPlayerController().Inventory.Inventory.Count;
                    }
                    else
                    {
                        InventoryDraw.InventoryIndex--;
                    }
                    return InventoryMenuReturn.DrawInventoryContainer;

                case ConsoleKey.DownArrow:
                    if (SingleTon.GetPlayerController().Inventory.Inventory.Count == InventoryDraw.InventoryIndex)
                    {
                        InventoryDraw.InventoryIndex = 1;
                    }
                    else
                    {
                        InventoryDraw.InventoryIndex++;
                    }
                    return InventoryMenuReturn.DrawInventoryContainer;

                case ConsoleKey.LeftArrow://minus
                    if(InventoryDraw.state == InventoryDrawMenuState.All)
                    {
                        InventoryDraw.state = InventoryDrawMenuState.Misc;
                    }
                    else
                    {
                        InventoryDraw.state--;
                    }
                    return InventoryMenuReturn.Everything;

                case ConsoleKey.RightArrow://plus
                    if(InventoryDraw.state == InventoryDrawMenuState.Misc)
                    {
                        InventoryDraw.state = InventoryDrawMenuState.All;
                    }
                    else
                    {
                        InventoryDraw.state++;
                    }
                    return InventoryMenuReturn.Everything;

                case ConsoleKey.Enter:

                    if(SingleTon.GetPlayerController().Inventory.Inventory[InventoryDraw.InventoryIndex - 1] is EquippableItem item)
                    {
                        if (SingleTon.GetPlayerController().Inventory.CheckIfItemsIsEquipped(item))
                        {
                            item.UnEquip();
                        }
                        else
                        {
                            item.Equip();
                        }
                        return InventoryMenuReturn.Everything;
                    }
                    break;

                case ConsoleKey.Escape:
                    Console.Clear();
                    new MapDraw().DrawMap();
                    PlayManager.State = PlayManager.PreviousState;
                    return InventoryMenuReturn.None;
            }
            return InventoryMenuReturn.None;
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
                            throw new NotImplementedException();
                            break;

                        case CombatDraw.ActionMenus.Items:
                            throw new NotImplementedException();
                            break;

                        case CombatDraw.ActionMenus.Main:
                            switch (CombatDraw.IndexMenu)
                            {
                                case 0:
                                    SingleTon.GetPlayerController().CBM.enemyFighting.SetDamage();
                                    DrawInfoBox.AddToBox("You attacked " + SingleTon.GetPlayerController().CBM.enemyFighting.Name + " and dealt " + SingleTon.GetPlayerController().Skills.Vitallity.TakeDamage(SingleTon.GetPlayerController().CBM.enemyFighting.Damage) + ", "+ SingleTon.GetPlayerController().CBM.enemyFighting.Name + " hits back and damages you " + SingleTon.GetPlayerController().CBM.enemyFighting.TakeDamage(SingleTon.GetPlayerController().Skills.Power.Buff + SingleTon.GetPlayerController().Skills.Power.ExtraAttack));
                                    if (SingleTon.GetPlayerController().Skills.Vitallity.HealthCurrent == 0)
                                    {

                                    }
                                    else if (SingleTon.GetPlayerController().CBM.enemyFighting.Health == 0)
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
                                        else if (SingleTon.GetCursorInstance().CurrentTile.MyType == TileType.Normal)
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

                default:
                    return CombatMenuReturn.None;
            }
        }
    }
    public enum CombatMenuReturn
    {
        None, All, Log, LogAndStatBlock, StatAndMenu, Menu, LogStatMenu
    }

    public enum InventoryMenuReturn
    {
        None, Gold, TabsAndDrawInventoryContainer, DrawInventoryContainer, Everything
    }
}
