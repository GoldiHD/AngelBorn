using AngelBorn.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngleBorn.Items
{
    class ConsumableEffects
    {
        public static void Healing(int strenght)
        {
            SingleTon.GetPlayerController().Skills.Vitallity.Heal((int)((strenght * 10) * Math.Pow((double)strenght, (double)SingleTon.GetPlayerController().Level )));
        }

        public static void ReGainMana(int strenght)
        {
            SingleTon.GetPlayerController().Skills.Magic.DrainMana((int)((strenght * 10) * Math.Pow((double)strenght, (double)SingleTon.GetPlayerController().Level)));
        }
    }
}
