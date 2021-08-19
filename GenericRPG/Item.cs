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

        /// <summary>
        /// Creates a new item, class is abstract so an Item has to created of the Class either GenericRPG.Weapon or GenericRPG.Armor
        /// </summary>
        /// <param name="itemName">The name of the item that is to be created</param>
        /// <param name="itemLevel">The required level for a hero to use this item.</param>
        /// <param name="itemSlot">The item slot that the item can be equipped in, requires a ItemSlot enum.</param>
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
        SLOT_HEAD,
        SLOT_BODY,
        SLOT_LEGS,
        SLOT_WEAPON
    }
}
