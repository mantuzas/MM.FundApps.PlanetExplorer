using MM.FundApps.PlanetExplorer.Robot.Abstractions;

namespace MM.FundApps.PlanetExplorer.Robot.Commands
{
    public sealed class MoveBackwardCommand : MoveCommand
    {
        public MoveBackwardCommand() : base('B')
        {
        }

        public override bool Execute(IRobot robot)
        {
            return robot.MoveBackward();
        }
    }
}