using System;

namespace GameOfChanceSimulator
{
    class Program
    {
        static void Main()
        {

            Game game = new Game();
            Console.WriteLine(game.Start());
        }
    }
}
