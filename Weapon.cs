using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Weapon : Items
    {
        public int DamageAmount { get; set; }

        public Weapon(string name, string description, int DamageAmount)
            : base(name, description, ItemType.Weapon)
        {
        }
        /// <summary>
        /// You use the thing and it hurt enemy
        /// </summary>
        public override void Use()
        {
            Console.WriteLine($"you use {Name}, hurt enemy for {DamageAmount} damage");
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
