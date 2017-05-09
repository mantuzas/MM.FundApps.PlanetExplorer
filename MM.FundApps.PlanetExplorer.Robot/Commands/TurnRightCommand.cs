using MM.FundApps.PlanetExplorer.Robot.Abstractions;

namespace MM.FundApps.PlanetExplorer.Robot.Commands
{
    public sealed class TurnRightCommand : TurnCommand
    {
        public TurnRightCommand() : base('R')
        {
        }

        public override bool Execute(IRobot robot)
        {
            robot.TurnRight();
            return true;
        }
    }
}