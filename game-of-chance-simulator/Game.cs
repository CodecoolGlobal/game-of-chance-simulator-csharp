using System;
using System.IO;

namespace GameOfChanceSimulator
{
    class Game
    {
        public Nation[] nationsCollection { get; private set; }
        Random rand = new Random();

        public Game()
        {
            nationsCollection = new Nation[6];

            nationsCollection[0] = new Nation("Swadia", "Health");
            nationsCollection[1] = new Nation("Rhodok", "");
            nationsCollection[2] = new Nation("Nord", "Attack");
            nationsCollection[3] = new Nation("Khergit", "Attack");
            nationsCollection[4] = new Nation("Sarranid", "Health");
            nationsCollection[5] = new Nation("Vaegir", "");
        }

        public string Start()
        {
            int turnCounter = 0;

            int attackingNationIndex = rand.Next(0, nationsCollection.Length);      //random starting
            int defendingNationIndex = rand.Next(0, nationsCollection.Length);

            while (attackingNationIndex == defendingNationIndex)
            {
                defendingNationIndex = rand.Next(0, nationsCollection.Length);
            }

            //bool running = true;
            int[] aliveInNations = new int[nationsCollection.Length];

            int[] defendersPreviousHealth = new int[nationsCollection[0].Troops.Length];

            while (true/*running*/)
            {
                turnCounter++;
                for (int count = 0; count < nationsCollection[attackingNationIndex].Troops.Length; count++)
                {
                    int toAttackIndex = rand.Next(0, nationsCollection[defendingNationIndex].Troops.Length);

                    int dead = 0;

                    while (nationsCollection[defendingNationIndex].Troops[toAttackIndex].Health <= 0)
                    {
                        toAttackIndex = rand.Next(0, nationsCollection[defendingNationIndex].Troops.Length);
                        dead++;
                        if (dead == nationsCollection[defendingNationIndex].Troops.Length)
                        {
                            break;
                        }
                    }

                    defendersPreviousHealth[toAttackIndex] = nationsCollection[defendingNationIndex].Troops[toAttackIndex].Health;

                    for (int i = 0; i < defendersPreviousHealth.Length; i++)
                    {
                        if (defendersPreviousHealth[i] == 0)
                        {
                            defendersPreviousHealth[i] = nationsCollection[defendingNationIndex].Troops[i].Health;
                        }
                    }

                    nationsCollection[attackingNationIndex].Troops[count].Attack(nationsCollection[defendingNationIndex].Troops[toAttackIndex], nationsCollection[attackingNationIndex].Troops[count]);




                    /*Console.WriteLine("{0} {1} attacked {2} {3} with {4} damage.", nationsCollection[attackingNationIndex].Name,
                        nationsCollection[attackingNationIndex].Troops[count].GetType().Name, nationsCollection[defendingNationIndex].Name,
                        nationsCollection[defendingNationIndex].Troops[toAttackIndex].GetType().Name, nationsCollection[attackingNationIndex].Troops[count].DealtDamage);*/
                }


                /*Console.WriteLine("\n[{0}]. turn result:\n", turnCounter);
                for (int count = 0; count < nationsCollection[attackingNationIndex].Troops.Length; count++)
                {
                    Console.WriteLine("{0}'s troops:\n\t\t\n\t\t{1} with {2} hp", nationsCollection[attackingNationIndex].Name,
                        nationsCollection[attackingNationIndex].Troops[count].GetType().Name,nationsCollection[attackingNationIndex].Troops[count].Health);
                }

                Console.WriteLine("\n-------------------------------------------------\n-------------------------------------------------\n");

                for (int count = 0; count < nationsCollection[defendingNationIndex].Troops.Length; count++)
                {
                    Console.WriteLine("{0}'s troops:\n\t\t\n\t\t{1} with {2} -> {3} hp", nationsCollection[defendingNationIndex].Name,
                        nationsCollection[defendingNationIndex].Troops[count].GetType().Name, defendersPreviousHealth[count], nationsCollection[defendingNationIndex].Troops[count].Health);
                    defendersPreviousHealth[count] = nationsCollection[defendingNationIndex].Troops[count].Health;
                }
                Console.WriteLine();*/

                int alive;

                for (int count = 0; count < nationsCollection.Length; count++)
                {
                    alive = 0;
                    for (int troopIndex = 0; troopIndex < nationsCollection[count].Troops.Length; troopIndex++)
                    {
                        if (nationsCollection[count].Troops[troopIndex].Health > 0)
                        {
                            alive++;
                        }
                    }

                    //if (alive == 0)
                    //{
                    //    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n{0} is destroyed.\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~", nationsCollection[count].Name);
                    //}
                    aliveInNations[count] = alive;
                }

                alive = 0;
                for (int count = 0; count < aliveInNations.Length; count++)
                {
                    if (aliveInNations[count] > 0)
                    {
                        alive++;
                    }
                }

                if (alive == 1)
                {
                    for (int count = 0; count < aliveInNations.Length; count++)
                    {
                        if (aliveInNations[count] > 0)
                        {
                            //Console.WriteLine("\n/                  \\\n{0} has won!!!!!!\n\\                  /", nationsCollection[count].Name);
                            return nationsCollection[count].Name;
                            //running = false;
                            //break;
                        }
                    }
                }

                else
                {
                    attackingNationIndex = defendingNationIndex;
                    while (aliveInNations[attackingNationIndex] == 0)
                    {
                        attackingNationIndex = rand.Next(0, nationsCollection.Length);
                    }

                    defendingNationIndex = rand.Next(0, nationsCollection.Length);

                    while (defendingNationIndex == attackingNationIndex || aliveInNations[defendingNationIndex] == 0)
                    {
                        defendingNationIndex = rand.Next(0, nationsCollection.Length);
                    }
                }
            }
        }
    }
}
