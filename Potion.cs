using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Potion : Items
    {
        public int HealAmount { get; set; }

        public Potion(string name, string description, int HealAmount)
            : base(name, description, ItemType.Potion)
        {
        }
        /// <summary>
        /// You use the thing and it heals you.
        /// </summary>
        public override void Use()
        {
            Console.WriteLine($"drank {Name} and heal {HealAmount} HP");
        }
    }
    public class BottleOfFire : Potion
    {
        /// <summary>
        /// Name: "Bottle Of Fire" 
        /// Healing: 40
        /// </summary>
        public BottleOfFire() : base("Bottle Of Fire", "The Souless treasure these flasks. drink to restore HP.", 40) {}
    }
    public class LifeGem : Potion
    {
        /// <summary>
        /// Name: "Life Gem" 
        /// Healing: 50
        /// </summary>
        public LifeGem() : base("Life Gem", "Wow this is better in every way!", 50) {}
    }
}
