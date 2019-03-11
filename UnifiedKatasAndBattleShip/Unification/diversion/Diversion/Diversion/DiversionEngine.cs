using SharedTools;
using System;
using System.Collections.Generic;
using System.Text;


namespace Diversion
{
    public class DiversionEngine
    {
        private Displayer _displayer;
        private string _messageForUser;

        public DiversionEngine()
        {
            _displayer = new Displayer();
        }
        public void StartApp(List<string> userValues)
        {
            BinaryChainAnaliser binaryChainAnaliser = new BinaryChainAnaliser();
            NumberToBinary numberToBinary = new NumberToBinary();

            string binaryValue = numberToBinary.ChangeNumberToBinary(userValues[0]);

            int matchingChains = binaryChainAnaliser.NumberOfMatchingChains(binaryValue, int.Parse(userValues[1]));

            _messageForUser = $"Your number '{userValues[0]}' in binary value is {binaryValue}. " +
                $"It has {matchingChains} matching chains.";
            _displayer.ConfirmativeMsgForUser(_messageForUser);
        }
    }
}
