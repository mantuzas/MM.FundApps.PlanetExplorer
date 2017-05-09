using System;

namespace MM.FundApps.PlanetExplorer.Robot.Abstractions
{
    public class PlanetBoundary
    {
        /// <summary>
        /// Constructor for Configuration.
        /// </summary>
        public PlanetBoundary()
        {
        }

        public PlanetBoundary(int minX, int maxX, int minY, int maxY)
            : this()
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

        public int MinX { get; set; }

        public int MaxX { get; set; }

        public int MinY { get; set; }

        public int MaxY { get; set; }
    }
}
