using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG
{
    public class Armor : Item
    {
        public ArmorType armorType { get; set; }

        public BasePrimaryAttributes primaryAttributes;

        public Armor()
        {
            ItemName = "Bananbukse";
            ItemLevel = 1;
            ItemSlot = ItemSlot.SLOT_HEAD;
            armorType = ArmorType.ARMOR_PLATE;
            primaryAttributes = new();
            primaryAttributes.Intelligence = 2;
            primaryAttributes.Vitality = 4;
        }
    }

    public enum ArmorType
    {
        ARMOR_CLOTH,
        ARMOR_LEATHER,
        ARMOR_MAIL,
        ARMOR_PLATE
    }
}
