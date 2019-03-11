using System;
using System.Collections.Generic;
using System.Text;

namespace Unification.DataTools
{
    public class DiversionUserDataVerifierStrategy : IDataVerifier
    {
        private dynamic _userValue;
        public T GetUserVerifiedChoice<T>() => _userValue;

        public bool VerifyUserData(string userData)
        {
            bool parsingResult = int.TryParse(userData, out int userValue);
            _userValue = userValue;

            return parsingResult;       
        }
    }
}
