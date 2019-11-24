using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngleBorn.Items
{
    class ConsumableItem : BaseItem
    {
        public delegate void EffectAction();
        public EffectAction effectAction;
        private int strenght;

        public ConsumableItem(string _name, string _description, ItemType _itemType, int _value, bool _usedInCombat, ConsumableType _consumableType, int _strenght)
        {
            strenght = _strenght;
            switch (_consumableType)
            {
                case ConsumableType.Healing:
                    effectAction = Healing;
                    break;

                case ConsumableType.DPR:
                    effectAction = DRP;
                    break;

                case ConsumableType.DamageBoost:
                    effectAction = DamageBoost;
                    break;

                case ConsumableType.Damage:
                    effectAction = Damage;
                    break;
            }
        }

        public void Healing()
        {

        }

        public void DRP()
        {

        }

        public void Damage()
        {

        }

        public void DamageBoost()
        {

        }
    }

    enum ConsumableType
    {
        Healing, Damage, DamageBoost, DPR
    }
}
