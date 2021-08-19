using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG
{
    /// <summary>
    /// A class containing the primary attributes. Used both for hero classes (GenericRPG.Hero) and items (GenericRPG.Armor).
    /// </summary>
    public class BasePrimaryAttributes
    {
        public int? Strength { get; set; }
        public int? Dexterity { get; set; }
        public int? Intelligence { get; set; }
        public int? Vitality { get; set; }

        public BasePrimaryAttributes(int str, int dex, int intel, int vit)
        {
            Strength = str;
            Dexterity = dex;
            Intelligence = intel;
            Vitality = vit;
        }
        /// <summary>t
        /// Default empty constructor to get a set of primary attributes. Generally only used for armor which unlike hero classes does not need all stats.
        /// </summary>
        public BasePrimaryAttributes()
        {
        }

        /// <summary>
        /// Increase the primary attributes within the class. 
        /// </summary>
        /// <param name="str">The amount of strength that should be added.</param>
        /// <param name="dex">The amount of dexterity that should be added.</param>
        /// <param name="intel">The amount of intellect that should be added.</param>
        /// <param name="vit">The amount of vitality that should be added.</param>
        public void IncreasePrimaryAttributes(int str, int dex, int intel, int vit)
        {
            Strength += str;
            Dexterity += dex;
            Intelligence += intel;
            Vitality += vit;
        }
    }
}
