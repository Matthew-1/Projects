using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTools
{
    public class Displayer
    {
        public void CasualMsgForUser(string messageToUser)
        {
            Console.WriteLine();
            Console.WriteLine(messageToUser);
            Console.WriteLine();
        }

        public void ErrorMsgForUser(string messageToUser)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            CasualMsgForUser(messageToUser);
            Console.ResetColor();
        }

        public void ConfirmativeMsgForUser(string messageToUser)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            CasualMsgForUser(messageToUser);
            Console.ResetColor();
        }

        public void ClearConsole() => Console.Clear();
    }
}
