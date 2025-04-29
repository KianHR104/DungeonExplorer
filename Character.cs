using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Character
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        public List<string> inventory = new List<string>();

        public Character(string name, int health) 
        {
            Name = name;
            Health = health;
        }
    }
}
