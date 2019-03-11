using System.Collections.Generic;

namespace BattleShips
{
    public interface IShipStrategy
    {
        List<int> GiveNumberOfMasts();
    }
}