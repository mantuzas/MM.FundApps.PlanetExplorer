using FluentAssertions;
using MM.FundApps.PlanetExplorer.Robot.Abstractions;
using MM.FundApps.PlanetExplorer.Robot.Commands;
using NSubstitute;
using Xunit;

namespace MM.FundApps.PlanetExplorer.Robot.Tests.Commands
{
    public class TurnLeftCommandTests
    {
        public class TurnLeftCommandBaseTests
        {
            protected TurnLeftCommand TurnLeftCommand;

            public TurnLeftCommandBaseTests()
            {
                TurnLeftCommand = new TurnLeftCommand();
            }
        }

        public class Constructor : TurnLeftCommandBaseTests
        {
            [Fact]
            public void When()
            {
                TurnLeftCommand.Cmd.Should().Be('L');
            }
        }

        public class Execute : TurnLeftCommandBaseTests
        {
            [Fact]
            public void WhenValidCommand_CallsTurnLeftOnRobot()
            {
                var robot = Substitute.For<IRobot>();

                var successfully = TurnLeftCommand.Execute(robot);

                Assert.True(successfully);
                robot.Received().TurnLeft();
            }
        }
    }
}