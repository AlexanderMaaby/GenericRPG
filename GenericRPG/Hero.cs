using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG
{
    public abstract class Hero
    {
        protected string Name { get; set; }
        protected int Level { get; set; }
        protected BasePrimaryAttributes basePrimaryAttributes;
        protected SecondaryAttributes secondaryAttributes;

        public Hero()
        {
            Name = "Bobcat";
            Level = 1;
        }

        public void LevelUp()
        {
            Level++;
            IncreasePrimaryAttributes();
        }

        public string[] CharacterSheetString()
        {
            string[] characterSheet = new string[9];
            characterSheet[0] = "Name: " + Name;
            characterSheet[1] = "Level: " + Level.ToString();
            characterSheet[2] = "Strength: " + basePrimaryAttributes.Strength.ToString();
            characterSheet[3] = "Intelligence: " + basePrimaryAttributes.Intelligence.ToString();
            characterSheet[4] = "Dexterity: " + basePrimaryAttributes.Dexterity.ToString();
            characterSheet[5] = "Health: " + secondaryAttributes.Health.ToString();
            characterSheet[6] = "Armor Rating: " + secondaryAttributes.ArmorRating.ToString();
            characterSheet[7] = "Elemental Resistance: " + secondaryAttributes.ElementalResistance.ToString();
            characterSheet[8] = "DPS: " + "Player is incapable of hurting anything";
            return characterSheet;
        }

        public abstract void IncreasePrimaryAttributes();

    }
    public class Mage : Hero
    {
        public Mage()
        {
            basePrimaryAttributes = new BasePrimaryAttributes(1,1,8,5);
            secondaryAttributes = new SecondaryAttributes(1,1,8,5);
        }
        public override void IncreasePrimaryAttributes()
        {
            basePrimaryAttributes.IncreasePrimaryAttributes(1,1,5,3);
        }
    }
}
