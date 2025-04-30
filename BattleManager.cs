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
        public void StartBattle()
        {
            Console.WriteLine("Battle Starting.");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            while (player.IsAlive())
            {
                Console.WriteLine("---Player Stats---");
                Console.WriteLine($"- {player.Name} (HP: {player.Health}, ATK: {player.Damage})");
                Console.WriteLine("---Enemy Stats---");
                foreach (Enemies CurrentEnemy in enemies)
                    {
                        Console.WriteLine($"- {CurrentEnemy.Name} (HP: {CurrentEnemy.Health}, ATK: {CurrentEnemy.Damage})");
                    }
                if (playerTurnTracker)
                {
                    PlayerTurn();
                    Thread.Sleep(2000);
                }
                else
                {
                    EnemyTurn();
                }

                playerTurnTracker = !playerTurnTracker;
            }

            Console.WriteLine(player.IsAlive() ? "You win!" : "You lost!");
        }
        private void PlayerTurn()
        {
            if (player.IsAlive())
            {
                Console.WriteLine("===PLAYER TURN===");
                //player.Attack();
            }
        }

        private void EnemyTurn()
        {
            foreach (Enemies CurrentEnemy in enemies)
            {
                if (CurrentEnemy.IsAlive())
                {
                    Console.WriteLine($"==={CurrentEnemy.Name}'s TURN===");
                    string action = CurrentEnemy.EnemyDecision();
                    switch (action)
                    {
                        case "Attack":
                            CurrentEnemy.Attack(player);
                            break;
                        case "Block":
                            CurrentEnemy.Defend(player);
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
                Thread.Sleep(2000);
            }
        }
    }
}