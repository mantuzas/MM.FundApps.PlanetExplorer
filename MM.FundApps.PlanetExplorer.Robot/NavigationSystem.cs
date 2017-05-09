using MM.FundApps.PlanetExplorer.Robot.Abstractions;

namespace MM.FundApps.PlanetExplorer.Robot
{
    public class NavigationSystem : INavigationSystem
    {
        protected readonly IPlanet Planet;

        public NavigationSystem(IPlanet planet)
        {
            Planet = planet;
        }

        public bool CanNavigate(Position position)
        {
            if (!Planet.InPlanet(position))
                return false;

            return !Planet.IsObstacle(position);
        }
    }
}