using System;
using System.Collections.Generic;
using System.Text;

namespace AngelBorn.World
{
    class BaseTile
    {
        public TileType MyType { get; set; }
        public string Description { get;  set; }
        public string TileName { get;  set; }
        public bool Walkable { get;  set; }
        public Cord Pos { get;  set; }

        public virtual BaseTile CopyOf(BaseTile _base)
        {
            MyType = _base.MyType;
            Description = _base.Description;
            TileName = _base.TileName;
            Walkable = _base.Walkable;
            Pos = _base.Pos;
            return this;
        }
    }


    public struct Cord
    {
        public int X;
        public int Y;
    }

    public enum TileType
    {
        Normal,
        Inpassable,
        Town

    }
}
