using AngelBorn.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngleBorn.Items
{
    class WeaponItem : EquippableItem
    {
        public int Damage { get; private set; }
        public int Durability { get; private set; }

        public WeaponItem(string _name, ItemType _itemType, int _value, bool _usedInCombat, int _damage, float _durability)
        {
            name = _name;
            Id = SingleTon.GetItemManager().AllItems.Count;
        }

        public override void Equip()
        {
            if (SingleTon.GetPlayerController().inventory.MainHand != null)
            {
                SingleTon.GetPlayerController().inventory.MainHand.UnEquip();
            }
            SingleTon.GetPlayerController().inventory.MainHand = this;
            SingleTon.GetPlayerController().Skills.Power.AddWeaponDamage(Damage);
        }

        public override void UnEquip()
        {
            SingleTon.GetPlayerController().Skills.Power.RemoveDamage(Damage);
            SingleTon.GetPlayerController().inventory.MainHand = null;
        }
    }
}
