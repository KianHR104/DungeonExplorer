using System;
using System.Threading;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class BattleManager 
    {
        private Player player;
        private List<Enemies> enemies;
        private bool playerTurnTracker = true;
        
        public BattleManager(Player player, List<Enemies> enemies)
        {
            this.player = player;
            this.enemies = enemies;
        }
        /// <summary>
        /// Starts the battle, and sorts the turns out.
        /// </summary>
        public bool StartBattle()
        {
            Console.WriteLine("Battle Starting.");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            Console.Clear(); 
            // if the player dies the game ends.
            while (player.IsAlive() && enemies.Count > 0)
            {
                Console.WriteLine("---Player Stats---");
                Console.WriteLine($"- {player.Name} (HP: {player.Health}, ATK: {player.Damage})");
                Console.WriteLine("---Enemy Stats---");
                // Displays every enemies stats
                foreach (Enemies CurrentEnemy in enemies)
                    {
                        Console.WriteLine($"- {CurrentEnemy.Name} (HP: {CurrentEnemy.Health}, ATK: {CurrentEnemy.Damage})");
                    }
                Thread.Sleep(1000);
                if (playerTurnTracker)
                {
                    PlayerTurn();
                    Thread.Sleep(2000);
                    Console.Clear(); 
                }
                else
                {
                    EnemyTurn();
                    Console.Clear(); 
                }
                // swaps the turn into the enemies
                playerTurnTracker = !playerTurnTracker;
            }
            // displays win if player win, lost if not
            if (player.IsAlive())
            {
                Console.WriteLine("Victory Achieved!");
                return true;
            }
            else
            {
               Console.WriteLine("You Died"); 
               Thread.Sleep(2000);
               return false;
            }
        }
        /// <summary>
        /// controls the players turn
        /// </summary>
        private void PlayerTurn()
        {
            if (player.IsAlive())
            {
                Console.WriteLine("===PLAYER TURN===");
                string action = player.PlayerDecision();
                switch (action)
                {
                    case "Attack":
                        player.Attack(enemies);
                        break;
                    case "Defend":
                        player.Defend();
                        break;
                    case "Inventory":
                        player.ViewInventory();
                        break;
                    default:
                        Console.WriteLine("this shouldnt be happening");
                        //Debug.LogWarning($"Unknown action '{action}' from enemy.");
                        break;
                }
                Console.WriteLine(" ");
            }
        }
        /// <summary>
        /// controls the enemies turn
        /// </summary>
        private void EnemyTurn()
        {
            // goes through all the eenemis
            for (int i = enemies.Count - 1; i >= 0; i--)
            {
                Enemies CurrentEnemy = enemies[i];
                // checks if allive
                if (CurrentEnemy.IsAlive())
                {
                    Console.WriteLine($"==={CurrentEnemy.Name}'s TURN===");
                    // gets the enemies decision.
                    string action = CurrentEnemy.EnemyDecision();
                    switch (action)
                    {
                        case "Attack":
                            CurrentEnemy.Attack(player);
                            break;
                        case "Block":
                            CurrentEnemy.Defend();
                            break;
                        case "Flee":
                            CurrentEnemy.Flee(player);
                            break;
                        case "Summon":
                            CurrentEnemy.Summon(player);
                            break;
                        default:
                            Console.WriteLine("this shouldnt be happening");
                            //Debug.LogWarning($"Unknown action '{action}' from enemy.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine($"{CurrentEnemy.Name} was slain.");
                    enemies.RemoveAt(i);
                }
                Console.WriteLine(" ");
                Thread.Sleep(2000);
            }
        }
    }
}