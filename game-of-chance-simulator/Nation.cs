using System.Collections.Generic;

namespace GameOfChanceSimulator
{
    class Nation
    {
        public Troop[] Troops;
        public string Name { get; set; }
        public Nation(string name)
        {
            Name = name;
            Init();
        }

        void Init()
        {
            Troops = new Troop[5];
            Troops[0] = new Archer();
            Troops[1] = new Archer();
            Troops[2] = new Cavalry();
            Troops[3] = new Footman();
            Troops[4] = new Footman();
        }
    }
}
