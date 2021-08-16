using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG
{
    public abstract class Item
    {
        public string ItemName { get; set; }
        public int ItemLevel { get; set; }
        public ItemSlot ItemSlot { get; set; }

        protected Item(string itemName, int itemLevel, ItemSlot itemSlot)
        {
            ItemName = itemName;
            ItemLevel = itemLevel;
            ItemSlot = itemSlot;
        }
        protected Item()
        {
            
        }
    }

    public enum ItemSlot
    {
        Head,
        Body,
        Legs,
        Weapon
    }
}
