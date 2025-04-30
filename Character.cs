using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Character
    {
        public string Name { get; private set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public List<string> inventory = new List<string>();
        private bool isBlocking = false;

        public Character(string name, int health, int damage) 
        {
            Name = name;
            Health = health;
            Damage = damage;
        }

        public virtual void Attack(Character target)
        {
            Console.WriteLine($"{Name} attacks {target.Name} for {Damage} damage.");
            target.TakeDamage(Damage);
        }

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

            // Ensure health doesn't go below zero
            if (Health < 0) Health = 0;
            Console.WriteLine($"{Name} takes {damage} damage. (HP: {Health})");
        }

        public bool IsAlive()
        {
            return Health > 0;
        }

        public virtual void Defend(Character target)
        {
            Console.WriteLine($"{Name} braces for impact!");
            isBlocking = true;
        }
        public virtual void Flee(Character target)
        {
            Console.WriteLine("is fleeing");
        }
        public virtual void Summon(Character target)
        {
            Console.WriteLine("is summoning");
        }
    }
}
