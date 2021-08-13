using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG
{
    public class SecondaryAttributes
    {
        public int Health { get; set; }
        private int vitalityHealthModifier = 10;
        public int ArmorRating { get; set; }
        public int ElementalResistance { get; set; }

        public SecondaryAttributes(int str, int dex, int intel, int vit)
        {
            Health = vit * vitalityHealthModifier;
            ArmorRating = str + dex;
            ElementalResistance = intel;
        }
        public void RecalculateSecondaryAttributes(int str, int dex, int intel, int vit)
        {
            Health = vit * vitalityHealthModifier;
            ArmorRating = str + dex;
            ElementalResistance = intel;
        }
    }
}
