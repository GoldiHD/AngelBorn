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
            switch(ArmorLocation)
            {
                case ArmorLocation.Chest:

                    break;
            }
        }

        public override void UnEquip()
        {
            throw new NotImplementedException();
        }
    }

    enum ArmorLocation
    {
        Head, Chest, Legs, Feet, Offhand
    }
}
