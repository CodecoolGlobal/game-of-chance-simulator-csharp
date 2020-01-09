using System;

namespace GameOfChanceSimulator
{
    class Troop
    {
        public int Health { get; private set; }
        public int MinDamage { get; private set; }
        public int MaxDamage { get; private set; }
        public int BlockChance { get; private set; }

        public Troop(int health, int minDamage, int maxDamage, int blockChance)
        {
            Health = health;
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            BlockChance = blockChance;
        }

        public bool IsDead()
        {
            if (Health <= 0)
                return true;
            return false;
        }

        public int Attack(Troop target)
        {
            int damage = CalcDamage();
            if (!target.IsDead())
            {
                target.Health -= damage;
            }
            if (target.Health < 0)
            {
                target.Health = 0;
            }
            return damage;
        }

        int CalcDamage()
        {
            Random rand = new Random();
            return rand.Next(MinDamage, MaxDamage + 1);
        }
    }
}
