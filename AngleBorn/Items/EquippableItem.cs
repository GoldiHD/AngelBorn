using AngleBorn.Player.StatsV2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngleBorn.Items
{
    abstract class EquippableItem : BaseItem, IAttributeModifer
    {
        public int attributeModiferPower { get; set; }
        public int attributeModiferVitallity { get; set; }
        public int attributeModiferMagic { get; set; }
        public int attributeModiferLuck { get; set; }

        public abstract void Equip();

        public abstract void UnEquip();

        

    }
}
