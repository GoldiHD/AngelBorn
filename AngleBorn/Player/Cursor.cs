using AngelBorn.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace AngelBorn.Player
{
    class Cursor
    {
        public BaseTile CurrentTile;
        public Cord Pos
        {
            get { return new Cord { X = CurrentTile.Pos.X, Y = CurrentTile.Pos.Y }; }
        }
    }
}
