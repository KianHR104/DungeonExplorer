using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Weapon : Items
    {
        public int DamageAmount { get; set; }

        public Weapon(string name, string description, int damageAmount)
            : base(name, description, ItemType.Weapon)
        {
            DamageAmount = damageAmount; 
        }
        /// <summary>
        /// You use the weapon and it equips it.
        /// </summary>
        public override void Use(Player player)
        {
            player.Damage = DamageAmount;
            Console.WriteLine($"you equipped {Name}, now you deal {DamageAmount} damage.");
        }
    }

    public class Zweihander : Weapon
    {
        /// <summary>
        /// Name: "Zweihander" 
        /// Damage: 30
        /// </summary>
        public Zweihander() : base("Zweihander", "One of the gigantic straight greatswords.", 30) {}
    }
    public class TheChimeraHalberd : Weapon
    {
        /// <summary>
        /// Name: "The Chimera Halberd" 
        /// Damage: 40
        /// </summary>
        public TheChimeraHalberd() : base("The Chimera Halberd", "You took this off his corpse didnt you?", 40) {}
    }
    public class ChimeraTailAxe : Weapon
    {
        /// <summary>
        /// Name: "Chimera Tail Axe" 
        /// Damage: 40
        /// </summary>
        public ChimeraTailAxe() : base("Chimera Tail Axe", "Its that blokes tail.", 40) {}
    }
}
