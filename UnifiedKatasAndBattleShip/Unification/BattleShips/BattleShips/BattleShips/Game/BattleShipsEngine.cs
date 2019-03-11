using BattleShips.GameElements;
using BattleShips.UserPlayer;
using System;
using System.Threading;

namespace BattleShips
{
    public class BattleShipsEngine
    {
        private Config _config;
        private Game _game;
        private UserCommunicatorGameEngine _userCommunicator;
        private BoardDrawer _displayer;
        private Player _player_1;
        private Player _player_2;

        public void StartApp()
        {
            _config = new Config();
            _game = _config.SetUpGame();
            _userCommunicator = new UserCommunicatorGameEngine(_game);
            _displayer = new BoardDrawer();

            _player_1 = _game.GetPlayers()[0];
            _player_2 = _game.GetPlayers()[1];

            PerformShooting();

        }


        private void PerformShooting()
        {
            bool gameIsOver = false;

            do
            {
                Player shootingPlayer = _player_1;
                Player enemyPlayer = _player_2;

                _displayer.ShowUserBoardWithShootingState(shootingPlayer.BoardWithShootingState);
                int[] shootedField = _userCommunicator.AskPlayersForShooting(shootingPlayer);

                if (CheckIfHit(shootedField, enemyPlayer))
                {
                    enemyPlayer.AllMasts--;
                    shootingPlayer.BoardWithShootingState.BoardAllFields[shootedField[1] - 1, shootedField[0] - 1] = BoardField.Hit;
                    _displayer.ShowResultsAfterShooting(shootingPlayer.BoardWithShootingState);

                    gameIsOver = CheckWinningConditionsAndAnnounceWinner(shootingPlayer, enemyPlayer);
                    
                    if(!gameIsOver)
                        _displayer.ClearConsole(); 
                    
                }
                else if (!gameIsOver)
                {
                    shootingPlayer.BoardWithShootingState.BoardAllFields[shootedField[1] - 1, shootedField[0] - 1] = BoardField.Miss;
                    _displayer.ShowResultsAfterShooting(shootingPlayer.BoardWithShootingState);
                    _displayer.ClearConsole();
                    SwapPlayers();
                }

            } while (gameIsOver == false);
            

        }

        private void SwapPlayers()
        {
            var tmpPlayer = _player_1;
            _player_1 = _player_2;
            _player_2 = tmpPlayer;
        }

        private bool CheckWinningConditionsAndAnnounceWinner(Player shootingPlayer, Player enemyPlayer)
        {
            if (enemyPlayer.AllMasts <1)
            {
                _userCommunicator.AnnounceWinner(shootingPlayer);
                return true;
            }

            return false;
        }

        private bool CheckIfHit(int[] shootedField, Player enemyPlayer)
        {
            if (enemyPlayer.BoardWithShips.BoardAllFields[shootedField[1]-1, shootedField[0]-1] == BoardField.Ship)
                return true;
            else
                return false;
            
        }
    }
}