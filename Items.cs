using System;
using System.Media;
using System.Threading;
using System.Collections.Generic;

namespace DungeonExplorer
{
    internal class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ItemType Type { get; set; }

        public Item(string name, string description, ItemType type)
        {
            Name = name;
            Description = description;
            Type = type;
        }

        // Virtual method to be overridden by specific item types
        public virtual void Use()
        {
            Console.WriteLine($"Used {Name}. (No special action implemented.)");
        }

        public enum ItemType
        {
            Potion,
            Upgrade,
            Weapon,
            Misc
        }
    }
}