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

        public Character(string name, int health, int damage) 
        {
            Name = name;
            Health = health;
            Damage = damage;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0; // Prevent health from going below 0
        }

        public bool IsAlive()
        {
            return Health > 0;
        }
    }
}
