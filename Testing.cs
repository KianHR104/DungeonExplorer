using System;
using System.Media;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Testing
    {
        public class CombatTest
        {
            public static void AttackTest()
            {
                var player = new Player("Player", 100, 15);
                var enemy = new Enemies("Enemy", 50, 10);
                Console.WriteLine("Start test");
                player.Attack(enemy);
                Console.WriteLine($"Enemy Health after attack: {enemy.Health}");
                enemy.Attack(player);
                Console.WriteLine($"Player Health after attack: {player.Health}");
            }
        }
        public class SpawnerCheck
        {
            private static Dictionary<int, List<Enemies>> EnemyList;
            private static Dictionary<int, List<Items>> ItemList;
            public static void EnemySpawns()
            {
                EnemyList = RoomManager.GetEnemies();
                List<Enemies> currentRoomEnemies = EnemyList.ContainsKey(1) 
                                                    ? EnemyList[1] 
                                                    : new List<Enemies>();
                Console.WriteLine($"Enemy List: {currentRoomEnemies[0]}");
            }
            public static void ItemSpawns()
            {
                ItemList = RoomManager.GetItems();
                List<Items> currentRoomItems = ItemList.ContainsKey(1) 
                                                    ? ItemList[1] 
                                                    : new List<Items>();
                Console.WriteLine($"Enemy List: {currentRoomItems[0]}");
            }
        }
    }
}