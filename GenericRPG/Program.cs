using System;
using System.Drawing;
using System.Threading;

namespace GenericRPG
{
    public class Program
    {
        static void Main(string[] args)
        {
            Warrior heroicdude = new Warrior();
            Armor testChest = new Armor()
            {
                ItemName = "Big Bad Armor",
                ItemLevel = 1,
                ItemSlot = ItemSlot.SLOT_BODY,
                armorType = ArmorType.ARMOR_PLATE,
                primaryAttributes = new() { Vitality = 2, Strength = 1 }
            };
            GenericRPG.Weapon testAxe = new GenericRPG.Weapon()
            {
                ItemName = "Garrosh Axe",
                ItemLevel = 1,
                ItemSlot = GenericRPG.ItemSlot.SLOT_WEAPON,
                WeaponType = GenericRPG.WeaponType.WEAPON_AXE,
                WeaponDamage = 7,
                AttackSpeed = 1.1,
                AttackDPS = 7.0 * 1.1
            };
            heroicdude.EquipItem(testAxe);
            heroicdude.EquipItem(testChest);
            foreach (string turnips in heroicdude.CharacterSheetString())
            {
                Console.WriteLine(turnips);
            }
            Console.WriteLine((7.00 * 1.1) * (1.00 * (1.00 + ((5.00 + 1.00) / 100.00))));

            //gameloop
            bool game = true;
            while(game)
            {
                Console.Clear();
                Console.WriteLine("Input your action, 'levelup', 'exit'");
                string input = Console.ReadLine();
                if (input.Equals("exit"))
                {
                    game = false;
                }
                if (input.Equals("levelup"))
                {
                    heroicdude.LevelUp(1);
                }
                foreach (string turnips in heroicdude.CharacterSheetString())
                {
                    Console.WriteLine(turnips);
                }
                Console.ReadLine();
            }
        }
    }
}
