using BattleShips.GameElements;
using System;
using System.Collections.Generic;

namespace BattleShips
{
    public class Board
    {
        public BoardField[,] BoardAllFields = new BoardField[10, 10];

        public Board()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    BoardAllFields[i,j] = BoardField.Avaible;
                }
            }
        }

    }
}