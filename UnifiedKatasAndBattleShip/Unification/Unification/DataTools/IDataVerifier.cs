using System;
using System.Collections.Generic;
using System.Text;

namespace Unification
{
    public interface IDataVerifier
    {
        bool VerifyUserData(string userData);
        T GetUserVerifiedChoice<T>();
    }
}
