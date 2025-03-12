using System;
using System.Media;
using System.Threading;
using System.Collections.Generic;

namespace DungeonExplorer
{
    internal class Game
    {
        int RoomIndex = 0;
        private Player player;
        private List<Room> RoomList;
        public Game()
        {
            // Allowes user to pick their own name
            Console.Write("Please enter the name of your hero:  ");
            string username = Console.ReadLine(); 
            player = new Player(username, 100);
            RoomList = new List<Room>
            {
            new Room(
                "Flameconnected church", 
                "It's an crumbling ruin situated to overlook a cliff.", 
                0, 
                new List<string>{
                    "Useless Pendant", 
                    "Zweihander", 
                    "Binoculars"}),

            new Room("Souless village", 
            "It's a decrepit, wooden housing district.", 
            3, 
            new List<string>{
                "Residence Key", 
                "Unending Box"}),

            new Room("Souless Communion", 
            "It's a ruined cathedral district overrun by the Souless.", 
            5, 
            new List<string>{
                "Titan Chunk", 
                "Mystery Key"}),

            new Room("First Chime of arising", 
            "It's a gothic rooftop with 2 stone chimera.", 
            2, 
            new List<string>{
                "The Chimera Halberd", 
                "Chimera Tail Axe"})
            };
        }
        /// <summary>
        /// Initializes the game.
        /// </summary>
        public void Start()
        {
            bool playing = true;
            while (playing)
            {
                Console.Clear(); // clears screen so easier for user
                Console.WriteLine($"You are in: {RoomList[RoomIndex].GetRoomName()}"); // tell the user what room they are in.
                // Checks if enemies are in the room by seeing the enemy count, if so start a fight.
                if (RoomList[RoomIndex].EnemyCount >= 1)
                    {
                        Console.WriteLine("There are enemies in this room, starting fight...");
                        // write code for comabt system... v
                        
                        // Ensure when player clears a room of enemies they dont respawn
                        RoomList[RoomIndex].EnemyCount = 0;
                    }

                // checks if the room had an item
                if (RoomList[RoomIndex].Items != null && RoomList[RoomIndex].Items.Count > 0)
                    {
                        player.PickUpItem(RoomList[RoomIndex].Items);
                        // Empties the item incase player reloads this room
                        RoomList[RoomIndex].Items.Clear();
                        Thread.Sleep(1000);
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
                        Console.WriteLine(RoomList[RoomIndex].GetDescription());
                        //Takes player to next room if there is a room available. 
                        if (RoomIndex >= 0 && RoomIndex < RoomList.Count - 1)
                        {
                            Console.WriteLine("Entering Next Room....");
                            RoomIndex += 1;
                        }
                        else
                        {
                            Console.WriteLine("No more rooms.");
                        }
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();
                        break;
                    case "2":
                        // lets the player check player status
                        Console.Clear();
                        Console.WriteLine($"Player Name: {player.Name}");
                        Console.WriteLine($"Player Health: {player.Health}");
                        Console.WriteLine($"Inventory: {string.Join(", ", player.inventory)}");
                        Console.WriteLine("Press any key to continue.");
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
                        Thread.Sleep(2000);
                        break;
                }
            }
        }
    }
}