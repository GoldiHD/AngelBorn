using AngelBorn.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngleBorn.Items
{
    class ArmorItem : EquippableItem
    {
        public ArmorLocation ArmorLocation { get; private set; }
        public int AC { get; private set; }
        public ArmorItem(string _name, ItemType _itemType, int _value, bool _usedInCombat, int _AC, ArmorLocation _armorLocation)
        {
            name = _name;
            itemType = _itemType;
            Value = _value;
            UseInCombat = _usedInCombat;
            AC = _AC;
            ArmorLocation = _armorLocation;
        }

        public override void Equip()
        {
            switch (ArmorLocation)
            {
                case ArmorLocation.Chest:
                    if (SingleTon.GetPlayerController().Inventory.ChestArmor != null)
                    {
                        SingleTon.GetPlayerController().Inventory.ChestArmor.UnEquip();
                    }
                    SingleTon.GetPlayerController().Inventory.ChestArmor = this;
                    break;

                case ArmorLocation.Feet:
                    if (SingleTon.GetPlayerController().Inventory.ShoesArmor != null)
                    {
                        SingleTon.GetPlayerController().Inventory.ShoesArmor.UnEquip();
                    }
                    SingleTon.GetPlayerController().Inventory.ShoesArmor = this;
                    break;

                case ArmorLocation.Head:
                    if (SingleTon.GetPlayerController().Inventory.HeadArmor != null)
                    {
                        SingleTon.GetPlayerController().Inventory.HeadArmor.UnEquip();
                    }
                    SingleTon.GetPlayerController().Inventory.HeadArmor = this;
                    break;

                case ArmorLocation.Offhand:
                    if (SingleTon.GetPlayerController().Inventory.OffHand != null)
                    {
                        SingleTon.GetPlayerController().Inventory.OffHand.UnEquip();
                    }
                    SingleTon.GetPlayerController().Inventory.OffHand = this;
                    break;

                case ArmorLocation.Legs:
                    if (SingleTon.GetPlayerController().Inventory.PantsArmor != null)
                    {
                        SingleTon.GetPlayerController().Inventory.PantsArmor.UnEquip();
                    }
                    SingleTon.GetPlayerController().Inventory.PantsArmor = this;
                    
                    break;
            }
            SingleTon.GetPlayerController().Armor += AC;
        }
        public override void UnEquip()
        {
            switch (ArmorLocation)
            {
                case ArmorLocation.Chest:
                    SingleTon.GetPlayerController().Inventory.ChestArmor = null;            
                    break;
                case ArmorLocation.Feet:
                    SingleTon.GetPlayerController().Inventory.ShoesArmor = null;
                    break;
                case ArmorLocation.Offhand:
                    SingleTon.GetPlayerController().Inventory.OffHand = null;
                    break;
                case ArmorLocation.Legs:
                    SingleTon.GetPlayerController().Inventory.PantsArmor = null;
                    break;
                case ArmorLocation.Head:
                    SingleTon.GetPlayerController().Inventory.HeadArmor = null;
                    break;
            }
            SingleTon.GetPlayerController().Armor -= AC;
        }
    }

    enum ArmorLocation
    {
        Head, Chest, Legs, Feet, Offhand
    }
}
