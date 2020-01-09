using System;

namespace GameOfChanceSimulator
{
    public class Troop
    {
        Random rand = new Random();
        public int Health { get; private set; }
        public int MinDamage { get; private set; }
        public int MaxDamage { get; private set; }
        public int DealtDamage { get; private set; }

        public Troop(int health, int minDamage, int maxDamage)
        {
            Health = health;
            MinDamage = minDamage;
            MaxDamage = maxDamage;

            DealtDamage = rand.Next(minDamage, maxDamage + 1);
        }

        public void Attack(Troop target,Troop attacker)
        {
            target.Health -= attacker.DealtDamage;
            if (target.Health < 0)
            {
                target.Health = 0;
            }
        }

        public void AddBonus(Troop troopToBuff,string bonus)
        {
            if (bonus.Equals("Health"))
            {
                troopToBuff.Health += 10;
            }

            if (bonus.Equals("Attack"))
            {
                troopToBuff.MinDamage += 10;
                troopToBuff.MaxDamage += 10;
                troopToBuff.DealtDamage = rand.Next(troopToBuff.MinDamage, troopToBuff.MaxDamage + 1);
            }
        }
    }
}
