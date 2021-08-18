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
    }
}
