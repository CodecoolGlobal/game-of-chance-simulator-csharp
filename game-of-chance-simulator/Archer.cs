namespace GameOfChanceSimulator
{
    class Archer : Troop
    {
        int Chance { get; set; }
        public Archer(int chance) : base(40, 50, 100)
        {
            Chance = chance;
        }
    }
}
