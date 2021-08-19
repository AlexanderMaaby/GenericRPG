using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG
{
    /// <summary>
    /// A class containing the secondary attributes: health, armor rating and elemental resistance.
    /// </summary>
    public class SecondaryAttributes
    {
        public int Health { get; set; }
        private int vitalityHealthModifier = 10;
        public int ArmorRating { get; set; }
        public int ElementalResistance { get; set; }

        /// <summary>
        /// Creates a set of secondary attributes for a hero. 
        /// </summary>
        /// <param name="str">The amount of strength the hero has.</param>
        /// <param name="dex">The amount of dexterity the hero has.</param>
        /// <param name="intel">The amount of intellect the hero has.</param>
        /// <param name="vit">The amount of vitality the hero has.</param>
        public SecondaryAttributes(int str, int dex, int intel, int vit)
        {
            Health = vit * vitalityHealthModifier;
            ArmorRating = str + dex;
            ElementalResistance = intel;
        }

        public SecondaryAttributes()
        {

        }

        /// <summary>
        /// Recalcualtes a set of secondary attributes for a hero. 
        /// </summary>
        /// <param name="str">The amount of strength the hero has.</param>
        /// <param name="dex">The amount of dexterity the hero has.</param>
        /// <param name="intel">The amount of intellect the hero has.</param>
        /// <param name="vit">The amount of vitality the hero has.</param>
        public void RecalculateSecondaryAttributes(int str, int dex, int intel, int vit)
        {
            Health = vit * vitalityHealthModifier;
            ArmorRating = str + dex;
            ElementalResistance = intel;
        }
    }
}
