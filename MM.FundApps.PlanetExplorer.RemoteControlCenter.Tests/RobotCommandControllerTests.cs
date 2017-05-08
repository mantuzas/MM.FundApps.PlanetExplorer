using System.Linq;
using FluentAssertions;
using MM.FundApps.PlanetExplorer.RemoteControlCenter.Abstractions;
using MM.FundApps.PlanetExplorer.Robot.Abstractions.Commands;
using NSubstitute;
using Xunit;

namespace MM.FundApps.PlanetExplorer.RemoteControlCenter.Tests
{
    public class RobotCommandControllerTests
    {
        public class RobotCommandControllerBaseTests
        {
            protected IHardwareInputDevice HardwareInputDevice;

            protected RobotCommandController RobotCommandController;

            protected IRobotCommandFactory RobotCommandFactory;

            public RobotCommandControllerBaseTests()
            {
                HardwareInputDevice = Substitute.For<IHardwareInputDevice>();
                RobotCommandFactory = Substitute.For<IRobotCommandFactory>();

                RobotCommandController = new RobotCommandController(HardwareInputDevice, RobotCommandFactory);
            }
        }

        public class ReadCommands : RobotCommandControllerBaseTests
        {
            [Fact]
            public void WhenHardwareCapturesExistingCommand_ReturnsCommands()
            {
                var command = Substitute.For<ICommand>();
                command.Cmd.Returns('A');

                HardwareInputDevice.Capture().Returns("A");
                RobotCommandFactory.Get('A').Returns(command);

                var commands = RobotCommandController.ReadCommands();

                commands.Should().NotBeNull();
                commands.Should().NotBeEmpty();
                commands.Single().Cmd.Should().Be('A');
            }

            [Fact]
            public void WhenHardwareCapturesNonExistingCommand_ThrowsInvalidCommandException()
            {
                HardwareInputDevice.Capture().Returns("A");
                RobotCommandFactory.Get('A').Returns((ICommand)null);

                Assert.Throws<InvalidCommandException>(() => RobotCommandController.ReadCommands());
            }

            [Fact]
            public void WhenHardwareDoesNotCaptureCommand_ReturnsEmtyListOfCommands()
            {
                HardwareInputDevice.Capture().Returns(string.Empty);

                var commands = RobotCommandController.ReadCommands();

                commands.Should().NotBeNull();
                commands.Should().BeEmpty();
            }
        }
    }
}