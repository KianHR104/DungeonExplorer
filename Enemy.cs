using System;

namespace DungeonExplorer
{
    public class Enemies : Character
    {
        protected Random random = new Random();
        public Enemies(string name, int health, int damage) : base(name, health, damage) {}

        // Decision method returns a string action
        public virtual string EnemyDecision()
        {
            int AttackRoll = random.Next(100);
            if (AttackRoll < 5) return "Flee";
            if (AttackRoll < 35) return "Block";
            // 75% attack
            return "Attack"; 
        }
    }
    
    // enemy stats =====================================
    public class HordeofSouless : Enemies
    {
        /// <summary>
        /// Name: "Horde of Souless" 
        /// Health: 26
        /// Damage: 5
        /// </summary>
        public HordeofSouless() : base("Horde of Souless", 26, 5) {}
        // If the enemy has less than 5 hp it runs away.
        public override string EnemyDecision()
        {
            if (Health < 5) return "Flee";
            return base.EnemyDecision();
        }
    }

    public class SoulessWarrior : Enemies
    {
        private bool hasBlocked = false;
        /// <summary>
        /// Name: "Souless Warrior"
        /// Health: 50
        /// Damage: 10
        /// </summary>
        public SoulessWarrior() : base("Souless Warrior", 50, 10) {}
        // if the enemy didnt block last turn it will block this turn.
        public override string EnemyDecision()
        {
            if (!hasBlocked)
            {
                hasBlocked = true;
                return "Block";
            }
            return "Attack";
        }
    }

    public class ArmoredBoar : Enemies
    {
        /// <summary>
        /// Name: "Armored Boar"
        /// Health: 75
        /// Damage: 10
        /// </summary>
        public ArmoredBoar() : base("Armored Boar", 75, 10) {}
        // this enemy ONLY attacks.
        public override string EnemyDecision()
        {
            return "Attack";
        }
    }

    public class Chimera : Enemies
    {
        /// <summary>
        /// Name: "Chimera" 
        /// Health: 100
        /// Damage: 20
        /// </summary>
        public Chimera() : base("Chimera", 100, 20) {}
        // when the enemy hits 50% it summons a second chimera (not implemented)
        public override string EnemyDecision()
        {
            return base.EnemyDecision();
        }
    }
}
