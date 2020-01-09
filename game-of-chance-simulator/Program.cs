using System;
using System.IO;

namespace GameOfChanceSimulator
{
    class Program
    {
        int rounds;
        string path;
        HistoricalDataSet hds;
        ILogger cl;
        //Game game;

        static void Main(string[] args)
        {
            Program program = new Program();
            program.Init(args);
            //Evaluate here
        }

        void Init(string[] args)
        {
            cl = new ConsoleLogger();
            path = "\\history.csv";

            if (args.Length != 0)
            {
                try
                {
                    rounds = Convert.ToInt32(args[0]);
                    hds = GenerateHistoricalDataSet(args);

                    /* foreach (var dataPoint in hds.DataPoints)
                    {
                        foreach (var data in dataPoint.GetType().GetProperties())
                        {
                            cl.Info(data.GetValue(dataPoint, null).ToString());
                        }
                    } */
                    hds.AppendToFile(path);
                }
                catch
                {
                    cl.Error("Invalid argument! Must be a number.");
                }
            }
            //load previously generated data
            else
            {
                cl.Info("Using previously generated data.");
            }
            LoadPreviouslyGeneratedData();
        }

        void LoadPreviouslyGeneratedData()
        {
            try
            {
                if (hds == null)
                    hds = new HistoricalDataSet(cl);
                hds.Load(path);
                DataEvaluator de = new DataEvaluator(hds, cl);
                Result result = de.Run();
                cl.Info($"Number of simulations: {result.NumberOfSimulations} | Best choice: {result.BestChoice} | Chance of winning: {(result.BestChoiceChance * 100).ToString("#.##")}%");
                /* foreach (var dataPoint in hds.DataPoints)
                {
                    foreach (var data in dataPoint.GetType().GetProperties())
                    {
                        cl.Info(data.GetValue(dataPoint, null).ToString());
                    }
                } */
            }
            catch
            {
                cl.Error($"Failed to read {Directory.GetCurrentDirectory() + path}, please generate a few rounds first.");
            }
        }

        HistoricalDataSet GenerateHistoricalDataSet(string[] args)
        {
            hds = new HistoricalDataSet(cl);
            hds.Generate(path, rounds);

            return hds;
        }
    }
}
