using FluentAssertions;
using MM.FundApps.PlanetExplorer.Robot.Abstractions;
using MM.FundApps.PlanetExplorer.Robot.Commands;
using NSubstitute;
using Xunit;

namespace MM.FundApps.PlanetExplorer.Robot.Tests.Commands
{
    public class MoveForwardCommandTests
    {
        public class MoveForwardCommandBaseTests
        {
            protected MoveForwardCommand MoveForwardCommand;

            public MoveForwardCommandBaseTests()
            {
                MoveForwardCommand = new MoveForwardCommand();
            }
        }

        public class Constructor : MoveForwardCommandBaseTests
        {
            [Fact]
            public void When()
            {
                MoveForwardCommand.Cmd.Should().Be('F');
            }
        }

        public class Execute : MoveForwardCommandBaseTests
        {
            [Fact]
            public void WhenValidCommand_CallsMoveForwardOnRobot()
            {
                var robot = Substitute.For<IRobot>();
                robot.MoveForward().Returns(true);

                var successfully = MoveForwardCommand.Execute(robot);

                Assert.True(successfully);
                robot.Received().MoveForward();
            }
        }
    }
}