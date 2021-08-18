using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GenericRPGTests
{
    public class EquipmentTests
    {
        [Fact]
        public void EquipItem_EquippingHigherLevelWeapon_ShouldThrowInvalidWeaponException()
        {
            //Arrange
            GenericRPG.Mage hero = new GenericRPG.Mage();
            GenericRPG.Weapon testStaff = new GenericRPG.Weapon()
            {
                ItemName = "Staff of Arugal",
                ItemLevel = 2,
                ItemSlot = GenericRPG.ItemSlot.SLOT_WEAPON,
                WeaponType = GenericRPG.WeaponType.WEAPON_STAFF,
                WeaponDamage = 8,
                AttackSpeed = 0.8,
                AttackDPS = 1
            };
            //Act and Assert
            Assert.Throws<GenericRPG.InvalidWeaponException>(() => hero.EquipItem(testStaff));
        }

        [Fact]
        public void EquipItem_EquippingHigherLevelArmor_ShouldThrowInvalidArmorException()
        {
            //Arrange
            GenericRPG.Mage hero = new GenericRPG.Mage();
            GenericRPG.Armor testRobe = new GenericRPG.Armor()
            {
                ItemName = "Robe of Arugal",
                ItemLevel = 2,
                ItemSlot = GenericRPG.ItemSlot.SLOT_BODY,
                armorType = GenericRPG.ArmorType.ARMOR_CLOTH,
                primaryAttributes = new() {Vitality = 1, Intelligence = 5 }

            };
            //Act and Assert
            Assert.Throws<GenericRPG.InvalidArmorException>(() => hero.EquipItem(testRobe));
        }

        [Fact]
        public void EquipItem_EquippingWrongWeaponType_ShouldThrowInvalidWeaponException()
        {
            //Arrange
            GenericRPG.Mage hero = new GenericRPG.Mage();
            GenericRPG.Weapon testBlade = new GenericRPG.Weapon()
            {
                ItemName = "Blade of Aragorn",
                ItemLevel = 1,
                ItemSlot = GenericRPG.ItemSlot.SLOT_WEAPON,
                WeaponType = GenericRPG.WeaponType.WEAPON_SWORD,
                WeaponDamage = 8,
                AttackSpeed = 0.8,
                AttackDPS = 1
            };
            //Act and Assert
            Assert.Throws<GenericRPG.InvalidWeaponException>(() => hero.EquipItem(testBlade));
        }

        [Fact]
        public void EquipItem_EquippingWrongArmorType_ShouldThrowInvalidArmorException()
        {
            //Arrange
            GenericRPG.Mage hero = new GenericRPG.Mage();
            GenericRPG.Armor testRobe = new GenericRPG.Armor()
            {
                ItemName = "Robe of Bulky Arugal",
                ItemLevel = 1,
                ItemSlot = GenericRPG.ItemSlot.SLOT_BODY,
                armorType = GenericRPG.ArmorType.ARMOR_PLATE,
                primaryAttributes = new() { Vitality = 1, Intelligence = 5 }

            };
            //Act and Assert
            Assert.Throws<GenericRPG.InvalidArmorException>(() => hero.EquipItem(testRobe));
        }

        [Fact]
        public void EquipItem_EquippingValidWeapon_ShouldReturnSuccessString()
        {
            //Arrange
            GenericRPG.Mage hero = new GenericRPG.Mage();
            GenericRPG.Weapon testStaff = new GenericRPG.Weapon()
            {
                ItemName = "Staff of Medivh",
                ItemLevel = 1,
                ItemSlot = GenericRPG.ItemSlot.SLOT_WEAPON,
                WeaponType = GenericRPG.WeaponType.WEAPON_STAFF,
                WeaponDamage = 8,
                AttackSpeed = 0.8,
                AttackDPS = 1
            };
            string expected = "New weapon equipped!";
            //Act
            string actual = hero.EquipItem(testStaff);
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EquipItem_EquippingValidArmor_ShouldReturnSuccessString()
        {
            //Arrange
            GenericRPG.Mage hero = new GenericRPG.Mage();
            GenericRPG.Armor testRobe = new GenericRPG.Armor()
            {
                ItemName = "Robe of Arugal",
                ItemLevel = 1,
                ItemSlot = GenericRPG.ItemSlot.SLOT_BODY,
                armorType = GenericRPG.ArmorType.ARMOR_CLOTH,
                primaryAttributes = new() { Vitality = 1, Intelligence = 5 }
            };
            string expected = "New armor equipped!";
            //Act
            string actual = hero.EquipItem(testRobe);
            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
