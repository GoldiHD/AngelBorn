using System;
using System.Collections.Generic;
using System.Text;

namespace AngelBorn.World.Tiles
{
    class CityTile : BaseTile
    {
        public Map CityMap { get; private set; }
        public string CityName { get; private set; }
        public Map ParrentMap { get; private set; }

        public Map LoadMap()
        {
            return CityMap;
        }

        public CityTile CopyOf(CityTile _base)
        {
            
            base.CopyOf((BaseTile)_base);
            MyType = TileType.Town;
            CityName = _base.CityName;
            ParrentMap = _base.ParrentMap;
            CityMap = _base.CityMap;
            return this;

        }

        public CityTile(string _cityName, Map _ParrentMap, Map _ChildMap)
        {
            CityName = _cityName;
            ParrentMap = _ParrentMap;
            CityMap = _ChildMap;
        }

        public CityTile()
        {
        }
    }
}
