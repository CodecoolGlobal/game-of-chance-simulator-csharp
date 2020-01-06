namespace GameOfChanceSimulator
{
    class Troop
    {
        public int Health { get; private set; }
        public int MinDamage { get; private set; }
        public int MaxDamage { get; private set; }

        public Troop(int health, int minDamage, int maxDamage)
        {
            Health = health;
            MinDamage = minDamage;
            MaxDamage = maxDamage;
        }
    }
}
