using System;
using System.Collections.Generic;

namespace BattleShips
{
    public static class ShipsFactory
    {
        public static void CreateShipsForGame(Game game)
        {
           List<int> numberOfMasts = game.GetShipsStrategy().GiveNumberOfMasts();

            foreach (var masts in numberOfMasts)
            {
                foreach (var player in game.GetPlayers())
                {
                    player.AddShip(new Ship(masts));
                }
            }
        }

        public static List<Ship> CreateManyShips(int numberOfShips,int numberOfMasts)
        {
            var ships = new List<Ship>();

            for (int i = 0; i < numberOfShips; i++)
            {
                ships.Add(CreateShip(numberOfMasts));
            }

            return ships;
        }

        public static Ship CreateShip(int numberOfMasts)
        {
            return new Ship(numberOfMasts);
        }
    }
}