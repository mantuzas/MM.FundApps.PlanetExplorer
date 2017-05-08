using MM.FundApps.PlanetExplorer.Robot.Abstractions;
using MM.FundApps.PlanetExplorer.Robot.Abstractions.Commands;

namespace MM.FundApps.PlanetExplorer.Robot.Commands
{
    public abstract class Command : ICommand
    {
        protected Command(char command)
        {
            Cmd = command;
        }

        public char Cmd { get; }

        public abstract bool Execute(IRobot robot);
    }
}