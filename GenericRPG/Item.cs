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

        //
        // Summary:
        //     Creates a new item, class is abstract so an Item has to created of the Class either GenericRPG.Weapon or GenericRPG.Armor
        //
        // Parameters:
        //   itemName
        //     The name of the item that is to be created
        //   itemLevel
        //     The required level for a hero to use this item.
        //   itemSlot
        //     The item slot that the item can be equipped in, requires a ItemSlot enum.
        //
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
