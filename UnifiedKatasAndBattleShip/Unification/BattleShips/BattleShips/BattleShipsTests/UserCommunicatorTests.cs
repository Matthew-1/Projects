using BattleShips;
using Moq;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.IO;

namespace Tests
{
    public class UserCommunicatorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AskForPlayerName_Matthew()
        {
            //given
            Game game = new Game();
            UserCommunicatorConfig userCommunicator = new UserCommunicatorConfig(game);
            Console.SetIn(new StringReader("Matthew"));

            //when
            userCommunicator.AskForPlayerNames();

            //then
            string playerName_1 = game.GetPlayers()[0].Name;

            Assert.AreEqual("Matthew", playerName_1);
           

        }

        [Test]
        public void AskForShipStrategy_RandomShipStrategy()
        {
            //given
            Game game = new Game();
            UserCommunicatorConfig userCommunicator = new UserCommunicatorConfig(game);
            Console.SetIn(new StringReader("0"));

            //when
            userCommunicator.AskForShipStrategy();

            //then
            Assert.IsTrue(game.GetShipsStrategy() is RandomShipsStrategy);



        }

        [Test]
        public void AskForShipStrategy_UserShipStrategy()
        {
            //given
            Game game = new Game();
            UserCommunicatorConfig userCommunicator = new UserCommunicatorConfig(game);
            Console.SetIn(new StringReader("7"));

            //when
            userCommunicator.AskForShipStrategy();

            //then
            Assert.IsTrue(game.GetShipsStrategy() is UserShipsStrategy);


        }

        [Test]
        public void AskForShipStrategy_WhenWrongNumberGivenAskForStrategyTillSuccess()
        {
            //given
            Game game = new Game();
            UserCommunicatorConfig userCommunicator = new UserCommunicatorConfig(game);
            Console.SetIn(new StringReader("100"));

            //when
            userCommunicator.AskForShipStrategy();
            Console.SetIn(new StringReader("7"));

            //then
            Assert.IsTrue(game.GetShipsStrategy() is UserShipsStrategy);

        }

    }
}