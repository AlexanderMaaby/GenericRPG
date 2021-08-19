using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG
{
    /// <summary>
    /// Contains all logic in relation to a hero character. 
    /// </summary>
    public abstract class Hero
    {
        public string Name { get; set; } = "Generic Hero";
        public int Level { get; set; } = 1;
        public BasePrimaryAttributes basePrimaryAttributes;
        public BasePrimaryAttributes totalPrimaryAttributes;
        public SecondaryAttributes secondaryAttributes;
        public Dictionary<string, dynamic> inventory = new Dictionary<string, dynamic>();


        /// <summary>
        /// Levels up the hero the amount of levels requested in the paramter.
        /// </summary>
        /// <param name="levelsToGain">An int for the amount of levels the specific hero should gain.</param>
        /// <exception cref=System.ArgumentException">
        /// <paramref name="levelsToGain"/> is 0 or less.
        /// </exception>
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

        /// <summary>
        /// Removes any temporary attributes increased from the character wearing armor.
        /// </summary>
        /// <param name="item">The specific item of the type GenerigRPG.Armor that should be removed from the hero.</param>
        public void RemoveTemporaryAttributes(Armor item)
        {
            totalPrimaryAttributes.Intelligence -= item.primaryAttributes?.Intelligence ?? 0;
            totalPrimaryAttributes.Strength -= item.primaryAttributes?.Strength ?? 0;
            totalPrimaryAttributes.Dexterity -= item.primaryAttributes?.Dexterity ?? 0;
            totalPrimaryAttributes.Vitality -= item.primaryAttributes?.Vitality ?? 0;
        }

        /// <summary>
        /// Adds temporary attributes increased from the character wearing armor.
        /// </summary>
        /// <param name="item">The specific item of the type GenerigRPG.Armor that should be added to the hero.</param>
        public void AddTemporaryAttributes(Armor item)
        {
            totalPrimaryAttributes.Intelligence += item.primaryAttributes?.Intelligence ?? 0;
            totalPrimaryAttributes.Strength += item.primaryAttributes?.Strength ?? 0;
            totalPrimaryAttributes.Dexterity += item.primaryAttributes?.Dexterity ?? 0;
            totalPrimaryAttributes.Vitality += item.primaryAttributes?.Vitality ?? 0;
        }

        /// <summary>
        /// Recalculates a hero characters secondary stats based upon the heroes current totalPrimaryAttributes.
        /// </summary>
        public void RecalculateSecondaryAttributes()
        {
            int tempStrength = (int) totalPrimaryAttributes.Strength;
            int tempInt = (int)totalPrimaryAttributes.Intelligence;
            int tempDex = (int)totalPrimaryAttributes.Dexterity;
            int tempVit = (int)totalPrimaryAttributes.Vitality;
            secondaryAttributes = new SecondaryAttributes(tempStrength, tempDex, tempInt, tempVit);
        }

        /// <summary>
        /// Equips a new weapon to the hero character. 
        /// </summary>
        /// <param name="item">The specific item of the type GenerigRPG.Weapon that should be equipped to the hero character.</param>
        /// <returns>A string specifying whether equipping the weapon was succesfull or not.</returns>
        /// <exception cref="GenericRPG.InvalidWeaponException">
        /// <paramref name="item"/> is not an item the hero character can either due to item level or weapon type.
        /// </exception>
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

        /// <summary>
        /// Equips a new armor to the hero character. 
        /// </summary>
        /// <param name="item">The specific item of the type GenerigRPG.Armor that should be equipped to the hero character.</param>
        /// <returns>A string specifying whether equipping the armor was succesfull or not.</returns>
        /// <exception cref="GenericRPG.InvalidArmorException">
        /// <paramref name="item"/> is not an item the hero character can either due to item level or armor type.
        /// </exception>
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

        /// <summary>
        /// Method to find the characters current DPS.
        /// </summary>
        /// <returns>Returns the hero characters current DPS (damage per second) as a double.</returns>
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

        /// <summary>
        /// Shows the character sheet of the given hero character.
        /// </summary>
        /// <returns>An array of strings with all the relevant hero character data.</returns>
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

        /// <summary>
        /// Increases the primary attributes of a hero. Called when a hero levels up.
        /// </summary>
        public abstract void IncreasePrimaryAttributes();

        /// <summary>
        /// Checks if a hero character is able to equip a certain item.
        /// </summary>
        /// <param name="item">The specific item of the type GenerigRPG.Armor that should be checked for eligibility.</param>
        /// <returns>Returns a bool whether or not the hero character can equip given item.</returns>
        public abstract bool AvailableArmorType(Armor item);

        /// <summary>
        /// Checks if a hero character is able to equip a certain item.
        /// </summary>
        /// <param name="item">The specific item of the type GenerigRPG.Weapon that should be checked for eligibility.</param>
        /// <returns>Returns a bool whether or not the hero character can equip given item.</returns>
        public abstract bool AvailableWeaponType(Weapon item);

        /// <summary>
        /// Returns the value that represents a hero class damage multiplying primary attribute, as a double.
        /// </summary>
        /// <returns>The main primary attribute for a hero class as a double.</returns>
        public abstract double GetMainPrimaryAttributeValue();

    }
}
