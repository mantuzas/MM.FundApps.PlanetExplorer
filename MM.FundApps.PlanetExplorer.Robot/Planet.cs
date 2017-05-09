using Microsoft.Extensions.Options;
using MM.FundApps.PlanetExplorer.Robot.Abstractions;

namespace MM.FundApps.PlanetExplorer.Robot
{
    public class Planet : IPlanet
    {
        protected readonly IOptions<PlanetOptions> PlanetOptions;

        protected readonly PlanetBoundary PlanetBoundary;

        public Planet(IOptions<PlanetOptions> planetOptions)
        {
            PlanetOptions = planetOptions;
            PlanetBoundary = planetOptions.Value.PlanetBoundary;
        }

        public bool InPlanet(Position position)
        {
            if (position.X <= PlanetBoundary.MinX)
                return false;

            if (position.X >= PlanetBoundary.MaxX)
                return false;

            if (position.Y <= PlanetBoundary.MinY)
                return false;

            if (position.Y >= PlanetBoundary.MaxY)
                return false;

            return true;
        }
    }
}