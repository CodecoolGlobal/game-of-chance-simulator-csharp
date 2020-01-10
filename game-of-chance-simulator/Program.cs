using System;
using System.IO;

namespace GameOfChanceSimulator
{
    class Program
    {
        int rounds;
        string path;
        HistoricalDataSet hds;
        ILogger logger;
        //Game game;

        static void Main(string[] args)
        {
            Program program = new Program();
            program.Init(args);
            //Evaluate here
        }

        void Init(string[] args)
        {
            logger = new ConsoleLogger();
            path = "\\history.csv";

            if (args.Length != 0)
            {
                try
                {
                    rounds = Convert.ToInt32(args[0]);
                }
                catch
                {
                    logger.Error("Invalid argument! Must be a number.");
                }

                if (args[0] != "0")
                {
                    hds = GenerateHistoricalDataSet();
                    /* foreach (var dataPoint in hds.DataPoints)
                    {
                        foreach (var data in dataPoint.GetType().GetProperties())
                        {
                            logger.Info(data.GetValue(dataPoint, null).ToString());
                        }
                    } */

                    hds.AppendToFile(path);
                }
            }
            //load previously generated data
            logger.Info("Using previously generated data.");
            LoadPreviouslyGeneratedData();
        }

        void LoadPreviouslyGeneratedData()
        {
            try
            {
                //if (hds == null)
                hds = new HistoricalDataSet(logger);
                hds.Load(path);
                DataEvaluator de = new DataEvaluator(hds, logger);
                Result result = de.Run();
                logger.Info($"Number of simulations: {result.NumberOfSimulations} | choice: {result.BestChoice} | Chance of winning: {(result.BestChoiceChance * 100).ToString("#.##")}%");
            }
            catch
            {
                logger.Error($"Failed to read {Directory.GetCurrentDirectory() + path}, please generate a few rounds first.");
            }
        }

        HistoricalDataSet GenerateHistoricalDataSet()
        {
            hds = new HistoricalDataSet(logger);
            hds.Generate(path, rounds);


            return hds;
        }
    }
}
