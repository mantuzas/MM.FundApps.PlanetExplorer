namespace MM.FundApps.PlanetExplorer.Robot.Abstractions.Commands
{
    public interface ICommand
    {
        char Cmd { get; }

        bool Execute(IRobot robot);
    }
}