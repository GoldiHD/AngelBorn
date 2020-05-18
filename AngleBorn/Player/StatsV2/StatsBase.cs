using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngleBorn.Player.StatsV2
{
    class StatsBase
    {
        public int StatLevelWithModifers 
        { 
            get { return statLevel + GetTotalModifers(); }
        }

        public int statLevel { get; private set; }

        public void AddPoint()
        {
            statLevel++;
        }

        public StatsBase(int level)
        {
            statLevel = level;
        }

        private int GetTotalModifers()
        {
            int totalModifers = 0;
            foreach(StatsModifer element in Modifers)
            {
                totalModifers += element.ModiferAmount;
            }
            return totalModifers;
        }

        public List<StatsModifer> Modifers = new List<StatsModifer>();
    }

    public struct StatsModifer
    {
        public int ModiferAmount;
        public IAttributeModifer src;
    }
}
