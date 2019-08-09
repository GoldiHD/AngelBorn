using AngelBorn.Grapihcs;
using AngelBorn.Grapihcs.MapGra;
using AngelBorn.Tools;
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
        private PlayerState State = PlayerState.WorldMap;
        private MapDraw ViewMap = new MapDraw();
        private DrawStats ViewStats = new DrawStats();
        private Movement movement = new Movement();
        public void Run()
        {
            CW.Clear();
            ViewMap.DrawMap();
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

                    case PlayerState.SubMap:

                        break;

                    case PlayerState.Store:

                        break;

                    case PlayerState.Combat:

                        break;
                }
            }
        }
    }

    enum PlayerState
    {
        WorldMap, SubMap, Combat, Store
    }
}
