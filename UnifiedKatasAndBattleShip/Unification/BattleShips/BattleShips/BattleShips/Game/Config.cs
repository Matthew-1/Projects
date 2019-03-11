namespace BattleShips
{
    public class Config
    {
       
        public Game SetUpGame()
        {
            //Create Game and user communicator
            Game game = new Game();
            UserCommunicatorConfig userCommunicator = new UserCommunicatorConfig(game);
            //Set up players
            userCommunicator.AskForPlayerNames();
            //Choose ship number strategy
            userCommunicator.AskForShipStrategy();
            //Create ships
            ShipsFactory.CreateShipsForGame(game);
            //Set up boards
            userCommunicator.AskForLocatingShips();

            return game;

        }
    }
}