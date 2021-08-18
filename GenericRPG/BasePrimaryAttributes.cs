using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG
{
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

        public BasePrimaryAttributes()
        {
        }

        public void IncreasePrimaryAttributes(int str, int dex, int intel, int vit)
        {
            Strength += str;
            Dexterity += dex;
            Intelligence += intel;
            Vitality += vit;
        }
    }
}
