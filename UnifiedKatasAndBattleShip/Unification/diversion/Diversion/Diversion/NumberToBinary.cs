using System;
using System.Collections.Generic;
using System.Text;

namespace Diversion
{
    public class NumberToBinary
    {
        public string ChangeNumberToBinary(string userValue)
        {
            int.TryParse(userValue, out int numberFromUser);

            string binary = Convert.ToString(numberFromUser, 2);

            return binary;
        }

    }
}
