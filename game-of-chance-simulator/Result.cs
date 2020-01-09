namespace GameOfChanceSimulator
{
    public class Result
    {
        public int NumberOfSimulations { get; }
        public string BestChoice { get; }
        public float BestChoiceChance { get; }
        public Result(int numberOfSimulations, string bestChoice, float bestChoiceChance)
        {
            NumberOfSimulations = numberOfSimulations;
            BestChoice = bestChoice;
            BestChoiceChance = bestChoiceChance;
        }
    }
}