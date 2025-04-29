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
        public Dictionary<string, int> Directions { get; set; }
        public Room(int id, string name, string description, 
                    List<string> items,  
                    Dictionary<string, int> directions = null)
        {
            RoomId = id;
            Name = name;
            Description = description;
            Items = items ?? new List<string>(); // Ensures Items is never null
            Directions = directions ?? new Dictionary<string, int>();
        }

        /// <summary>
        /// Allows the user to know the description of the room.
        /// </summary>
        public void GetDescription()
        {
            Console.WriteLine($"Room: {Name}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Directions: {GetDirections()}");
            Console.WriteLine(); 
        }

        /// <summary>
        /// Allows the user to know the name of the room.
        /// </summary>
        /// <returns> Returns a name of the current room. </returns>
        public string GetRoomName()
        {
            return Name;
        }
        
        /// <summary>
        /// gets the directions where a room is placed in relation to the room which is currently player in
        /// </summary>
        /// <returns> everywhere where the player can pick. </returns>
        public string GetDirections()
        {
            // checks if there any directions at all (there should always be atleast 1)
            if (Directions.Count == 0)
            {
                return "this shoudnt be happening.";
            }

            var directionText = new List<string>();
            foreach (var direction in Directions)
            {
                directionText.Add($"{direction.Key} leads to room {direction.Value}");
            }

            return string.Join(", ", directionText);
        }
    }
}