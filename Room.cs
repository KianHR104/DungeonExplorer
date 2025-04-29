using System;
using System.Media;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Room
    {
        public int RoomId { get; set; }
        private string Name { get; set; }
        private string Description { get; set; }
        public List<string> Items { get; set; }  

        // Constructor should accept List<string> for items
        public Room(int id, string name, string description, List<string> items)
        {
            RoomId = id;
            Name = name;
            Description = description;
            Items = items ?? new List<string>(); // Ensures Items is never null
        }

        /// <summary>
        /// Allows the user to know the description of the room.
        /// </summary>
        /// <returns> Returns a description of the current room. </returns>
        public string GetDescription()
        {
            return Description;
        }

        /// <summary>
        /// Allows the user to know the name of the room.
        /// </summary>
        /// <returns> Returns a name of the current room. </returns>
        public string GetRoomName()
        {
            return Name;
        }
    }
}