using System.Collections.Generic;
using MM.FundApps.PlanetExplorer.Robot.Abstractions;

namespace MM.FundApps.PlanetExplorer.Robot
{
    public class PlanetOptions
    {
        public PlanetBoundary PlanetBoundary;

        public IReadOnlyCollection<Position> Obstacles;
    }
}
