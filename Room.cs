using System;
using System.Media;
using System.Collections.Generic;

namespace DungeonExplorer
{
public class Room
{
    public string Name { get; set; }
    private string Description { get; set; }
    public int EnemyCount { get; set; }
    public List<string> Items { get; set; }  

    // Constructor should accept List<string> for items
    public Room(string name, string description, int enemyCount, List<string> items)
    {
        Name = name;
        Description = description;
        EnemyCount = enemyCount;
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
    }
}