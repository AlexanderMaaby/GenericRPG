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
        public int Level { get; set; }
        public BasePrimaryAttributes basePrimaryAttributes;
        public BasePrimaryAttributes totalPrimaryAttributes;
        public SecondaryAttributes secondaryAttributes;
        public Dictionary<string, dynamic> inventory = new Dictionary<string, dynamic>();

        public Hero()
        {
            Name = "Bobcat";
            Level = 1;
        }

        public void LevelUp(int levelsToGain)
        {
            if (levelsToGain > 0)
            {
                Level += levelsToGain;
                IncreasePrimaryAttributes();
            }
            else
            {
                throw new ArgumentException(string.Format("{0} can not be 0 or less", levelsToGain), "levelsToGain");
            }
        }
        
        public void RemoveTemporaryAttributes(Armor item)
        {
            totalPrimaryAttributes.Intelligence -= item.primaryAttributes?.Intelligence ?? 0;
            totalPrimaryAttributes.Strength -= item.primaryAttributes?.Strength ?? 0;
            totalPrimaryAttributes.Dexterity -= item.primaryAttributes?.Dexterity ?? 0;
            totalPrimaryAttributes.Vitality -= item.primaryAttributes?.Vitality ?? 0;
        }
        public void AddTemporaryAttributes(Armor item)
        {
            totalPrimaryAttributes.Intelligence += item.primaryAttributes?.Intelligence ?? 0;
            totalPrimaryAttributes.Strength += item.primaryAttributes?.Strength ?? 0;
            totalPrimaryAttributes.Dexterity += item.primaryAttributes?.Dexterity ?? 0;
            totalPrimaryAttributes.Vitality += item.primaryAttributes?.Vitality ?? 0;
        }

        public void RecalculateSecondaryAttributes()
        {
            int tempStrength = (int) totalPrimaryAttributes.Strength;
            int tempInt = (int)totalPrimaryAttributes.Intelligence;
            int tempDex = (int)totalPrimaryAttributes.Dexterity;
            int tempVit = (int)totalPrimaryAttributes.Vitality;
            secondaryAttributes = new SecondaryAttributes(tempStrength, tempDex, tempInt, tempVit);
        }

        public string[] CharacterSheetString()
        {
            Console.WriteLine(totalPrimaryAttributes.Intelligence.ToString());
            string[] characterSheet = new string[10];
            characterSheet[0] = "Name: " + Name;
            characterSheet[1] = "Level: " + Level.ToString();
            characterSheet[2] = "Strength: " + totalPrimaryAttributes.Strength.ToString() + " ("+ basePrimaryAttributes.Strength.ToString() +")";
            characterSheet[3] = "Intelligence: " + totalPrimaryAttributes.Intelligence.ToString() + " (" + basePrimaryAttributes.Intelligence.ToString() +")";
            characterSheet[4] = "Dexterity: " + totalPrimaryAttributes.Dexterity.ToString() + " (" + basePrimaryAttributes.Dexterity.ToString() + ")";
            characterSheet[5] = "Health: " + secondaryAttributes.Health.ToString();
            characterSheet[6] = "Armor Rating: " + secondaryAttributes.ArmorRating.ToString();
            characterSheet[7] = "Elemental Resistance: " + secondaryAttributes.ElementalResistance.ToString();
            characterSheet[8] = "DPS: " + CharacterDPS();
            return characterSheet;
        }

        public abstract void IncreasePrimaryAttributes();

        public abstract double CharacterDPS();

    }
    public class Mage : Hero
    {
        public Mage()
        {
            basePrimaryAttributes = new BasePrimaryAttributes(1,1,8,5);
            totalPrimaryAttributes = new BasePrimaryAttributes(1,1,8,5);
            secondaryAttributes = new SecondaryAttributes(1,1,8,5);
        }
        public override void IncreasePrimaryAttributes()
        {
            basePrimaryAttributes.IncreasePrimaryAttributes(1, 1, 5, 3);
            totalPrimaryAttributes.IncreasePrimaryAttributes(1, 1, 5, 3);
        }

        public override double CharacterDPS()
        {
            Weapon weapon = inventory[ItemSlot.SLOT_WEAPON.ToString()];
            double tempModifier = 1.00 + (double) totalPrimaryAttributes.Intelligence / 100.00;
            double tempDPS = weapon.AttackDPS * tempModifier;
            return tempDPS;
        }
        public string EquipItem(Weapon item)
        {
            string returnstring = "No weapon equipped!";
            if (((item.WeaponType == WeaponType.WEAPON_STAFF) || (item.WeaponType == WeaponType.WEAPON_WAND)) && item.ItemLevel <= Level)
            {
                inventory.Remove(item.ItemSlot.ToString());
                inventory.Add(item.ItemSlot.ToString(), item);
                returnstring = "New weapon equipped!";
            }
            else
            {
                //catch custom exception
                throw new InvalidWeaponException("This character cannot equip this weapon");
            }
            return returnstring;
        }

        public string EquipItem(Armor item)
        {
            string returnstring = "No item equipped!";
            if(item.armorType == ArmorType.ARMOR_CLOTH && item.ItemLevel <= Level)
            {
                if (inventory.ContainsKey(item.ItemSlot.ToString()))
                {
                    Armor oldItem = inventory[item.ItemSlot.ToString()];
                    RemoveTemporaryAttributes(oldItem);
                    inventory.Remove(item.ItemSlot.ToString());
                }
                inventory.Add(item.ItemSlot.ToString(), item);
                AddTemporaryAttributes(item);
                RecalculateSecondaryAttributes();
                returnstring = "New armor equipped!";
            }
            else
            {
                //add custom exception
                throw new InvalidArmorException("This character is unable to equip this armor");
            }
            return returnstring;
        }
    }
}
