using System;

namespace GameOfChanceSimulator
{
    class Game
    {
        Nation n1;
        Nation n2;
        Random Random;
        bool GameOver = false;

        /*public Game()
        {
            n1 = new Nation("Swadia");
            n2 = new Nation("Rhodok");

            Nation[] nationsCollection = new Nation[2];
            nationsCollection[0] = n1;
            nationsCollection[1] = n2;

            Random = new Random();
        }*/

        public void Start()
        {
            int turnCounter = 0;

            n1 = new Nation("Swadia");
            n2 = new Nation("Rhodok");

            Nation[] nationsCollection = new Nation[2];
            nationsCollection[0] = n1;
            nationsCollection[1] = n2;

            Random rand = new Random();

            int attackingNationIndex = rand.Next(0, nationsCollection.Length);      //random starting
            int defendingNationIndex = rand.Next(0, nationsCollection.Length);

            int troopToAttack;

            while (defendingNationIndex == attackingNationIndex)   //not to attack themselves
            {
                defendingNationIndex = rand.Next(0, nationsCollection.Length);
            }

            System.Console.WriteLine($"{nationsCollection[attackingNationIndex].Name} is about to strike first!");

            while (!GameOver)
            {
                turnCounter++;
                Console.WriteLine("\n\tStarting point:");
                PrintBattleStatus(turnCounter, nationsCollection[attackingNationIndex], nationsCollection[defendingNationIndex]);


                //BATTLE LOGIC
                for (int i = 0; i < nationsCollection[attackingNationIndex].Troops.Length; i++)
                {
                    if (nationsCollection[attackingNationIndex].Troops[i].Health > 0)
                    {
                        do
                        {
                            troopToAttack = rand.Next(0, nationsCollection[defendingNationIndex].Troops.Length);
                        }
                        while (CheckTroopAlive(nationsCollection[defendingNationIndex].Troops[troopToAttack]));



                        nationsCollection[attackingNationIndex].Troops[i].Attack(nationsCollection[defendingNationIndex].Troops[troopToAttack]);
                        System.Console.WriteLine("{0} {1} attacked {2} {3} and dealt {4} damage.", nationsCollection[attackingNationIndex].Name, nationsCollection[attackingNationIndex].Troops[i].GetType().Name, nationsCollection[defendingNationIndex].Name, nationsCollection[defendingNationIndex].Troops[troopToAttack].GetType().Name, nationsCollection[attackingNationIndex].Troops[i].MinDamage);
                    }


                    if (CheckNationAlive(nationsCollection[defendingNationIndex]))
                    {
                        System.Console.WriteLine("{0} won! $$$$$$$", nationsCollection[attackingNationIndex].Name);
                        PrintBattleStatus(turnCounter, nationsCollection[attackingNationIndex], nationsCollection[defendingNationIndex]);
                        GameOver = true;
                        break;
                    }
                }
                PrintBattleStatus(turnCounter, nationsCollection[attackingNationIndex], nationsCollection[defendingNationIndex]);



                //defender attack now
                Console.WriteLine("\n\n/-/-/-/-/-/-/-/-/-/");
                Console.WriteLine("{0}'s turn now!\n", nationsCollection[defendingNationIndex].Name);

                attackingNationIndex = defendingNationIndex;
                defendingNationIndex = rand.Next(0, nationsCollection.Length);

                while (defendingNationIndex == attackingNationIndex)   //not to attack themselves
                {
                    defendingNationIndex = rand.Next(0, nationsCollection.Length);
                }



                for (int i = 0; i < nationsCollection[attackingNationIndex].Troops.Length; i++)
                {
                    if (nationsCollection[attackingNationIndex].Troops[i].Health > 0)
                    {
                        do
                        {
                            troopToAttack = rand.Next(0, nationsCollection[defendingNationIndex].Troops.Length);
                        }
                        while (CheckTroopAlive(nationsCollection[defendingNationIndex].Troops[troopToAttack])); //attack from the attacked one


                        nationsCollection[attackingNationIndex].Troops[i].Attack(nationsCollection[defendingNationIndex].Troops[troopToAttack]);
                        System.Console.WriteLine("{0} {1} attacked {2} {3} and dealt {4} damage.", nationsCollection[attackingNationIndex].Name, nationsCollection[attackingNationIndex].Troops[i].GetType().Name, nationsCollection[defendingNationIndex].Name, nationsCollection[defendingNationIndex].Troops[troopToAttack].GetType().Name, nationsCollection[attackingNationIndex].Troops[i].MinDamage);
                    }



                    if (CheckNationAlive(nationsCollection[defendingNationIndex]))
                    {
                        System.Console.WriteLine("{0} won! $$$$$$$", nationsCollection[attackingNationIndex].Name);
                        PrintBattleStatus(turnCounter, nationsCollection[attackingNationIndex], nationsCollection[defendingNationIndex]);
                        GameOver = true;
                        break;
                    }
                }


                attackingNationIndex = defendingNationIndex;
                defendingNationIndex = rand.Next(0, nationsCollection.Length);


                while (defendingNationIndex == attackingNationIndex)   //not to attack themselves
                {
                    defendingNationIndex = rand.Next(0, nationsCollection.Length);
                }

            }



            /*if (Random.Next(0, 2) == 0)     //Determine who's first
            {
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
                            System.Console.WriteLine("{0} won! $$$$$$$", n1.Name);
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
                            System.Console.WriteLine("{0} won! $$$$$$$", n2.Name);
                            PrintBattleStatus(turnCounter);
                            GameOver = true;
                            break;
                        }
                    }
                }
            }
            else
            {
                System.Console.WriteLine($"{n2.Name} is about to strike first!");
                for (int i = 0; i < 2; i++)
                {

                }
            }
            */



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

            void PrintBattleStatus(int turnCounter, Nation attacking, Nation defending)
            {
                //BATTLE STATUS
                System.Console.WriteLine("------------------------------------");
                System.Console.WriteLine("[{0}. Turn] Battle status: {1} vs {2}", turnCounter, attacking.Name, defending.Name);
                System.Console.WriteLine("------------------------------------");

                System.Console.WriteLine("{0} troops:", attacking.Name);
                foreach (Troop troop in attacking.Troops)
                {
                    System.Console.WriteLine("\t{0}:", troop.GetType().Name);
                    System.Console.WriteLine("\t\t- HP: {0}", troop.Health);
                }

                System.Console.WriteLine("\n{0} troops:", defending.Name);
                foreach (Troop troop in defending.Troops)
                {
                    System.Console.WriteLine("\t{0}:", troop.GetType().Name);
                    System.Console.WriteLine("\t\t- HP: {0}", troop.Health);
                }
                //BATTLE STATUS
            }
        }
    }
}
