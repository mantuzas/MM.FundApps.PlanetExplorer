using MM.FundApps.PlanetExplorer.RemoteControlCenter.Abstractions;
using MM.FundApps.PlanetExplorer.Robot.Abstractions;

namespace MM.FundApps.PlanetExplorer.RemoteControlCenter
{
    public class RemoteControlCenter : IRemoteControlCenter
    {
        protected readonly IHardwareOutputDevice HardwareOutputDevice;
        protected readonly IRobot Robot;
        protected readonly IRobotCommandController RobotCommandController;

        public RemoteControlCenter(IRobot robot,
            IRobotCommandController robotCommandController,
            IHardwareOutputDevice hardwareOutputDevice)
        {
            Robot = robot;
            RobotCommandController = robotCommandController;
            HardwareOutputDevice = hardwareOutputDevice;
        }

        public void Execute()
        {
            var homePose = Robot.GetPose();

            HardwareOutputDevice.Output($"Home pose X: {homePose.Position.X}, Y: {homePose.Position.Y}, Direction: {homePose.CardinalDirection}");
            HardwareOutputDevice.Output($"Enter command:");

            try
            {   
                var commands = RobotCommandController.ReadCommands();

                foreach (var command in commands)
                {
                    command.Execute(Robot);
                }

                var lastPose = Robot.GetPose();
                HardwareOutputDevice.Output($"Last pose X: {lastPose.Position.X}, Y: {lastPose.Position.Y}, Direction: {lastPose.CardinalDirection}");
            }
            catch (InvalidCommandException invalidCommandException)
            {
                HardwareOutputDevice.Output($"Invalid command entered: {invalidCommandException.Command}");
            }

            HardwareOutputDevice.Output($"Exiting.");
        }
    }
}