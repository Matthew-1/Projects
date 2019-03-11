using SharedTools;
using System;
using System.Collections.Generic;
using System.Text;
using Unification.DataTools;

namespace Unification
{
    public class UserNeedsManager
    {
        private Displayer _displayer;
        private UserDataHarvester _userData;
        private ApplicationsManager _appManager;
        private List<string> _userValuesForApp;
        private IDataVerifier _dataVerifier;
        private string _messageToUser;
        private string _userAnswer;
        private int _userChoiceOfApp;

        public UserNeedsManager()
        {
            _displayer = new Displayer();
            _userData = new UserDataHarvester();
            _appManager = new ApplicationsManager();
            _userValuesForApp = new List<string>();
        }

        public bool PlayGamesEntryPoint(bool firstGreeting = true)
        {
            _displayer.ClearConsole();
            _dataVerifier = new ChoosingAppDataVerifierStrategy();
            bool correctUserData = false;

            if (firstGreeting)
            {
                _messageToUser = "Hello";
                _displayer.CasualMsgForUser(_messageToUser);
                _messageToUser = "Welcome in Unification project which unites two kata tasks and battle ships game as far.\n" +
                    "Anagrams kata is supposed to search an anagram from built-in word list.\n" +
                    "Diversion converts number to binary value and checks whether there are adjecent 1 in each chain.\n" +
                    "User decides about length of the chains. \n" +
                    "Katas are taken from https://github.com/gamontal/awesome-katas";
                _displayer.CasualMsgForUser(_messageToUser);
            }

            do
            {
                _messageToUser = "What operation would you like to carry out?\n" +
                               "Find an anagram (1), find binary chains (2), " + 
                               "play battle ships (3), exit (e)";

                _displayer.CasualMsgForUser(_messageToUser);
                 _userAnswer = _userData.GetDataFromUser();

                if (_userAnswer == "e")
                {
                    _messageToUser = "Thank You for using my app. Press any key to close the console";
                    _displayer.ConfirmativeMsgForUser(_messageToUser);
                    return false;
                }

                correctUserData = _dataVerifier.VerifyUserData(_userAnswer);

            } while (correctUserData==false);

            _userChoiceOfApp = _dataVerifier.GetUserVerifiedChoice<int>();
            switch (_userChoiceOfApp)
            {
                case 1:
                    AnagramsAssistent();
                    break;
                case 2:
                    DiversionAssistent();
                    break;
                case 3:
                    BattleShipAssistent();
                    break;
            }

            return true;

        }

        private void BattleShipAssistent()
        {
            _messageToUser = "You have chosen to play battle ships. Good luck!";
            _displayer.ConfirmativeMsgForUser(_messageToUser);
            _dataVerifier = new BattleShipsDataVerifierStrategy();
            bool playGame = true;
            do
            {
                if(playGame)
                {
                    _appManager.StartApplicationForUser(3, null);
                    _displayer.ClearConsole();
                    _messageToUser = "Nice battle!";
                    _displayer.ConfirmativeMsgForUser(_messageToUser);
                }
                
                _messageToUser = "Would You like to play again? Yes (y), next time (n)";
                _displayer.ConfirmativeMsgForUser(_messageToUser);
                _userAnswer = _userData.GetDataFromUser();
                playGame = _dataVerifier.VerifyUserData(_userAnswer);


            } while (_dataVerifier.GetUserVerifiedChoice<string>() != "n");

        }

        private void AnagramsAssistent()
        {

            _messageToUser = "You have chosen anagrams.";
            _displayer.ConfirmativeMsgForUser(_messageToUser);

            do
            {
                _messageToUser = "Type a word to search for anagrams or exit (e):";
                _displayer.CasualMsgForUser(_messageToUser);
                _userAnswer = _userData.GetDataFromUser();
                _userValuesForApp.Add(_userAnswer);

                _appManager.StartApplicationForUser(_userChoiceOfApp, _userValuesForApp);
                _userValuesForApp.Clear();

            } while (_userAnswer !="e");
            
        }

        private void DiversionAssistent()
        {
            _dataVerifier = new DiversionUserDataVerifierStrategy();
            _messageToUser = "You have chosen diversion.";
            _displayer.ConfirmativeMsgForUser(_messageToUser);
            bool correctUserValue = false;

            do
            {
                _messageToUser = "Type number to check or exit (e):";
                _displayer.CasualMsgForUser(_messageToUser);
                _userAnswer = _userData.GetDataFromUser();
                correctUserValue = _dataVerifier.VerifyUserData(_userAnswer);

                if(correctUserValue)
                {
                    _userValuesForApp.Add(_userAnswer);
                    _messageToUser = "Type number of digits in chain or exit (e):";
                    _displayer.CasualMsgForUser(_messageToUser);
                    _userAnswer = _userData.GetDataFromUser();
                    correctUserValue = _dataVerifier.VerifyUserData(_userAnswer);
                }
                
                if(correctUserValue)
                {
                    _userValuesForApp.Add(_userAnswer);
                    _appManager.StartApplicationForUser(_userChoiceOfApp, _userValuesForApp);
                    _userValuesForApp.Clear();
                }
                else if(_userAnswer != "e")
                {
                    _messageToUser = $"'{_userAnswer}' is not a correct number.";
                    _displayer.ErrorMsgForUser(_messageToUser);
                }

            } while (_userAnswer != "e");

        }
    }
}
