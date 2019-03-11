using System;
using System.Collections.Generic;

namespace BattleShips
{
    public class UserShipsStrategy : IShipStrategy
    {
        private int _numberOfShips;

        public UserShipsStrategy(int numberOfShips)
        {
            _numberOfShips = numberOfShips;
        }

        public List<int> GiveNumberOfMasts()
        {
            var masts = new List<int>();
            Random random = new Random();

            for (int i = 0; i < _numberOfShips; i++)
            {
                masts.Add(random.Next(1, 6));
            }

            return masts;
        }
    }
}