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
        private PlayerState State = PlayerState.WorldMap;
        private MapDraw ViewMap = new MapDraw();
        private DrawStats ViewStats = new DrawStats();
        private Movement movement = new Movement();
        private DrawInfoBox DIB = new DrawInfoBox();
        private int infoBoardSize = 0;

        public void Run()
        {
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
                        if(infoBoardSize < DrawInfoBox.Inputs.Count)
                        {
                            DIB.Draw(2,MapDraw.ViewSize.Y * 2  + 3);
                        }
                        break;

                    case PlayerState.Store:

                        break;

                    case PlayerState.Combat:

                        break;

                    case PlayerState.Menu:

                        break;
                }
            }
        }
    }

    enum PlayerState
    {
        WorldMap, SubMap, Combat, Store, Menu
    }
}
