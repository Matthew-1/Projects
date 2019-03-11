using BattleShips.GameElements;
using System;
using System.Threading;

namespace BattleShips
{
    internal class BoardDrawer
    {

        internal void WriteMessageForUser(string messageForUser)
        {
            Console.WriteLine();
            Console.WriteLine(messageForUser);
            Console.WriteLine();
        }

        internal void ShowUserBoardWithShips(Board boardWithShips)
        {
            ClearConsole();
            ShowBoard(boardWithShips);
        }

        internal void ShowUserBoardWithShootingState(Board boardWithShootingState)
        {
            ShowBoard(boardWithShootingState);
        }

        internal void ClearConsole()
        {
            Console.Clear();
        }

        private void ShowBoard(Board board)
        {
            DrawColumnNumeration();

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (j == 0)
                    {
                        DrawRowNumeration(i + 1);
                        DrawFields(board, i, j);
                    }
                    else
                        DrawFields(board, i, j);
                }
                Console.WriteLine();
            }
        }

        private void DrawFields(Board board, int i, int j)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("| ");

            var field = board.BoardAllFields[i, j];

            switch (field)
            {
                case BoardField.Miss:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;

                case BoardField.Hit:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;

                case BoardField.Ship:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;

            }

            Console.Write($"{(char)field}");

            Console.ForegroundColor = ConsoleColor.Cyan;
            if (j == 9)
                Console.Write(" |");
            else
                Console.Write(" ");

            Console.ResetColor();
        }

        internal void ShowResultsAfterShooting(Board boardWithShootingState)
        {
            ShowUserBoardWithShootingState(boardWithShootingState);
            WriteMessageForUser("Processing...");
            Thread.Sleep(2000);
        }

        private void DrawRowNumeration(int rowNumber)
        {
            if (rowNumber == 10)
                Console.Write($"  {rowNumber} ");
            else
                Console.Write($"  {rowNumber}  ");
        }

        private void DrawColumnNumeration()
        {
            Console.Write("       ");
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"{i + 1}   ");
            }

            Console.WriteLine();
        }
    }
}