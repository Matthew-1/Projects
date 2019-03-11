using System;
using System.Collections.Generic;
using System.Text;

namespace Unification
{
    public class ChoosingAppDataVerifierStrategy:IDataVerifier
    {
        private dynamic _userChoiceOfApp;

        public T GetUserVerifiedChoice<T>() => _userChoiceOfApp;

        public bool VerifyUserData(string userData)
        {
            bool parsingResult = int.TryParse(userData, out int userChoiceOfApp);

            _userChoiceOfApp = userChoiceOfApp;

            return parsingResult;
        }
    }
}
