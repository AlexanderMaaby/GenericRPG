using System;
using System.Drawing;
using System.Threading;

namespace GenericRPG
{
    public class Program
    {
        static void Main(string[] args)
        {
            Mage heroicdude = new Mage();
            Console.WriteLine("Hello World!");
            Weapon weapon = new Weapon();
            Armor armor = new Armor();
            Console.WriteLine("Bong bong: " + weapon.ItemSlot.ToString());
            heroicdude.EquipItem(weapon);
            heroicdude.EquipItem(armor);
            foreach(string turnips in heroicdude.CharacterSheetString())
            {
                Console.WriteLine(turnips);
            }
          
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
