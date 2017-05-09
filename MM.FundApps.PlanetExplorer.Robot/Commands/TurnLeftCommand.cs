using MM.FundApps.PlanetExplorer.Robot.Abstractions;

namespace MM.FundApps.PlanetExplorer.Robot.Commands
{
    public sealed class TurnLeftCommand : TurnCommand
    {
        public TurnLeftCommand() : base('L')
        {
        }

        public override bool Execute(IRobot robot)
        {
            robot.TurnLeft();
            return true;
        }
    }
}