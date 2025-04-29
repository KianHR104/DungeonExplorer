using System;

namespace DungeonExplorer
{
    public class Enemy : Character
    {
        protected Random random = new Random();
        public Enemy(string name, int health, int damage) : base(name, health, damage) {}

        // Decision method returns a string action
        public virtual string EnemyDecision(Player player)
        {
            int roll = random.Next(100);
            if (roll < 5) return "Flee";
            if (roll < 35) return "Block"; // 30% block
            return "Attack"; // 75% attack
        }
    }
    
    // enemy stats =====================================
    public class HordeofSouless : Enemy
    {
        public HordeofSouless() : base("Horde of Souless", 26, 5) {}

        public override string EnemyDecision(Player player)
        {
            if (Health < 10) return "Flee";
            return base.EnemyDecision(player);
        }
    }

    public class SoulessWarrior : Enemy
    {
        private bool hasBlocked = false;

        public SoulessWarrior() : base("Souless Warrior", 50, 10) {}

        public override string EnemyDecision(Player player)
        {
            if (!hasBlocked)
            {
                hasBlocked = true;
                return "Block";
            }
            return "Attack";
        }
    }

    public class ArmoredBoar : Enemy
    {
        public ArmoredBoar() : base("Armored Boar", 75, 10) {}

        public override string EnemyDecision(Player player)
        {
            return "Attack";
        }
    }
}
