namespace GenericRPG
{
    public class Warrior : Hero
    {
        public Warrior()
        {
            basePrimaryAttributes = new BasePrimaryAttributes(5,2,1,10);
            totalPrimaryAttributes = new BasePrimaryAttributes(5,2,1,10);
            secondaryAttributes = new SecondaryAttributes(5,2,1,10);
        }
        public override void IncreasePrimaryAttributes()
        {
            basePrimaryAttributes.IncreasePrimaryAttributes(3, 2, 1, 5);
            totalPrimaryAttributes.IncreasePrimaryAttributes(3, 2, 1, 5);
        }

        public override bool AvailableArmorType(Armor item)
        {
            return ((item.armorType == ArmorType.ARMOR_PLATE || item.armorType == ArmorType.ARMOR_MAIL) && item.ItemLevel <= Level);
        }

        public override bool AvailableWeaponType(Weapon item)
        {
            return (item.WeaponType == WeaponType.WEAPON_AXE || item.WeaponType == WeaponType.WEAPON_HAMMER || item.WeaponType == WeaponType.WEAPON_SWORD) && item.ItemLevel <= Level;
        }

        public override double GetMainPrimaryAttributeValue()
        {
            return (double) totalPrimaryAttributes.Strength;
        }
    }
}
