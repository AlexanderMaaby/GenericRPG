using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG
{
    public class Weapon : Item
    {
        public int WeaponDamage { get; set; }
        public double AttackSpeed { get; set; }
        public double AttackDPS { get; set; }
        public WeaponType WeaponType { get; set; }

        /// <summary>
        /// Creates a new weapon.
        /// </summary>
        /// <param name="weaponDamage">The damage the weapon has.</param>
        /// <param name="attackSpeed">The attack speed of the weapon.</param>
        /// <param name="weaponType">What type of weapon it is, has to be valid enum WeaponType.</param>
        /// <param name="itemName">The name of the item that is to be created.</param>
        /// <param name="itemLevel">The required level for a hero to use this item.</param>
        /// <param name="itemSlot">The item slot that the item can be equipped in, requires a ItemSlot enum.</param>
        public Weapon(int weaponDamage, double attackSpeed, WeaponType weaponType, string itemName, int itemLevel, ItemSlot itemSlot) : base(itemName, itemLevel, itemSlot)
        {
            WeaponDamage = weaponDamage;
            AttackSpeed = attackSpeed;
            WeaponType = weaponType;;
            AttackDPS = weaponDamage * attackSpeed;
        }
        public Weapon()
        {
            ItemName = "Generic Weapon";
            ItemLevel = 1;
            ItemSlot = ItemSlot.SLOT_WEAPON;
            WeaponDamage = 8;
            AttackSpeed = 1.2;
            WeaponType = WeaponType.WEAPON_STAFF;
            AttackDPS = (double) WeaponDamage * AttackSpeed;
        }
    }

    public enum WeaponType
    {
        WEAPON_AXE,
        WEAPON_BOW,
        WEAPON_DAGGER,
        WEAPON_HAMMER,
        WEAPON_STAFF,
        WEAPON_SWORD,
        WEAPON_WAND
    };
}
