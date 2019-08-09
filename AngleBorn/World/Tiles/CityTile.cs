using System;
using System.Collections.Generic;
using System.Text;

namespace AngelBorn.World.Tiles
{
    class CityTile : BaseTile
    {
        private Map CityMap;
        public string CityName;
        public Cord Pos;

        public Map LoadMap()
        {
            return CityMap;
        }

        public CityTile CopyOf(CityTile _base, Map _CityMap)
        {
            base.CopyOf((BaseTile)_base);
            CityName = _base.CityName;
            CityMap = _CityMap;
            return this;

        }

        public CityTile(string _cityName)
        {
            CityName = _cityName;
        }

        public CityTile()
        {
        }
    }
}
