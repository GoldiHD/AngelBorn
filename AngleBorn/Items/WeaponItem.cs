using AngelBorn.Tools;
using AngleBorn.Player.StatsV2;
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

        public WeaponItem(string _name, string _description,ItemType _itemType, int _value, bool _usedInCombat, int _damage)
        {
            name = _name;
            describtion = _description;
            Id = SingleTon.GetItemManager().AllItems.Count;
            itemType = _itemType;
            Value = _value;
            UseInCombat = _usedInCombat;
            Damage = _damage;
            Effect = "Attack +" + Damage;
        }

        public override void Equip()
        {
            if (SingleTon.GetPlayerController().Inventory.MainHand != null)
            {
                SingleTon.GetPlayerController().Inventory.MainHand.UnEquip();
            }
            SingleTon.GetPlayerController().Inventory.MainHand = this;
            SingleTon.GetPlayerController().Skills.Power.AddWeaponDamage(Damage);
        }

        public override void UnEquip()
        {
            SingleTon.GetPlayerController().Skills.Power.RemoveDamage(Damage);
            SingleTon.GetPlayerController().Inventory.MainHand = null;
        }
    }
}
