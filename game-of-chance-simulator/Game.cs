using System;

namespace GameOfChanceSimulator
{
    class Game
    {
        Nation n1;
        Nation n2;
        Random Random;
        public Game()
        {
            n1 = new Nation("Swadia");
            n2 = new Nation("Rhodok");
            Random = new Random();
        }

        public attack(Nation n)

        public void Start()
        {
            if (Random.Next(0, 2) == 0)
            {
                System.Console.WriteLine($"{n1.Name} is about to strike!");
            }
            else
            {
                System.Console.WriteLine($"{n2.Name} is about to strike!");
            }
            while (CheckAlive)
            {

            }
        }

        bool CheckAlive()
        {
            for (int i = 0; i < n1.Troops.Length; i++)
            {
                if (n1.Troops[i].Health > 0)
                {
                    return true;
                }
            }
            for (int i = 0; i < n2.Troops.Length; i++)
            {
                if (n2.Troops[i].Health > 0)
                {
                    return true;
                }
            }
        }
    }
}
