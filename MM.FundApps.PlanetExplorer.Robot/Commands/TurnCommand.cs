namespace MM.FundApps.PlanetExplorer.Robot.Commands
{
    public abstract class TurnCommand
        : Command
    {
        protected TurnCommand(char command)
            : base(command)
        {
        }
    }
}