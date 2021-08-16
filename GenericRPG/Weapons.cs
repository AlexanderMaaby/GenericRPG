using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG
{
    public class Weapons : Item
    {
        public int WeaponDamage { get; set; }
        public double AttackSpeed { get; set; }
        public WeaponType WeaponType { get; set; }

        public Weapons(int weaponDamage, double attackSpeed, WeaponType weaponType, string itemName, int itemLevel, ItemSlot itemSlot) : base(itemName, itemLevel, itemSlot)
        {
            WeaponDamage = weaponDamage;
            AttackSpeed = attackSpeed;
            WeaponType = weaponType;
        }
        public Weapons()
        {
            ItemName = "Bananbue";
            ItemLevel = 1;
            ItemSlot = ItemSlot.Weapon;
            WeaponDamage = 8;
            AttackSpeed = 1.2;
            WeaponType = WeaponType.Staff;
        }
    }

    public enum WeaponType
    {
        Axe,
        Bow,
        Dagger,
        Hammer,
        Staff,
        Sword,
        Wand
    };
}
