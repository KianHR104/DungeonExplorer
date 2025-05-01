using System;
using System.Media;
using System.Threading;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Items
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ItemType Type { get; set; }

        public Items(string name, string description, ItemType type)
        {
            Name = name;
            Description = description;
            Type = type;
        }

        public virtual void Use()
        {
            Console.WriteLine($"use {Name} it did something probably.");
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