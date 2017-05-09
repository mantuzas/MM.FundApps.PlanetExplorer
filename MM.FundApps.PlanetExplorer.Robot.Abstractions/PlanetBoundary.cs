using System;

namespace MM.FundApps.PlanetExplorer.Robot.Abstractions
{
    public class PlanetBoundary
    {
        public PlanetBoundary(int minX, int maxX, int minY, int maxY)
        {
            if (minX == maxX)
                throw new ArgumentException("Coordinate system X coordinates can't be the same.",
                    $"{nameof(minX)}; {nameof(maxX)}");

            if (minY == maxY)
                throw new ArgumentException("Coordinate system Y coordinates can't be the same.",
                    $"{nameof(minY)}; {nameof(maxY)}");

            MinX = Math.Min(minX, maxX);
            MaxX = Math.Max(minX, maxX);

            MinY = Math.Min(minY, maxY);
            MaxY = Math.Max(minY, maxY);
        }

        public int MinX { get; }

        public int MaxX { get; }

        public int MinY { get; }

        public int MaxY { get; }
    }
}
