using AngelBorn.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngleBorn.Player.StatsV2
{
    class StatPower : StatsBase
    {
        public int GetDamageModifer { get { return (int)Math.Round((double)CalculateDamageModifer()); }}

        public StatPower(int startingLevel) : base(startingLevel)
        {

        }


        private float CalculateDamageModifer()
        {
            return ((float)StatLevelWithModifers / (float)SingleTon.GetPlayerController().Level) * 0.3f;
        }
    }
}
