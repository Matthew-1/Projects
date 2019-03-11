using System;
using System.Collections.Generic;

namespace BattleShips
{
    public class Game
    {
        private List<Player> _players;
        private IShipStrategy _shipStrategy;

        public Game()
        {
            _players = new List<Player>() { new Player(), new Player() };
        }

        public List<Player> GetPlayers() => _players;
        public IShipStrategy GetShipsStrategy() => _shipStrategy;
        public void SetPlayerName(string name, int playerIndex) => _players[playerIndex].Name = name;

        public void SetShipsNumberStrategy(IShipStrategy shipsStrategy)
        {
            _shipStrategy = shipsStrategy;
        }
    }
}