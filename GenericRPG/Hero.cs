using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG
{
    public abstract class Hero
    {
        public string Name { get; set; } = "Generic Hero";
        public int Level { get; set; } = 1;
        public BasePrimaryAttributes basePrimaryAttributes;
        public BasePrimaryAttributes totalPrimaryAttributes;
        public SecondaryAttributes secondaryAttributes;
        public Dictionary<string, dynamic> inventory = new Dictionary<string, dynamic>();

        public Hero()
        {
        }

        public void LevelUp(int levelsToGain)
        {
            if (levelsToGain > 0)
            {
                Level += levelsToGain;
                for (int i=0; i < levelsToGain; i++)
                {
                    IncreasePrimaryAttributes();
                } 
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
        public string EquipItem(Weapon item)
        {
            string returnstring = "No weapon equipped!";
            if (AvailableWeaponType(item))
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
            if (AvailableArmorType(item))
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
                throw new InvalidArmorException("This character is unable to equip this armor");
            }
            return returnstring;
        }
        public double CharacterDPS()
        {
            Weapon weapon;
            double tempDPS;
            double tempModifier = 1.00 + GetMainPrimaryAttributeValue() / 100.00;
            if (inventory.ContainsKey(ItemSlot.SLOT_WEAPON.ToString()))
            {
                weapon = inventory[ItemSlot.SLOT_WEAPON.ToString()];
                tempDPS = weapon.AttackDPS * tempModifier;
            }
            else
            {
                tempDPS = 1.00 * tempModifier;
            }
            return tempDPS;
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

        public abstract bool AvailableArmorType(Armor item);

        public abstract bool AvailableWeaponType(Weapon item);

        public abstract double GetMainPrimaryAttributeValue();

    }
}
