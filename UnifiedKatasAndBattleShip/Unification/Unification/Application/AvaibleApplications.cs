using System;
using System.Collections.Generic;
using System.Text;
using anagrams;
using Diversion;
using BattleShips;


namespace Unification.Application
{
    public class AvaibleApplications
    {

        public void StartDiversionApp(List<string> _userValuesForApp)
        {
            new DiversionEngine().StartApp(_userValuesForApp);
        }

        public void StartAnagramsApp(List<string> _userValuesForApp)
        {
            new AnagramEngine().StartApp(_userValuesForApp);
        }

        public void StartBattleShipsApp()
        {
            new BattleShipsEngine().StartApp();
        }
    }
}
