using System;

namespace GameOfChanceSimulator
{
    class Game
    {
        Nation[] nations;
        Random Random;
        bool GameOver = false;
        //STATS
        string Winner;
        int Casualties;
        bool FlawlessVictory;
        bool ShouldPrint;
        public Game()
        {
            Init();
        }

        void Init()
        {
            nations = new Nation[2];
            nations[0] = new Nation("Swadia");
            nations[1] = new Nation("Rhodok");
            Winner = "TBA";
            Casualties = 0;
            FlawlessVictory = false;
            Random = new Random();
        }

        public string Start()
        {
            int firstToStrike = Random.Next(0, 2);
            if (firstToStrike == 0)     //Determine who's first
            {
                MakeBattle(nations[0], nations[1]);
            }
            else
            {
                MakeBattle(nations[1], nations[0]);
            }
            return Winner;
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
                if (troop.IsDead())
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
            Winner = nation.Name;
            foreach (Troop troop in nation.Troops)
            {
                if (troop.IsDead())
                {
                    Casualties++;
                }
            }

            if (Casualties == 0)
            {
                FlawlessVictory = true;
            }
            if (FlawlessVictory)
            {
                //System.Console.WriteLine("------------------------------------{0} won the battle without casualties!------------------------------------", nation.Name);
            }
            {
                //System.Console.WriteLine("------------------------------------{0} won the battle!------------------------------------", nation.Name);
            }
            //System.Console.WriteLine("{0}'s casualties: {1}", nation.Name, Casualties);
        }

        void PrintBattleStatus(int turnCounter)
        {
            //BATTLE STATUS
            /* System.Console.WriteLine("------------------------------------");
            System.Console.WriteLine("[{0}. Turn] Battle status: {1} vs {2}", turnCounter, nations[0].Name, nations[1].Name);
            System.Console.WriteLine("------------------------------------"); */

            foreach (var nation in nations)
            {
                //System.Console.WriteLine("{0}'s troops:", nation.Name);
                foreach (Troop troop in nation.Troops)
                {
                    /* System.Console.WriteLine("\t{0}:", troop.GetType().Name, nation.Name);
                    System.Console.WriteLine("\t\t- HP: {0}", troop.Health); */
                }
            }
            //BATTLE STATUS
        }

        void MakeBattle(Nation attackingNation, Nation defendingNation)
        {
            int turnCounter = 0;

            //System.Console.WriteLine($"{attackingNation.Name} is about to strike first!");

            while (!GameOver)   //Game Loop
            {
                turnCounter++;
                if (ShouldPrint)
                    PrintBattleStatus(turnCounter);
                //BATTLE LOGIC
                for (int i = 0; i < attackingNation.Troops.Length; i++)
                {
                    int troopToAttack;
                    if (!attackingNation.Troops[i].IsDead())
                    {
                        do
                        {
                            troopToAttack = Random.Next(0, defendingNation.Troops.Length);
                        }
                        while (defendingNation.Troops[troopToAttack].IsDead());
                        int damage = attackingNation.Troops[i].Attack(defendingNation.Troops[troopToAttack]);
                        if (attackingNation.Name == "Swadia")
                        {
                            //System.Console.WriteLine("{0}n {1} attacked {2} {3} and dealt {4} damage.", attackingNation.Name, attackingNation.Troops[i].GetType().Name, defendingNation.Name, defendingNation.Troops[troopToAttack].GetType().Name, damage);
                        }
                        else
                        {
                            //System.Console.WriteLine("{0} {1} attacked {2}n {3} and dealt {4} damage.", attackingNation.Name, attackingNation.Troops[i].GetType().Name, defendingNation.Name, defendingNation.Troops[troopToAttack].GetType().Name, damage);
                        }
                    }
                    if (CheckNationAlive(defendingNation))
                    {
                        PrintVictory(attackingNation);
                        PrintBattleStatus(turnCounter);
                        GameOver = true;
                        break;
                    }
                    if (!defendingNation.Troops[i].IsDead())
                    {
                        do
                        {
                            troopToAttack = Random.Next(0, attackingNation.Troops.Length);
                        }
                        while (attackingNation.Troops[troopToAttack].IsDead());
                        int damage = defendingNation.Troops[i].Attack(attackingNation.Troops[troopToAttack]);
                        if (defendingNation.Name == "Rhodok")
                        {
                            //System.Console.WriteLine("{0} {1} attacked {2}n {3} and dealt {4} damage.", defendingNation.Name, defendingNation.Troops[i].GetType().Name, attackingNation.Name, attackingNation.Troops[troopToAttack].GetType().Name, damage);
                        }
                        else
                        {
                            //System.Console.WriteLine("{0}n {1} attacked {2} {3} and dealt {4} damage.", defendingNation.Name, defendingNation.Troops[i].GetType().Name, attackingNation.Name, attackingNation.Troops[troopToAttack].GetType().Name, damage);
                        }
                    }
                    if (CheckNationAlive(attackingNation))
                    {
                        PrintVictory(defendingNation);
                        PrintBattleStatus(turnCounter);
                        GameOver = true;
                        break;
                    }
                }
            }
        }
    }
}