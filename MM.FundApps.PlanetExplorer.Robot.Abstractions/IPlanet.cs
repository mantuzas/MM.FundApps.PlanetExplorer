namespace MM.FundApps.PlanetExplorer.Robot.Abstractions
{
    public interface IPlanet
    {
        bool InPlanet(Position position);

        bool IsObstacle(Position position);
    }
}