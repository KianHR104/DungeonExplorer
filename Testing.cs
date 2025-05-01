using System;
using System.Media;
using System.Diagnostics;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Testing
    {
        public class CombatTest
        {
            // Tests for things involving attacking 
            public static void AttackTest()
            {
                var player = new Player("Player", 100, 15);
                var enemy = new Enemies("Enemy", 50, 10);
                Console.WriteLine("Start Attack test");

                int initialEnemyHealth = enemy.Health;
                player.Attack(enemy);
                Console.WriteLine($"Enemy Health after attack: {enemy.Health}");
                Debug.Assert(enemy.Health == initialEnemyHealth - player.Damage, "the Health values dont allign");

                int initialPlayerHealth = player.Health;
                enemy.Attack(player);
                Console.WriteLine($"Player Health after attack: {player.Health}");
                Debug.Assert(player.Health == initialPlayerHealth - enemy.Damage, "Health values dont allign");
            }
        }
        // Tests for things involving spawners 
        public class SpawnerCheck
        {
            private static Dictionary<int, List<Enemies>> EnemyList;
            private static Dictionary<int, List<Items>> ItemList;
            // checks enemies spawn
            public static void EnemySpawns()
            {
                EnemyList = RoomManager.GetEnemies();
                List<Enemies> currentRoomEnemies = EnemyList.ContainsKey(1) 
                                                    ? EnemyList[1] 
                                                    : new List<Enemies>();
                Console.WriteLine($"Enemy List: {currentRoomEnemies[0]}");
            }
            // checks items spawn
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