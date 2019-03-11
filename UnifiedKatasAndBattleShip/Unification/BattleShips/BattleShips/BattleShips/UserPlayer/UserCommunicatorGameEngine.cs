using BattleShips.GameElements;
using SharedTools;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BattleShips.UserPlayer
{
    public class UserCommunicatorGameEngine
    {
        private Game _game;
        private Displayer _displayer;
        private BoardDrawer _boardDrawer;
        private string _messageForUser;
        private IUserInput _getUserInput = new GetInput();

        public UserCommunicatorGameEngine(Game game)
        {
            _displayer = new Displayer();
            _boardDrawer = new BoardDrawer();
            _game = game;
        }

        public int[] AskPlayersForShooting(Player player)
        {
            int[] shootedField = new int[2];
            bool shootedCorrectly = false;

            do
            {
                _messageForUser = $"{player.Name} shoot Your enemy - write X coordinate/Show board with Your ships - write 's':";
                _displayer.CasualMsgForUser(_messageForUser);
                bool shoot = int.TryParse(_getUserInput.GetUserInput(), out shootedField[0]);

                if (shoot == false)
                {
                    OwnBoardShowingMode(player);
                }
                else if (shoot)
                {
                    _messageForUser = "Shoot Your enemy - write Y coordinate:";
                    _displayer.CasualMsgForUser(_messageForUser);
                    int.TryParse(_getUserInput.GetUserInput(), out shootedField[1]);
                    shootedCorrectly = ValidateShootingCoordinates(player, shootedField);
                }   

            } while (shootedCorrectly == false);
            

            _boardDrawer.ClearConsole();

            return shootedField;

        }

        private bool ValidateShootingCoordinates(Player player, int[] shootedField)
        {
            for (int i = 0; i < shootedField.Length; i++)
            {
                if (shootedField[i] < 1 || shootedField[i] > 10)
                {
                    _messageForUser = "Wrong coordinates - try again.";
                    _displayer.ErrorMsgForUser(_messageForUser);
                    return false;
                }
            }
            int y_Coordinate = shootedField[1] - 1;
            int x_Coordinate = shootedField[0] - 1;

            if (player.BoardWithShootingState.BoardAllFields[y_Coordinate, x_Coordinate] == BoardField.Miss
                || player.BoardWithShootingState.BoardAllFields[y_Coordinate, x_Coordinate] == BoardField.Hit)
            {
                _messageForUser = "You have already shooted there. Try to shoot empty field.";
                _displayer.ErrorMsgForUser(_messageForUser);
                return false;
            }

            return true;

        }

        public void AnnounceWinner(Player shootingPlayer)
        {
            _messageForUser = $"Congratulation! {shootingPlayer.Name} wins the battle!";
            _displayer.ConfirmativeMsgForUser(_messageForUser);

            Thread.Sleep(1300);
        }

        private void OwnBoardShowingMode(Player player)
        {
            string userAnswer = "";
            do
            {
                _boardDrawer.ShowUserBoardWithShips(player.BoardWithShips);
                _messageForUser = "Get back to shooting - write 'e'";
                _displayer.CasualMsgForUser(_messageForUser);
                userAnswer = _getUserInput.GetUserInput();
                _boardDrawer.ClearConsole();

            } while (userAnswer != "e");
            
            _boardDrawer.ShowUserBoardWithShootingState(player.BoardWithShootingState);

        }
    }
}
