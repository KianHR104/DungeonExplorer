using System;
using System.Media;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        public List<string> inventory = new List<string>();

        public Player(string name, int health) 
        {
            Name = name;
            Health = health;
        }

        /// <summary>
        /// tell the player they found a item, what it is and put it in inventory
        /// </summary>
        public void PickUpItem(List<string> items)
        {
            Console.WriteLine("You find an item:");
            Console.WriteLine(string.Join(", ", items));
            inventory.AddRange(items);
        }
    }
}