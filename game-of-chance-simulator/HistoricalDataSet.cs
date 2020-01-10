using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GameOfChanceSimulator
{
    class HistoricalDataSet
    {
        int Size { get; }
        List<HistoricalDataPoint> _DataPoints;
        public IReadOnlyList<HistoricalDataPoint> DataPoints { get { return _DataPoints.AsReadOnly(); } }

        ILogger Logger;
        bool Tie = true;
        public HistoricalDataSet(ILogger logger)
        {
            Logger = logger;
            _DataPoints = new List<HistoricalDataPoint>();
        }

        public void Generate(string path, int rounds)
        {
            Dictionary<string, int> nations = new Dictionary<string, int>();
            int timesWon = 0;
            string winner = "";
            

            Logger.Info($"Generating {rounds} rounds of data");
            for (int i = 0; i < rounds; i++)
            {
                Game game = new Game();

                Logger.Info($"Generating 1 round of data.");
                Logger.Info("Nations: Swadia, Rhodok, Nord, Khergit, Vaegir, Sarranid");
                winner = game.Start();
                Logger.Info($"Winner: {winner}");

                if (nations.ContainsKey(winner))
                {
                    nations[winner] += 1;
                }
                else
                {
                    nations.Add(winner, 1);
                }
                timesWon = nations.Aggregate((l, r) => l.Value > r.Value ? l : r).Value;
            }

            foreach (var nation in nations)
            {
                _DataPoints.Add(new HistoricalDataPoint(nation.Value, rounds, nation.Key));
            }
            if (Tie)
            {
                System.Console.WriteLine("TIE GAME");

            }
            
        }

        public void AppendToFile(string path)
        {
            for(int i=0;i<DataPoints.Count;i++)
            {
                File.AppendAllText(@Directory.GetCurrentDirectory() + path, DataPoints[i].ToString() + Environment.NewLine);
            }
        }

        public void Load(string path)
        {
            //DataManager dm = new DataManager(@Directory.GetCurrentDirectory() + path);
            /* foreach (var line in dm.GetLines())
            {

            } */
            foreach (string line in File.ReadLines(@Directory.GetCurrentDirectory() + path))
            {
                string[] row = line.Split(",");
                //System.Console.WriteLine(string.Join(",", row));
                _DataPoints.Add(new HistoricalDataPoint(Convert.ToInt32(row[0]), Convert.ToInt32(row[1]), row[2]));
            }
        }
    }
}
