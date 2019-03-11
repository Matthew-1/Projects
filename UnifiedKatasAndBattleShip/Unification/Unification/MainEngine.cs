using System;

namespace Unification
{
    internal class MainEngine
    {
        internal static void Start()
        {
            UserNeedsManager userNeedsManager = new UserNeedsManager();

            bool runApp = true;
            bool firstGreeting = true;

            do
            {
                runApp = userNeedsManager.PlayGamesEntryPoint(firstGreeting);
                firstGreeting = false;

            } while (runApp);

            Console.ReadKey();
        }
    }
}