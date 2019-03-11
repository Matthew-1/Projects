using System;
using System.Collections.Generic;
using System.Text;
using Unification.Application;

namespace Unification
{
    public class ApplicationsManager
    {
        
        private AvaibleApplications _avaibleApps;

        public ApplicationsManager()
        {
            _avaibleApps = new AvaibleApplications();
        }

        public void StartApplicationForUser(int appNumber, List<string> _userValuesForApp)
        {

            switch (appNumber)
            {
                case 1:
                    _avaibleApps.StartAnagramsApp(_userValuesForApp);
                    break;
                case 2:
                    _avaibleApps.StartDiversionApp(_userValuesForApp);
                    break;
                case 3:
                    _avaibleApps.StartBattleShipsApp();
                    break;
            }
        }

    }
}
