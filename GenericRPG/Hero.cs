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

        //
        // Summary:
        //     Levels up the hero the amount of levels requested in the paramter.
        //
        // Parameters:
        //   levelsToGain:
        //     An int for the amount of levels the specific hero should gain.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     levelsToGain is 0 or lower.
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
            RecalculateSecondaryAttributes();
        }

        //
        // Summary:
        //     Removes any temporary attributes increased from the character wearing armor.
        //
        // Parameters:
        //   item:
        //     The specific item of the type GenerigRPG.Armor that should be removed from the hero.
        //     
        public void RemoveTemporaryAttributes(Armor item)
        {
            totalPrimaryAttributes.Intelligence -= item.primaryAttributes?.Intelligence ?? 0;
            totalPrimaryAttributes.Strength -= item.primaryAttributes?.Strength ?? 0;
            totalPrimaryAttributes.Dexterity -= item.primaryAttributes?.Dexterity ?? 0;
            totalPrimaryAttributes.Vitality -= item.primaryAttributes?.Vitality ?? 0;
        }

        //
        // Summary:
        //     Adds temporary attributes increased from the character wearing armor.
        //
        // Parameters:
        //   item:
        //     The specific item of the type GenerigRPG.Armor that should be added to the hero.
        // 
        public void AddTemporaryAttributes(Armor item)
        {
            totalPrimaryAttributes.Intelligence += item.primaryAttributes?.Intelligence ?? 0;
            totalPrimaryAttributes.Strength += item.primaryAttributes?.Strength ?? 0;
            totalPrimaryAttributes.Dexterity += item.primaryAttributes?.Dexterity ?? 0;
            totalPrimaryAttributes.Vitality += item.primaryAttributes?.Vitality ?? 0;
        }

        //
        // Summary:
        //     Recalculates a hero characters secondary stats based upon the heroes current totalPrimaryAttributes.
        // 
        public void RecalculateSecondaryAttributes()
        {
            int tempStrength = (int) totalPrimaryAttributes.Strength;
            int tempInt = (int)totalPrimaryAttributes.Intelligence;
            int tempDex = (int)totalPrimaryAttributes.Dexterity;
            int tempVit = (int)totalPrimaryAttributes.Vitality;
            secondaryAttributes = new SecondaryAttributes(tempStrength, tempDex, tempInt, tempVit);
        }
        //
        // Summary:
        //     Equips a new weapon to the hero character. 
        //
        // Parameters:
        //   item:
        //     The specific item of the type GenerigRPG.Weapon that should be equipped to the hero character.
        //
        // Exceptions:
        //   GenerigRPG.InvalidWeaponException:
        //     If the item level of the weapon is higher than the level of the hero, or if the weapon type is not compatible with the hero class.
        //
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
                throw new InvalidWeaponException("This character cannot equip this weapon");
            }
            return returnstring;
        }

        //
        // Summary:
        //     Equips a new armor to the hero character. 
        //
        // Parameters:
        //   item:
        //     The specific item of the type GenerigRPG.Armor that should be equipped to the hero character.
        //
        // Exceptions:
        //   GenerigRPG.InvalidArmorException:
        //     If the item level of the armor is higher than the level of the hero, or if the armor type is not compatible with the hero class.
        //
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
        //
        // Summary:
        //     Returns the hero characters current DPS (damage per second) as a double.
        //
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

        //
        // Summary:
        //     Returns a array of strings with all relevant data from a hero character.
        //
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

        //
        // Summary:
        //     Increases the primary attributes of a hero. Called when a hero levels up.
        //
        public abstract void IncreasePrimaryAttributes();

        //
        // Summary:
        //     Checks if a hero character is able to equip a certain item.
        //
        // Parameters:
        //   item:
        //     The specific item of the type GenerigRPG.Armor that should be checked for eligibility.
        //
        public abstract bool AvailableArmorType(Armor item);

        //
        // Summary:
        //     Checks if a hero character is able to equip a certain item.
        //
        // Parameters:
        //   item:
        //     The specific item of the type GenerigRPG.Weapon that should be checked for eligibility.
        //
        public abstract bool AvailableWeaponType(Weapon item);

        //
        // Summary:
        //     Returns the value that represents a hero class damage multiplying primary attribute, as a double.
        //
        public abstract double GetMainPrimaryAttributeValue();

    }
}
