using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Upgrade : Items
    {
        public int UpgradeAmount { get; set; }

        public Upgrade(string name, string description, int upgradeAmount)
            : base(name, description, ItemType.Upgrade)
        {
            UpgradeAmount = upgradeAmount;
        }
        /// <summary>
        /// You use the thing and it increase your damage stat
        /// </summary>
        public override void Use(Player player)
        {
            player.Damage += UpgradeAmount;
            Console.WriteLine($"used {Name} and gained {UpgradeAmount} damage, permantly for this weapon.");
            player.inventory.Remove(this);
            Console.WriteLine($"{Name} has been Destroyed.");
        }
    }
    public class TitanChunk : Upgrade
    {
        /// <summary>
        /// Name: "Titan Chunk" 
        /// Upgrade Amount: 10
        /// </summary>
        public TitanChunk() : base("Titan Chunk", "Chuck of a titan.", 10) {}
    }
}
