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
        private Dictionary<int, List<Enemy>> EnemyList;
        public Game()
        {
            // Allowes user to pick their own name
            Console.Write("Please enter the name of your hero:  ");
            string username = Console.ReadLine(); 
            player = new Player(username, 100, 25);
            RoomList = new List<Room>
            {
            new Room(1,
                "Flameconnected church", 
                "It's an crumbling ruin situated to overlook a cliff.", 
                new List<string>{
                    "Useless Pendant", 
                    "Zweihander", 
                    "Binoculars"}),

            new Room(2,
            "Souless village", 
            "It's a decrepit, wooden housing district.", 
            new List<string>{
                "Residence Key", 
                "Unending Box"}),

            new Room(3,
            "Souless Communion", 
            "It's a ruined cathedral district overrun by the Souless.", 
            new List<string>{
                "Titan Chunk", 
                "Mystery Key"}),

            new Room(4,
            "First Chime of arising", 
            "It's a gothic rooftop with 2 stone chimera.", 
            new List<string>{
                "The Chimera Halberd", 
                "Chimera Tail Axe"})
            };

            // Creates a list of enemies which relate to each room.
            EnemyList = new Dictionary<int, List<Enemy>>()
            {
                { 1, new List<Enemy> {} },
                { 2, new List<Enemy> {new Enemy("Horde of Souless", 30, 5), new Enemy("Souless Warrior", 50, 10)}},
                { 3, new List<Enemy> {new Enemy("Armored Boar", 150, 10) } },
                { 4, new List<Enemy> {new Enemy("Chimera", 100, 20), new Enemy("Chimera 2", 50, 20)}}
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
                // clears screen so easier for user
                Console.Clear(); 
                // tell the user what room they are in.
                Console.WriteLine($"You are in: {RoomList[RoomIndex].GetRoomName()}");

                // Checks if enemies are in the room by comparing the room id to the Enemy list dictionary
                if (EnemyList.ContainsKey(RoomList[RoomIndex].Id) && EnemyList[RoomList[RoomIndex].Id].Count > 0)
                {
                    Console.WriteLine("There are enenmies");
                    
                    EnemyList[RoomList[RoomIndex].Id].Clear();
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