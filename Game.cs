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
        private Dictionary<int, List<Enemies>> EnemyList;
        private Dictionary<int, List<Items>> ItemList;
        public Game()
        {
            // ===Testing goes here V===
            /*
            Console.WriteLine("Test Starting");
            Testing.CombatTest.AttackTest();
            Testing.SpawnerCheck.EnemySpawns();
            Testing.SpawnerCheck.ItemSpawns();
            Console.WriteLine("Press any key to stop tests.");
            Console.ReadKey();
            */

            // ===Game Starts here===
            // Allowes user to pick their own name
            Console.Write("Please enter the name of your hero:  ");
            string username = Console.ReadLine(); 
            player = new Player(username, 100, 25);

            // Creates a list of rooms amd their info.
            RoomList = RoomManager.GetRooms();

            // Creates a list of enemies which relate to each room.
            EnemyList = RoomManager.GetEnemies();

            // Creates a list of enemies which relate to each room.
            ItemList = RoomManager.GetItems();

        }
        /// <summary>
        /// Initializes the game.
        /// </summary>
        public void Start()
        {
            bool playing = true;
            bool PlayerState = true;
            while (playing)
            {
                // clears screen so easier for user
                Console.Clear(); 
                // tell the user what room they are in.
                Console.WriteLine($"You are in: {RoomList[RoomIndex].GetRoomName()}");

                // takes just the enemies from this room from the diciotrany, if no enemies make empty list.
                List<Enemies> currentRoomEnemies = EnemyList.ContainsKey(RoomList[RoomIndex].RoomId) 
                                                    ? EnemyList[RoomList[RoomIndex].RoomId] 
                                                    : new List<Enemies>();
                // checks if room has enenmies in it.
                if (currentRoomEnemies.Count > 0)
                {
                    Console.WriteLine("There are enemies!");
                    BattleManager battleManager = new BattleManager(player, currentRoomEnemies);
                    // Start the battle
                    PlayerState = battleManager.StartBattle();
                    if (PlayerState == false)
                    {
                        playing = false;
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("There are no enemies in this room.");
                }
                // Clears the enemies just in case for some bizare reason battle ended without enemies dead.
                EnemyList[RoomList[RoomIndex].RoomId].Clear();

                // takes just the Items from this room from the diciotrany, if no Items make empty list.
                List<Items> currentRoomItems = ItemList.ContainsKey(RoomList[RoomIndex].RoomId) 
                                                    ? ItemList[RoomList[RoomIndex].RoomId] 
                                                    : new List<Items>();
                // checks if room has Items in it.
                if (currentRoomItems.Count > 0)
                {
                    Console.WriteLine("There are Items!");
                    player.PickUpItem(currentRoomItems);
                }
                else
                {
                    Console.WriteLine("There are no Items in this room.");
                }
                // Clears the Items from this room.
                ItemList[RoomList[RoomIndex].RoomId].Clear();
                Thread.Sleep(1000);
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
                        RoomList[RoomIndex].GetDescription();
                        //Takes player to next room if there is a room available. 
                        if (RoomIndex >= 0 && RoomIndex < RoomList.Count - 1)
                        {
                            Console.WriteLine("Which Direction would you like to go?");
                            // gets an input from the users, remvoes white space and lower cases it.
                            string input = Console.ReadLine()?.Trim().ToLower();
                            // compare if the current room has the inputed direction avaibale
                            if (RoomList[RoomIndex].Directions.TryGetValue(input, out int destinationRoomId))
                            {
                                // change the room to whatever the player picks
                                RoomIndex = destinationRoomId; 
                                Console.WriteLine($"You go {input} to Room {RoomIndex}.");
                                Console.WriteLine("Loading Next Room......");
                            }
                            else
                            {
                                Console.WriteLine("You can't go that way. Going Back.....");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No more rooms.");
                        }
                        Thread.Sleep(2000);
                        break;
                    case "2":
                        // lets the player check player status
                        Console.Clear();
                        Console.WriteLine($"Player Name: {player.Name}");
                        Console.WriteLine($"Player Health: {player.Health}");
                        Console.WriteLine($"Player Damage: {player.Damage}");
                        player.ViewInventory();
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
            Console.WriteLine("Game over, aint no retries.");
        }
    }
}