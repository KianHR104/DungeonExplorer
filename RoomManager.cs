using System.Collections.Generic;

namespace DungeonExplorer
{
    public static class RoomManager
    {
        /// <summary>
        /// Creates all the required rooms and their info.
        /// </summary>
        public static List<Room> GetRooms()
        {
                var room1 = new Room(1,
                    "Flameconnected church", 
                    "It's a crumbling ruin situated to overlook a cliff.", 
                    new List<string>{
                        "Useless Pendant", 
                        "Zweihander", 
                        "Binoculars"},
                    new Dictionary<string, int> { 
                        { "east", 2 }});

                var room2 = new Room(2,
                    "Souless village", 
                    "It's a decrepit, wooden housing district.", 
                    new List<string>{
                        "Residence Key", 
                        "Unending Box"},
                    new Dictionary<string, int> { 
                        { "east", 3 }, { "west", 1 }});

                var room3 = new Room(3,
                    "Souless Communion", 
                    "It's a ruined cathedral district overrun by the Souless.", 
                    new List<string>{
                        "Titan Chunk", 
                        "Mystery Key"},
                    new Dictionary<string, int> { 
                        { "east", 4 }, { "west", 2 }});

                var room4 = new Room(4,
                    "First Chime of arising", 
                    "It's a gothic rooftop with 2 stone chimera.", 
                    new List<string>{
                        "The Chimera Halberd", 
                        "Chimera Tail Axe"},
                    new Dictionary<string, int> { 
                        { "west", 3 }});

                var rooms = new List<Room> { room1, room2, room3, room4 };
                return rooms;
        }

        /// <summary>
        /// Creates all the required enemies and their info and where they are.
        /// </summary>
        public static Dictionary<int, List<Enemy>> GetEnemies()
        {
            return new Dictionary<int, List<Enemy>>
            {
                { 1, new List<Enemy> {} },
                { 2, new List<Enemy> {new HordeofSouless(), new SoulessWarrior()}},
                { 3, new List<Enemy> {new ArmoredBoar()}},
                { 4, new List<Enemy> {new Enemy("Chimera", 100, 20)}}
            };
        }
    }
}