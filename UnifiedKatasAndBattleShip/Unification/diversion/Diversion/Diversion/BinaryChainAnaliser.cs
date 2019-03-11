using System;
using System.Collections.Generic;
using System.Text;

namespace Diversion
{
    public class BinaryChainAnaliser
    {
        private int _matchingChains = 0;

        public int NumberOfMatchingChains(string binary, int digitsInChain = 3)
        {
            int counter = 1;
            string binaryChain = "";

            foreach (var digit in binary)
            {
                binaryChain += digit;
                

                if (counter % digitsInChain == 0)
                {
                    AnaliseChain(binaryChain, digitsInChain);
                    binaryChain = "";
                }

                counter++;

            }

            return _matchingChains;
        }

        private void AnaliseChain(string binaryChain, int digitsInChain)
        {
            int successCounter = 0;
            for (int i = 1; i < binaryChain.Length; i++)
            {
                if (binaryChain[i - 1] == '1' && binaryChain[i] == '1')
                {

                }
                else
                    successCounter++;
            }

            bool evenNumberDigit = (digitsInChain % 2 == 0) ? true : false;

            if (successCounter == binaryChain.Length -1)
                _matchingChains++;

        }
    }
}
