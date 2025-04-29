using System.Collections.Generic;

namespace DungeonExplorer
{
    public static class RoomManager
    {
        public static List<Room> GetRooms()
        {
            return new List<Room>
            {
                new Room(1,
                    "Flameconnected church", 
                    "It's a crumbling ruin situated to overlook a cliff.", 
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
        }
        public static Dictionary<int, List<Enemy>> GetEnemies()
        {
            return new Dictionary<int, List<Enemy>>
            {
                { 1, new List<Enemy> {} },
                { 2, new List<Enemy> {new Enemy("Horde of Souless", 25, 5), new Enemy("Souless Warrior", 30, 10)}},
                { 3, new List<Enemy> {new Enemy("Armored Boar", 75, 10) } },
                { 4, new List<Enemy> {new Enemy("Chimera", 100, 20), new Enemy("Chimera 2", 50, 20)}}
            };
        }
    }
}