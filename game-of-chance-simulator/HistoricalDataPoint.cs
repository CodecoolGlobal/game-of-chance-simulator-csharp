using System;

namespace GameOfChanceSimulator
{
    class HistoricalDataPoint
    {
        public int TimesWon { get; }
        public int Rounds { get; }
        public string NationName { get; }
        public HistoricalDataPoint(int timesWon, int rounds, string nationName)
        {
            TimesWon = timesWon;
            Rounds = rounds;
            NationName = nationName;
        }

        public override string ToString()
        {
            return string.Format("{0},{1},{2}", TimesWon, Rounds, NationName);
        }
    }
}