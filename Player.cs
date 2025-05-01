using System;
using System.Linq;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player : Character
    {
        public List<Items> inventory = new List<Items>();

        public Player(string name, int health, int damage) : base(name, health, damage) 
        {
            inventory = new List<Items>();
        }

        /// <summary>
        /// lets player decide what to do
        /// </summary>
        /// <returns> what the player is going to do </returns>
        public virtual string PlayerDecision()
        {
            while(true)
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Attack.");
                Console.WriteLine("2. Defend");
                Console.WriteLine("3. Inventory");
                // Gets the input by the player
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        return "Attack"; 
                    case "2":
                        return "Defend"; 
                    case "3":
                        return "Inventory"; 
                    default:
                        Console.WriteLine("Please pick from the options.");
                        break;
                }
            }
        }

        /// <summary>
        /// this is the attack for the player, which allows targeting.
        /// </summary>
        public void Attack(List<Enemies> targets)
        {
            // repeats until player input valid input
            while (true)
            {
                // Display available targets
                Console.WriteLine("Select a target to attack:");
                for (int i = 0; i < targets.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {targets[i].Name}");
                }

                // get player input
                string input = Console.ReadLine();
                // try to turn it into int, if not it does the else.
                if (int.TryParse(input, out int choice))
                {
                    choice -= 1; 
                    // checks if the choice matchs with an alive charater.
                    if (choice >= 0 && choice < targets.Count)
                    {
                        Character target = targets[choice];
                        Console.WriteLine($"{Name} attacks {target.Name} for {Damage}.");
                        target.TakeDamage(Damage);
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("thats not a character.");
                }
            }
        }
        
        /// <summary>
        /// Tell the player they found an item, what it is, and put it in inventory
        /// </summary>
        public void PickUpItem(List<Items> roomItems)
        {
            foreach (Items item in roomItems)
            {
                inventory.Add(item);
                Console.WriteLine($"You picked up: {item.Name} - {item.Description}");
            }
        }
        /// <summary>
        /// Allows you to.... View the invnetory.
        /// </summary>
        public void ViewInventory()
        {
            // this is using System.Linq;
            Console.WriteLine($"Inventory: {string.Join(", ", inventory.Select(item => item.Name))}");
        }

        /// <summary>
        /// Allows you to View the invnetory however they are displayed by item type.
        /// </summary>
        public void DisplayItemsByType()
        {
            // LINQ - group iventory by the item type
            var SortedItems = inventory.GroupBy(item => item.Type);
            // goes through every group
            foreach (var group in SortedItems)
            {
                Console.WriteLine($"Items of type: {group.Key}");
                // goess through every item in those groups
                foreach (var item in group)
                {
                    Console.WriteLine($"- {item.Name}");
                }
            }
        }
        /// <summary>
        /// Allows the user to pick an item and use it
        /// </summary>
        public void PickItem()
        {
            while (true)
            {
                Console.WriteLine("What item you want to use?   ");
                // gets ipout from user.
                string input = Console.ReadLine();
                // looks for the input in the inventroy
                var selectedItem = inventory.FirstOrDefault(item => 
                    item.Name.Equals(input, StringComparison.OrdinalIgnoreCase));

                if (selectedItem != null)
                {
                    Console.WriteLine($"You picked: {selectedItem.Name}");
                    // use the item
                    selectedItem.Use(this);
                    break;
                }
                // force the user to input correct answer.
                else
                {
                    Console.WriteLine("please enter a actual item");
                }
            }
        }
    }
}
