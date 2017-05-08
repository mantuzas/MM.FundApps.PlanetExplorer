using MM.FundApps.PlanetExplorer.Robot.Abstractions;

namespace MM.FundApps.PlanetExplorer.Robot.Commands
{
    public sealed class MoveForwardCommand : MoveCommand
    {
        public MoveForwardCommand() : base('F')
        {
        }

        public override bool Execute(IRobot robot)
        {
            return robot.MoveForward();
        }
    }
}