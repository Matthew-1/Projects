using System;
using System.Collections.Generic;
using System.Text;

namespace Unification.DataTools
{
    public class BattleShipsDataVerifierStrategy : IDataVerifier
    {
        private dynamic _userVerifiedData;
        public T GetUserVerifiedChoice<T>() => _userVerifiedData;


        public bool VerifyUserData(string userData)
        {
            string userAnswer = userData.Trim().ToLower();

            if (userAnswer == "y")
                return true;
            else
            {
                _userVerifiedData = userAnswer;
                return false;
            }
                

        }
    }
}
