using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player : Character
    {
        public Player(string name, int health, int damage) : base(name, health, damage) 
        {
        }

        /// <summary>
        /// Tell the player they found an item, what it is, and put it in inventory
        /// </summary>
        public void PickUpItem(List<string> items)
        {
            Console.WriteLine("You find an item:");
            Console.WriteLine(string.Join(", ", items));
            inventory.AddRange(items);
        }
    }
}
