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
        public bool IsAlive => Health > 0;

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
            Health -= damage;
            if (Health < 0) Health = 0;
            Console.WriteLine($"{Name} takes {damage} damage. (HP: {Health})");
        }
    }
}
