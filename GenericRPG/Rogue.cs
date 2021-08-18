namespace GenericRPG
{
    public class Rogue : Hero
    {
        public Rogue()
        {
            basePrimaryAttributes = new BasePrimaryAttributes(2,6,1,8);
            totalPrimaryAttributes = new BasePrimaryAttributes(2,6,1,8);
            secondaryAttributes = new SecondaryAttributes(2,6,1,8);
        }
        public override void IncreasePrimaryAttributes()
        {
            basePrimaryAttributes.IncreasePrimaryAttributes(1, 4, 1, 3);
            totalPrimaryAttributes.IncreasePrimaryAttributes(1, 4, 1, 3);
        }

        public override bool AvailableArmorType(Armor item)
        {
            return (item.armorType == ArmorType.ARMOR_LEATHER || item.armorType == ArmorType.ARMOR_MAIL) && item.ItemLevel <= Level;
        }

        public override bool AvailableWeaponType(Weapon item)
        {
            return (item.WeaponType == WeaponType.WEAPON_DAGGER || item.WeaponType == WeaponType.WEAPON_SWORD) && item.ItemLevel <= Level;
        }

        public override double GetMainPrimaryAttributeValue()
        {
            return (double) totalPrimaryAttributes.Dexterity;
        }
    }
}
