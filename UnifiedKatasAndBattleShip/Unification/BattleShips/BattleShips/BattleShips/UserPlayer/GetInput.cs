using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips.UserPlayer
{
    public class GetInput:IUserInput
    {
        public string GetUserInput()
        {
            return Console.ReadLine();
        }
    }
}
