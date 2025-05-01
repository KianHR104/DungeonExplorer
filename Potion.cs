using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Potion : Items
    {
        public int HealAmount { get; set; }

        public Potion(string name, string description, int healAmount)
            : base(name, description, ItemType.Potion)
        {
            HealAmount = healAmount;
        }
        /// <summary>
        /// You use the thing and it heals you.
        /// </summary>
        public override void Use(Player player)
        {
            player.Health += HealAmount;
            Console.WriteLine($"drank {Name} and heal {HealAmount} HP");
            player.inventory.Remove(this);
            Console.WriteLine($"{Name} has been consumed.");
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
