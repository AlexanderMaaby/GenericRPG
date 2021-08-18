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

        public Weapon(int weaponDamage, double attackSpeed, WeaponType weaponType, string itemName, int itemLevel, ItemSlot itemSlot) : base(itemName, itemLevel, itemSlot)
        {
            WeaponDamage = weaponDamage;
            AttackSpeed = attackSpeed;
            WeaponType = weaponType;;
            AttackDPS = weaponDamage * attackSpeed;
        }
        public Weapon()
        {
            ItemName = "Bananbue";
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
