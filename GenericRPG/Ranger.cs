namespace GenericRPG
{
    public class Ranger : Hero
    {
        public Ranger()
        {
            basePrimaryAttributes = new BasePrimaryAttributes(1,7,1,8);
            totalPrimaryAttributes = new BasePrimaryAttributes(1,7,1,8);
            secondaryAttributes = new SecondaryAttributes(1,7,1,8);
        }
        public override void IncreasePrimaryAttributes()
        {
            basePrimaryAttributes.IncreasePrimaryAttributes(1, 5, 1, 2);
            totalPrimaryAttributes.IncreasePrimaryAttributes(1, 5, 1, 2);
        }

        public override bool AvailableArmorType(Armor item)
        {
            return (item.armorType == ArmorType.ARMOR_LEATHER || item.armorType == ArmorType.ARMOR_MAIL) && item.ItemLevel <= Level;
        }

        public override bool AvailableWeaponType(Weapon item)
        {
            return item.WeaponType == WeaponType.WEAPON_BOW && item.ItemLevel <= Level;
        }

        public override double GetMainPrimaryAttributeValue()
        {
            return (double) totalPrimaryAttributes.Dexterity;
        }
    }
}
