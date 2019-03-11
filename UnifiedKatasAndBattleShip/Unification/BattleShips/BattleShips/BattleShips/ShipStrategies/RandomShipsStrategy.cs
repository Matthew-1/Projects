using System;
using System.Collections.Generic;

namespace BattleShips
{
    public class RandomShipsStrategy : IShipStrategy
    {
        public List<int> GiveNumberOfMasts()
        {
            Random random = new Random();
            List<int> masts = new List<int>();

            int numberOfShips = random.Next(1, 11);

            for (int i = 0; i < numberOfShips; i++)
            {
                masts.Add(random.Next(1, 6));
            }

            return masts;
        }
    }
}