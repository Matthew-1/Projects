using BattleShips.GameElements;
using BattleShips.UserPlayer;
using SharedTools;
using System;
using System.Threading;

namespace BattleShips
{
    public class UserCommunicatorConfig
    {
        private Game _game;
        private Displayer _displayer;
        private BoardDrawer _boardDrawer;
        private string _messageForUser;
        private IUserInput _getUserInput = new GetInput();

       
        public UserCommunicatorConfig(Game game)
        {
            _game = game;
            _displayer = new Displayer();
            _boardDrawer = new BoardDrawer();
        }

        public void AskForPlayerNames()
        {
            var players = _game.GetPlayers();

            for (int i = 0; i < _game.GetPlayers().Count; i++)
            {
                _messageForUser = $"What is Your name player {i+1}?";
                _displayer.CasualMsgForUser(_messageForUser);
                string name = _getUserInput.GetUserInput();

                if (name == "")
                    i--;
                else
                {
                    _messageForUser = $"Welcome in game {name}!";
                    _displayer.ConfirmativeMsgForUser(_messageForUser);
                    _game.SetPlayerName(name, i);
                }
            }

            Thread.Sleep(1000);
            _messageForUser = "Processing...";
            _displayer.ConfirmativeMsgForUser(_messageForUser);

            _boardDrawer.ClearConsole();
            
        }


        public void AskForShipStrategy()
        {
            

            bool correctGivenValue = false;

            do
            {
                _messageForUser = "What number of ships do You want to play with? Random (0)/ Your number(not more than 10):";
                _displayer.CasualMsgForUser(_messageForUser);

                int.TryParse(_getUserInput.GetUserInput(), out int numberOfShips);

                if (numberOfShips == 0)
                {
                    _game.SetShipsNumberStrategy(new RandomShipsStrategy());
                    correctGivenValue = true;
                }
                    
                else if (numberOfShips > 10 || numberOfShips < 0)
                {
                    _messageForUser = $"Incorrect number of ships '{numberOfShips}', try again.";
                    _displayer.ErrorMsgForUser(_messageForUser);
                    correctGivenValue = false;
                }

                else
                {
                    _game.SetShipsNumberStrategy(new UserShipsStrategy(numberOfShips));
                    correctGivenValue = true;
                }

            } while (correctGivenValue == false);
            
            _boardDrawer.ClearConsole();
        }

        public void AskForLocatingShips()
        {
            var players = _game.GetPlayers();

            for (int i = 0; i < players.Count; i++)
            {
                _messageForUser = $"{players[i].Name} set up Your ships on the board";
                _displayer.CasualMsgForUser(_messageForUser);

                SetShipsOnBoard(players[i]);   
            }

            _boardDrawer.ClearConsole();
        }

        private void SetShipsOnBoard(Player player, int validationPoint = 0)
        {

            for (int i = validationPoint; i < player.Ships.Count; i++)
            {
                _boardDrawer.ShowUserBoardWithShips(player.BoardWithShips);

                _messageForUser = $"{player.Name} set up ship with {player.Ships[i].GetNumberOfMasts()} masts.";
                _displayer.CasualMsgForUser(_messageForUser);

                _messageForUser = "Write accordingly: \nCoordinate X:";
                _displayer.CasualMsgForUser(_messageForUser);
                int.TryParse(_getUserInput.GetUserInput(), out int x_Coordinate);  

                _messageForUser = "Coordinate Y:";
                _displayer.CasualMsgForUser(_messageForUser);
                int.TryParse(_getUserInput.GetUserInput(), out int y_Coordinate); 

                _messageForUser = "Ship orientation 0 - horizontall, 1 - vertically:";
                _displayer.CasualMsgForUser(_messageForUser);
                int.TryParse(_getUserInput.GetUserInput(), out int orientation);

                if (ValidateUserInputForSettingShips(player, x_Coordinate, y_Coordinate, orientation, i))
                    i--;
                else
                {
                    player.LocateShip(player.Ships[i], x_Coordinate - 1, y_Coordinate - 1, orientation);
                }

               
            }

            _boardDrawer.ShowUserBoardWithShips(player.BoardWithShips);
            _messageForUser = "Processing...";
            _displayer.ConfirmativeMsgForUser(_messageForUser);
            Thread.Sleep(1300);
        }

        private bool ValidateUserInputForSettingShips(Player player, int x_Coordinate, int y_Coordinate, 
            int orientation, int validationPoint)
        {
            if (x_Coordinate > 10 || y_Coordinate > 10 || orientation > 1)
            {
                _messageForUser = "Wrong coordinates of ship or orientation. Try again.";
                _displayer.ErrorMsgForUser(_messageForUser);
                Thread.Sleep(1300);
                return true;
            }
                

            bool outOfBoard = false;
            bool onAnotherShip = false;

            switch(orientation)
            {
                case 0:
                    outOfBoard = ((x_Coordinate + player.Ships[validationPoint].GetNumberOfMasts()) > 10) ?
                        true : false;
                    break;

                case 1:
                    outOfBoard = ((y_Coordinate + player.Ships[validationPoint].GetNumberOfMasts()) > 10) ?
                        true : false;
                    break;
            }

            if (outOfBoard)
            {
                _messageForUser = "Ships is too long for chosen position. Change coordinates or orientation.";
                _displayer.ErrorMsgForUser(_messageForUser);
                Thread.Sleep(1300);
                return true;
            }

            onAnotherShip = ShipSetOnAnotherShip(player, x_Coordinate, y_Coordinate, orientation,
                        player.Ships[validationPoint].GetNumberOfMasts());

            if (onAnotherShip)
            {
                _messageForUser = "Ships can not be set on another ship. Try again.";
                _displayer.ErrorMsgForUser(_messageForUser);
                Thread.Sleep(1300);
                return true;
            }

            return false;
        }

        private bool ShipSetOnAnotherShip(Player player, int x_Coordinate, int y_Coordinate,
            int orientation, int numberOfMasts)
        {
            int horizontal, vertical = 0;

            for (int i = 0; i < numberOfMasts; i++)
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

                if (player.BoardWithShips.BoardAllFields[ y_Coordinate-1+vertical, x_Coordinate-1 + horizontal] == BoardField.Ship)
                    return true;
            }

            return false;
        }
    }
}