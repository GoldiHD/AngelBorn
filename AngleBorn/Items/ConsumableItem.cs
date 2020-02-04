using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngleBorn.Items
{
    class ConsumableItem : BaseItem
    {
        public delegate void EffectAction(int strenght);
        public EffectAction effectAction;
        private int strenght;

        public ConsumableItem(string _name, string _description, ItemType _itemType, int _value, bool _usedInCombat, EffectAction _effectAction , int _strenght)
        {
            strenght = _strenght;
            effectAction = _effectAction;
        }

        public void Apply()
        {
            effectAction.Invoke(strenght);
        }

    }

    enum ConsumableType
    {
       Damage, DamageBoost, DPR, Restore
    }
}
