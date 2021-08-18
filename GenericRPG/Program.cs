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

        }
        static void ColorfulAnimation()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    Console.Clear();

                    // steam
                    Console.Write("       . . . . o o o o o o", Color.LightGray);
                    for (int s = 0; s < j / 2; s++)
                    {
                        Console.Write(" o", Color.LightGray);
                    }
                    Console.WriteLine();

                    var margin = "".PadLeft(j);
                    Console.WriteLine(margin + "                _____      o", Color.LightGray);
                    Console.WriteLine(margin + "       ____====  ]OO|_n_n__][.", Color.DeepSkyBlue);
                    Console.WriteLine(margin + "      [________]_|__|________)< ", Color.DeepSkyBlue);
                    Console.WriteLine(margin + "       oo    oo  'oo OOOO-| oo\\_", Color.Blue);
                    Console.WriteLine("   +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+", Color.Silver);

                    Thread.Sleep(200);
                }
            }
        }
    }
}
