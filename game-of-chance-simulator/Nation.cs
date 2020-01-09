using System.Collections.Generic;

namespace GameOfChanceSimulator
{
    class Nation
    {
        public Troop[] Troops;
        public string Name { get; set; }
        public string Bonus { get; set; }
        public Nation(string name,string bonus)
        {
            Name = name;
            Bonus = bonus;
            Init();
        }

        void Init()
        {
            Troops = new Troop[5];
            Troops[0] = new Archer(5);
            Troops[1] = new Archer(5);
            Troops[2] = new Cavalry();
            Troops[3] = new Footman();
            Troops[4] = new Footman();
            FratctionBonus(Troops);
        }

        void FratctionBonus(Troop[] troopList)
        {
            for(int count=0;count<troopList.Length;count++)
            {
                troopList[count].AddBonus(troopList[count], Bonus);
            }
        }

    }
}
