using System;

namespace GameOfChanceSimulator
{
    class Program
    {
        static void Main()
        {

            Game game = new Game();
            game.Start();
        }

        /* static bool ()
        {
            Random rand = new Random();
            for (int i = 0; i< 100; i++)   //Esetek száma
            {
                double randNum = rand.NextDouble();
                if (randNum <= 1 * ((double)1 / 100))   //Esély 1 a 100-hoz
                {
                    System.Console.WriteLine("Hit!");
                    return true;
                }
                else
                {
                    System.Console.WriteLine("Miss.");
                    return false;
                }
            }
        } */


    }
}
