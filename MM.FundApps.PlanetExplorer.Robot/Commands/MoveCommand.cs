namespace MM.FundApps.PlanetExplorer.Robot.Commands
{
    public abstract class MoveCommand : Command
    {
        protected MoveCommand(char command) : base(command)
        {
        }
    }
}