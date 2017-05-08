namespace MM.FundApps.PlanetExplorer.Robot.Abstractions
{
    public class Position
    {
        public Position() : this(0, 0)
        {
        }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }

        public int Y { get; }
    }
}