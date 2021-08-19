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

        //
        // Summary:
        //     Creates a set of secondary attributes for a hero. 
        //
        // Parameters:
        //   str:
        //     The amount of strength the hero has.
        //   dex:
        //     The amount of dexterity the hero has.
        //   intel:
        //     The amount of intellect the hero has.
        //   vit:
        //     The amount of vitality the hero has.
        //

        public SecondaryAttributes(int str, int dex, int intel, int vit)
        {
            Health = vit * vitalityHealthModifier;
            ArmorRating = str + dex;
            ElementalResistance = intel;
        }

        public SecondaryAttributes()
        {

        }
        //
        // Summary:
        //     Recalcualtes a set of secondary attributes for a hero. 
        //
        // Parameters:
        //   str:
        //     The amount of strength the hero has.
        //   dex:
        //     The amount of dexterity the hero has.
        //   intel:
        //     The amount of intellect the hero has.
        //   vit:
        //     The amount of vitality the hero has.
        //
        public void RecalculateSecondaryAttributes(int str, int dex, int intel, int vit)
        {
            Health = vit * vitalityHealthModifier;
            ArmorRating = str + dex;
            ElementalResistance = intel;
        }
    }
}
