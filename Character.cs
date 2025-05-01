using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Character
    {
        public string Name { get; private set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        private bool isBlocking = false;

        public Character(string name, int health, int damage) 
        {
            Name = name;
            Health = health;
            Damage = damage;
        }

        /// <summary>
        /// Attacks the target for the damage of the attacker.
        /// </summary>
        public virtual void Attack(Character target)
        {
            Console.WriteLine($"{Name} attacks {target.Name} for {Damage} damage.");
            target.TakeDamage(Damage);
        }
        /// <summary>
        /// Works out the damage, becuase blocking and such.
        /// </summary>
        public virtual void TakeDamage(int damage)
        {
            // if character blocking take half damage.
            if (isBlocking) 
            {
                damage /= 2; 
                Console.WriteLine($"{Name} defends against some of the damage.");
                isBlocking = false;
            }
            // make it take damage
            Health -= damage;

            // Ensure health dont go below zero
            if (Health < 0) Health = 0;
            Console.WriteLine($"{Name} takes {damage} damage. (HP: {Health})");
        }

        /// <summary>
        /// do i really i need to write a summary?
        /// </summary>
        public bool IsAlive()
        {
            return Health > 0;
        }

        /// <summary>
        /// Makes it so the characters blocks, (halfing the next damage on them)
        /// </summary>
        public virtual void Defend()
        {
            Console.WriteLine($"{Name} braces for impact!");
            isBlocking = true;
        }

        /// <summary>
        /// if this happens the enemy "dies" or leaves the battle
        /// </summary>
        public virtual void Flee(Character target)
        {
            Console.WriteLine("is fleeing");
        }

        /// <summary>
        /// special case where enemies summon more to aid.
        /// </summary>
        public virtual void Summon(Character target)
        {
            Console.WriteLine("is summoning");
        }
    }
}
