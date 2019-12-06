using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngleBorn.Items
{
    abstract class EquippableItem : BaseItem
    {
        public abstract void Equip();

        public abstract void UnEquip();

        

    }
}
