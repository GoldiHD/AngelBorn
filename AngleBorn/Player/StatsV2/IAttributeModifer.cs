using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngleBorn.Player.StatsV2
{
    public interface IAttributeModifer
    {
        int attributeModiferPower { get; set; }
        int attributeModiferVitallity { get; set; }
        int attributeModiferMagic { get; set; }
        int attributeModiferLuck { get; set; }
    }
}
