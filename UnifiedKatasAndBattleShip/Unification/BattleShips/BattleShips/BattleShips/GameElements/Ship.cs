namespace BattleShips
{
    public class Ship
    {
        private int _masts;

        public Ship(int masts)
        {
            _masts = masts;
        }

        public int GetNumberOfMasts() => _masts;
    }
}