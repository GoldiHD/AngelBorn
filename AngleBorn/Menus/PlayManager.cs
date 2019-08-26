using AngelBorn.Grapihcs;
using AngelBorn.Grapihcs.MapGra;
using AngelBorn.Player.Inventory;
using AngelBorn.Tools;
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
        private int infoBoardSize = 0;

        public void Run()
        {
            State = PlayerState.WorldMap;
            CW.Clear();
            ViewMap.DrawMap();
            DIB.Draw(2, MapDraw.ViewSize.Y * 2 + 3);
            while (true)
            {

                switch(State)
                {
                    case PlayerState.WorldMap:
                        if(movement.CheckMoveMent())
                        {
                            ViewMap.DrawMap();
                        }
                        
                        break;

                    case PlayerState.Dungeon:
                        if(movement.MovementInDungeon())
                        {
                            ViewMap.DrawMap();
                        }
                        break;

                    case PlayerState.Store:

                        break;
                         
                    case PlayerState.Combat:

                        break;

                    case PlayerState.Menu:

                        break;
                }
                if (infoBoardSize < DrawInfoBox.Inputs.Count)
                {
                    DIB.Draw(2, MapDraw.ViewSize.Y * 2 + 3);
                }
            }
        }
    }

    enum PlayerState
    {
        WorldMap, Dungeon, Combat, Store, Menu
    }
}
