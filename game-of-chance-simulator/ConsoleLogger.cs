using System;

namespace GameOfChanceSimulator
{
    public class ConsoleLogger : ILogger
    {
        public ConsoleLogger()
        {

        }

        public void Error(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.Write("ERROR ");
            Console.ForegroundColor = ConsoleColor.White;
            System.Console.WriteLine($"{DateTime.Now.ToString(@"yyyy-MM-ddThh-mm-ss")}: " + msg);
        }

        public void Info(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.Write("INFO ");
            Console.ForegroundColor = ConsoleColor.White;
            System.Console.WriteLine($"{DateTime.Now.ToString(@"yyyy-MM-ddThh-mm-ss")}: " + msg);
        }
    }
}