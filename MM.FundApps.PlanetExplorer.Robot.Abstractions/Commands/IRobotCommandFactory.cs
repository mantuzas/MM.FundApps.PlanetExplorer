namespace MM.FundApps.PlanetExplorer.Robot.Abstractions.Commands
{
    public interface IRobotCommandFactory
    {
        ICommand Get(char command);
    }
}