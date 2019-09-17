using AngelBorn.Grapihcs;
using AngelBorn.Grapihcs.MapGra;
using AngelBorn.Player.Inventory;
using AngelBorn.Tools;
using AngelBorn.World;
using AngleBorn.Grapihcs;
using AngleBorn.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngleBorn.Menus
{
    class PlayManager
    {
        public InventoryManager inventory { get; private set; }
        public static PlayerState State;
        private MapDraw ViewMap = new MapDraw();
        private DrawStats ViewStats = new DrawStats();
        private Movement movement = new Movement();
        private DrawInfoBox DIB = new DrawInfoBox();
        private CombatDraw CD = new CombatDraw();
        private int infoBoardSize = 0;

        public void Run()
        {
            State = PlayerState.WorldMap;
            CW.Clear();
            ViewMap.DrawMap();

            while (true)
            {
                switch (State)
                {
                    case PlayerState.WorldMap:
                        if (infoBoardSize < DrawInfoBox.Inputs.Count)
                        {
                            DIB.Draw(2, MapDraw.ViewSize.Y * 2 + 3);
                        }
                        if (movement.CheckMoveMent())
                        {
                            ViewMap.DrawMap();
                        }

                        break;

                    case PlayerState.Dungeon:
                        if (infoBoardSize < DrawInfoBox.Inputs.Count)
                        {
                            DIB.Draw(2, MapDraw.ViewSize.Y * 2 + 3);
                        }
                        if (movement.MovementInDungeon())
                        {
                            ViewMap.DrawMap();
                        }
                        break;

                    case PlayerState.Store:

                        break;

                    case PlayerState.Combat:
                        switch (movement.CombatMenuNavigation())
                        {

                            case CombatMenuReturn.Menu:
                                CD.RedrawAcionMenu();
                                break;

                            case CombatMenuReturn.LogAndStatBlock:
                                CD.ReDrawLog();
                                CD.ReDrawStats();
                                break;

                            case CombatMenuReturn.Log:
                                CD.ReDrawLog();
                                break; 
                                
                            case CombatMenuReturn.StatAndMenu:
                                CD.RedrawAcionMenu();
                                CD.ReDrawStats();
                                break;

                            case CombatMenuReturn.All:
                                CD.Draw(new Cord { X = 2, Y = 2 });
                                break;
                        }
                        break;

                    case PlayerState.Menu:

                        break;
                }

            }
        }
    }

    enum PlayerState
    {
        WorldMap, Dungeon, Combat, Store, Menu
    }
}
