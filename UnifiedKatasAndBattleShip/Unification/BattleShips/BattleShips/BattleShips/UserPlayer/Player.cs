using BattleShips.GameElements;
using System;
using System.Collections.Generic;

namespace BattleShips
{
    public class Player
    {
        public string Name;
        public List<Ship> Ships = new List<Ship>();
        public Board BoardWithShips = new Board();
        public int AllMasts = 0;
        public Board BoardWithShootingState = new Board();

        public void AddShip(Ship ship) => Ships.Add(ship);
        public void AddShips(List<Ship> ship) => Ships=ship;

        public void LocateShip(Ship ship,int x_Coordinate,int y_Coordinate, int orientation)
        {
            int horizontal, vertical = 0;
            AllMasts += ship.GetNumberOfMasts();

            for (int i = 0; i < ship.GetNumberOfMasts(); i++)
            {
                if (orientation == 0)
                {
                    horizontal = i;
                    vertical = 0;
                }
                else
                {
                    horizontal = 0;
                    vertical = i;
                }

                BoardWithShips.BoardAllFields[ y_Coordinate + vertical, x_Coordinate + horizontal] = BoardField.Ship;
                
            }
        }
    }
}