using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfChanceSimulator
{
    class DataEvaluator
    {
        HistoricalDataSet HistoricalDataSet { get; }
        public DataEvaluator(HistoricalDataSet historicalDataSet, ILogger logger)
        {
            HistoricalDataSet = historicalDataSet;
        }

        public Result Run()
        {
            float chance = 0.0f;
            int numberOfSimulations = 0;
            Dictionary<string, int> nations = new Dictionary<string, int>();

            foreach (var dataPoint in HistoricalDataSet.DataPoints)
            {
                numberOfSimulations += dataPoint.Rounds;    //simulations are the same as rounds

                if (nations.ContainsKey(dataPoint.NationName))
                {
                    nations[dataPoint.NationName] += dataPoint.TimesWon;
                }
                else
                {
                    nations.Add(dataPoint.NationName, dataPoint.TimesWon);
                }
            }

            string bestChoice="";// = nations.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;

            int best = nations.Aggregate((l, r) => l.Value > r.Value ? l : r).Value;

            chance = (float)best / numberOfSimulations;

            foreach (var nation in nations)
            {
                if (nation.Value==best)
                {
                    bestChoice +=nation.Key+", ";
                }
            }

            bestChoice = bestChoice.Remove(bestChoice.Length - 2);


            return new Result(numberOfSimulations, bestChoice, chance);
        }
    }
}
