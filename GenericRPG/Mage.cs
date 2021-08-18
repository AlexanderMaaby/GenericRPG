namespace GenericRPG
{
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

        public override bool AvailableArmorType(Armor item)
        {
            return (item.armorType == ArmorType.ARMOR_CLOTH && item.ItemLevel <= Level);
        }

        public override bool AvailableWeaponType(Weapon item)
        {
            return (item.WeaponType == WeaponType.WEAPON_STAFF || item.WeaponType == WeaponType.WEAPON_WAND) && item.ItemLevel <= Level;
        }

        public override double GetMainPrimaryAttributeValue()
        {
            return (double) totalPrimaryAttributes.Intelligence;
        }
    }
}
