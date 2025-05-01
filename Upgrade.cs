using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Upgrade : Items
    {
        public int UpgradeAmount { get; set; }

        public Upgrade(string name, string description, int UpgradeAmount)
            : base(name, description, ItemType.Upgrade)
        {
        }
        /// <summary>
        /// You use the thing and it increase your damage stat
        /// </summary>
        public override void Use()
        {
            Console.WriteLine($"used {Name} and gained {UpgradeAmount} damage, permantly");
        }
    }
    public class TitanChunk : Upgrade
    {
        /// <summary>
        /// Name: "Titan Chunk" 
        /// Upgrade Amount: 5
        /// </summary>
        public TitanChunk() : base("Titan Chunk", "Chuck of a titan.", 5) {}
    }
}
