using FluentAssertions;
using MM.FundApps.PlanetExplorer.Robot.Abstractions;
using MM.FundApps.PlanetExplorer.Robot.Commands;
using NSubstitute;
using Xunit;

namespace MM.FundApps.PlanetExplorer.Robot.Tests.Commands
{
    public class TurnRightCommandTests
    {
        public class TurnRightCommandBaseTests
        {
            protected TurnRightCommand TurnRightCommand;

            public TurnRightCommandBaseTests()
            {
                TurnRightCommand = new TurnRightCommand();
            }
        }

        public class Constructor : TurnRightCommandBaseTests
        {
            [Fact]
            public void When()
            {
                TurnRightCommand.Cmd.Should().Be('R');
            }
        }

        public class Execute : TurnRightCommandBaseTests
        {
            [Fact]
            public void WhenValidCommand_CallsTurnRightOnRobot()
            {
                var robot = Substitute.For<IRobot>();

                var successfully = TurnRightCommand.Execute(robot);

                Assert.True(successfully);
                robot.Received().TurnRight();
            }
        }
    }
}