using System.Collections.Generic;

namespace GameOfChanceSimulator
{
    class Nation
    {
        Troop[] Troops;
        public Nation(string name)
        {
            Troops = new Troop[5];
        }
    }
}
