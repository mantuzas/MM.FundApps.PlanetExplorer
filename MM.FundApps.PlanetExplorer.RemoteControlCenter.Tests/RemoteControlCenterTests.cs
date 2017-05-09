using System.Collections.Generic;
using System.Linq;
using MM.FundApps.PlanetExplorer.RemoteControlCenter.Abstractions;
using MM.FundApps.PlanetExplorer.Robot.Abstractions;
using MM.FundApps.PlanetExplorer.Robot.Abstractions.Commands;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Xunit;

namespace MM.FundApps.PlanetExplorer.RemoteControlCenter.Tests
{
    public class RemoteControlCenterTests
    {
        public class RemoteControlCenterBaseTests
        {
            protected IHardwareOutputDevice HardwareOutputDevice;

            protected RemoteControlCenter RemoteControlCenter;
            protected IRobot Robot;
            protected IRobotCommandController RobotCommandController;

            public RemoteControlCenterBaseTests()
            {
                HardwareOutputDevice = Substitute.For<IHardwareOutputDevice>();
                Robot = Substitute.For<IRobot>();
                RobotCommandController = Substitute.For<IRobotCommandController>();

                RemoteControlCenter
                    = new RemoteControlCenter(Robot,
                        RobotCommandController,
                        HardwareOutputDevice);
            }
        }

        public class Execute : RemoteControlCenterBaseTests
        {

            [Fact]
            public void WhenNoCommands_RobotStaysAtSamePoint()
            {
                var homePose = new Pose();
                Robot.GetPose().Returns(homePose);

                RobotCommandController.ReadCommands().Returns(Enumerable.Empty<ICommand>());

                RemoteControlCenter.Execute();

                HardwareOutputDevice.Received().Output("Enter command:");

                Robot.Received().GetPose();
                HardwareOutputDevice.Received().Output($"Home pose X: {homePose.Position.X}, Y: {homePose.Position.Y}, Direction: {homePose.CardinalDirection}");
                RobotCommandController.Received().ReadCommands();

                var lastPose = homePose;

                Robot.Received().GetPose();
                HardwareOutputDevice.Received().Output($"Last pose X: {lastPose.Position.X}, Y: {lastPose.Position.Y}, Direction: {lastPose.CardinalDirection}");

                HardwareOutputDevice.Received().Output($"Exiting.");
            }

            [Fact]
            public void WhenInvalidCommand_ExceptionIsCatched()
            {
                var homePose = new Pose();
                Robot.GetPose().Returns(homePose);

                var command = Substitute.For<ICommand>();
                command.Cmd.Returns('A');

                RobotCommandController.ReadCommands().Throws(new InvalidCommandException('A'));

                // Act
                RemoteControlCenter.Execute();

                HardwareOutputDevice.Received().Output("Enter command:");

                Robot.Received().GetPose();
                HardwareOutputDevice.Received().Output($"Home pose X: {homePose.Position.X}, Y: {homePose.Position.Y}, Direction: {homePose.CardinalDirection}");
                RobotCommandController.Received().ReadCommands();

                Robot.Received().GetPose();
                HardwareOutputDevice.Output($"Invalid command entered: A");

                HardwareOutputDevice.Received().Output($"Exiting.");
            }
            
            [Fact]
            public void WhenCommandsAndCanMove_RobotMoves()
            {
                var homePose = new Pose();
                Robot.GetPose().Returns(homePose);

                var command = Substitute.For<ICommand>();
                command.Cmd.Returns('F');

                RobotCommandController.ReadCommands().Returns(new List<ICommand> { command });


                command.Execute(Robot).Returns(true);

                // Act
                RemoteControlCenter.Execute();

                HardwareOutputDevice.Received().Output("Enter command:");

                Robot.Received().GetPose();
                HardwareOutputDevice.Received().Output($"Home pose X: {homePose.Position.X}, Y: {homePose.Position.Y}, Direction: {homePose.CardinalDirection}");
                RobotCommandController.Received().ReadCommands();


                var lastPose = homePose;
                Robot.Received().GetPose();
                HardwareOutputDevice.Received().Output($"Last pose X: {lastPose.Position.X}, Y: {lastPose.Position.Y}, Direction: {lastPose.CardinalDirection}");

                HardwareOutputDevice.Received().Output($"Exiting.");
            }
        }
    }
}