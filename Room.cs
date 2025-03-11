using System;
using System.Media;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Room
    {
        public string Name { get; set; }
        private string Description { get; set; }
        public int Enemy_Count { get; set; }
        public string Item { get; set; }

        public Room(string name, string description, int enemy_count ,string item)
        {
            Name = name;
            Description = description;
            Enemy_Count = enemy_count;
            Item = item;
        }
        // allows player to read description of room 
        public string GetDescription()
        {
            return Description;
        }
    }
}