using System;

namespace GameOfChanceSimulator
{
    class Game
    {
        Nation n1;
        Nation n2;
        Random Random;
        bool GameOver = false;
        public Game()
        {
            n1 = new Nation("Swadia");
            n2 = new Nation("Rhodok");
            Random = new Random();
        }

        public void Start()
        {
            if (Random.Next(0, 2) == 0)     //Determine who's first
            {
                N1StrikesFirst();
            }
            else
            {
                System.Console.WriteLine($"{n2.Name} is about to strike first!");
                for (int i = 0; i < 2; i++)
                {

                }
            }
        }

        bool CheckTroopAlive(Troop troop)
        {
            if (troop.Health <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        bool CheckNationAlive(Nation nation)
        {
            int deadCount = 0;
            foreach (Troop troop in nation.Troops)
            {
                if (troop.Health == 0)
                {
                    deadCount++;
                }
            }
            if (deadCount == nation.Troops.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        void PrintVictory(Nation nation)
        {
            System.Console.WriteLine("{0} won! $$$$$$$", nation.Name);
        }

        void PrintBattleStatus(int turnCounter)
        {
            //BATTLE STATUS
            System.Console.WriteLine("------------------------------------");
            System.Console.WriteLine("[{0}. Turn] Battle status: {1} vs {2}", turnCounter, n1.Name, n2.Name);
            System.Console.WriteLine("------------------------------------");

            System.Console.WriteLine("{0} troops:", n1.Name);
            foreach (Troop troop in n1.Troops)
            {
                System.Console.WriteLine("\t{0}:", troop.GetType().Name, n1.Name);
                System.Console.WriteLine("\t\t- HP: {0}", troop.Health);
            }

            System.Console.WriteLine("\n{0} troops:", n2.Name);
            foreach (Troop troop in n2.Troops)
            {
                System.Console.WriteLine("\t{0}:", troop.GetType().Name, n2.Name);
                System.Console.WriteLine("\t\t- HP: {0}", troop.Health);
            }
            //BATTLE STATUS
        }

        void N1StrikesFirst()
        {
            int turnCounter = 0;

            System.Console.WriteLine($"{n1.Name} is about to strike first!");
            while (!GameOver)   //Game Loop
            {
                turnCounter++;
                PrintBattleStatus(turnCounter);
                //BATTLE LOGIC
                for (int i = 0; i < n1.Troops.Length; i++)
                {
                    int troopToAttack;
                    if (n1.Troops[i].Health > 0)
                    {
                        do
                        {
                            troopToAttack = Random.Next(0, n2.Troops.Length);
                        }
                        while (CheckTroopAlive(n2.Troops[troopToAttack]));
                        n1.Troops[i].Attack(n2.Troops[troopToAttack]);
                        System.Console.WriteLine("{0}n {1} attacked {2} {3} and dealt {4} damage.", n1.Name, n1.Troops[i].GetType().Name, n2.Name, n2.Troops[troopToAttack].GetType().Name, n1.Troops[i].MinDamage);
                    }
                    if (CheckNationAlive(n2))
                    {
                        PrintVictory(n1);
                        PrintBattleStatus(turnCounter);
                        GameOver = true;
                        break;
                    }
                    if (n2.Troops[i].Health > 0)
                    {
                        do
                        {
                            troopToAttack = Random.Next(0, n1.Troops.Length);
                        }
                        while (CheckTroopAlive(n1.Troops[troopToAttack]));
                        n2.Troops[i].Attack(n1.Troops[troopToAttack]);
                        System.Console.WriteLine("{0} {1} attacked {2}n {3} and dealt {4} damage.", n2.Troops[i].GetType().Name, n2.Name, n1.Name, n1.Troops[troopToAttack].GetType().Name, n2.Troops[i].MinDamage);
                    }
                    if (CheckNationAlive(n1))
                    {
                        PrintVictory(n2);
                        PrintBattleStatus(turnCounter);
                        GameOver = true;
                        break;
                    }
                }
            }
        }
    }
}