using System;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;
        public Game()
        {
            // Initialize the game with one room and one player
            player = new Player("The Selected Souless", 100);
            currentRoom = new Room("The Flameconnected church", "It's an crumbling ruin situated to overlook a cliff, which appears to be inhabbited by a distant town with tall stone walls encasing it. In the centre of these ruins lies a dying tree next to a blade sticking out a campfire.", 0, "Starter Pendant");
        }
        public void Start()
        {
            bool playing = true;
            while (playing)
            {
                Console.Clear(); // clears screen so easier for user
                Console.WriteLine($"You are in: {currentRoom.Name}"); // tell the user what room they are in
                // Checks if enemies are in the room by seeing the enemy count, if so start a fight
                if (currentRoom.Enemy_Count >= 1)
                    {
                        Console.WriteLine("There are enemies in this room starting fight...");
                        // write code for comabt system... v
                        
                        // Ensure when player clears a room of enemies they dont respawn
                        currentRoom.Enemy_Count = 0;
                    }

                // checks if the room had an item
                if (!string.IsNullOrEmpty(currentRoom.Item))
                    {
                        player.PickUpItem(currentRoom.Item);
                        // Empties the item incase player reloads this room
                        currentRoom.Item = "" ;
                        Console.ReadKey();
                        Console.WriteLine("");
                    }

                // The options the player has once defeating the enemies and looting the room.
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Look around the room");
                Console.WriteLine("2. Look at player status");
                Console.WriteLine("3. Exit game");
                // Gets the input by the player
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        // lets the player check room description
                        Console.Clear();
                        Console.WriteLine(currentRoom.GetDescription());
                        Console.ReadKey();
                        break;
                    case "2":
                        // lets the player check player status
                        Console.Clear();
                        Console.WriteLine("player Name:");
                        Console.WriteLine(player.Name);                        
                        Console.WriteLine("player Health:");                        
                        Console.WriteLine(player.Health);
                        Console.WriteLine("Inventory: " + string.Join(", ", player.inventory));
                        Console.ReadKey();
                        break;

                    case "3":
                        // lets player close the game
                        Console.WriteLine("Exiting game...");
                        playing = false; // stops the game
                        break;

                    default:
                        // if player doesnt choose a valid option
                        Console.WriteLine("Invalid choice. Try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}