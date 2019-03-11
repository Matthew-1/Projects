using BattleShips;
using BattleShips.GameElements;
using Moq;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.IO;

namespace Tests
{
    public class ShipTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void LocateShipWith2Masts_5x5yHorizontally()
        {
            //given
            Player player = new Player();
            int x_Coordinate = 5;
            int y_Coordinate = 5;
            int orientation = 0;
            player.AddShips(ShipsFactory.CreateManyShips(numberOfShips: 1, numberOfMasts: 2));

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Assert.IsTrue(player.BoardWithShips.BoardAllFields[i, j] == BoardField.Avaible);
                }
            }

            //when
            player.LocateShip(player.Ships[0],x_Coordinate,y_Coordinate,orientation);

            //then
            for (int i = x_Coordinate; i < x_Coordinate+2; i++)
            {
                Assert.IsTrue(player.BoardWithShips.BoardAllFields[y_Coordinate, i] == BoardField.Ship);
            }

            
        }

        [Test]
        public void MastsInPlayerAreIncreasedBy2_AfterLocatingShipWith2Masts()
        {
            //given
            Player player = new Player();
            int x_Coordinate = 5;
            int y_Coordinate = 5;
            int orientation = 0;
            player.AddShips(ShipsFactory.CreateManyShips(numberOfShips: 1, numberOfMasts: 2));

            //when
            player.LocateShip(player.Ships[0], x_Coordinate, y_Coordinate, orientation);

            //then
            int result = player.AllMasts;

            Assert.AreEqual(2, result);

            //when
            player.AddShips(ShipsFactory.CreateManyShips(numberOfShips: 1, numberOfMasts: 2));
            player.LocateShip(player.Ships[0],x_Coordinate, y_Coordinate, orientation);

            //then
            result = player.AllMasts;

            Assert.AreEqual(4, result);
        }


    }
}