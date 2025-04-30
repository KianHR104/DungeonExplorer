using System.Collections.Generic;

namespace DungeonExplorer
{
    public static class RoomManager
    {
        /// <summary>
        /// Creates all the required rooms and their info.
        /// </summary>
        /// <returns> Returns the list of rooms. </returns>
        public static List<Room> GetRooms()
        {
                var FirstRoom = new Room(0,
                    "Flameconnected church", 
                    "It's a crumbling ruin situated to overlook a cliff.", 
                    new List<string>{
                        "Useless Pendant", 
                        "Zweihander", 
                        "Binoculars"},
                    new Dictionary<string, int> { 
                        { "east", 1 }});

                var SecondRoom = new Room(1,
                    "Souless village", 
                    "It's a decrepit, wooden housing district.", 
                    new List<string>{
                        "Residence Key", 
                        "Unending Box"},
                    new Dictionary<string, int> { 
                        { "east", 2 }, { "west", 0 }});

                var ThirdRoom = new Room(2,
                    "Souless Communion", 
                    "It's a ruined cathedral district overrun by the Souless.", 
                    new List<string>{
                        "Titan Chunk", 
                        "Mystery Key"},
                    new Dictionary<string, int> { 
                        { "east", 3 }, { "west", 1 }});

                var FourthRoom = new Room(3,
                    "First Chime of arising", 
                    "It's a gothic rooftop with 2 stone chimera.", 
                    new List<string>{
                        "The Chimera Halberd", 
                        "Chimera Tail Axe"},
                    new Dictionary<string, int> { 
                        { "west", 2 }});

                var rooms = new List<Room> { FirstRoom, SecondRoom, ThirdRoom, FourthRoom };
                return rooms;
        }

        /// <summary>
        /// Creates all the requird enemies and their info and where they are.
        /// </summary>
        /// <returns> the list of enenmies locations. </returns>
        public static Dictionary<int, List<Enemies>> GetEnemies()
        {
            return new Dictionary<int, List<Enemies>>
            {
                { 0, new List<Enemies> {} },
                { 1, new List<Enemies> {new HordeofSouless(), new SoulessWarrior()}},
                { 2, new List<Enemies> {new ArmoredBoar()}},
                { 3, new List<Enemies> {new Chimera()}}
            };
        }
    }
}