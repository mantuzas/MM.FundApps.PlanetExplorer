using FluentAssertions;
using MM.FundApps.PlanetExplorer.Robot.Abstractions;
using MM.FundApps.PlanetExplorer.Robot.Commands;
using NSubstitute;
using Xunit;

namespace MM.FundApps.PlanetExplorer.Robot.Tests.Commands
{
    public class MoveBackwardCommandTests
    {
        public class MoveBackwardCommandBaseTests
        {
            protected MoveBackwardCommand MoveBackwardCommand;

            public MoveBackwardCommandBaseTests()
            {
                MoveBackwardCommand = new MoveBackwardCommand();
            }
        }

        public class Constructor : MoveBackwardCommandBaseTests
        {
            [Fact]
            public void When()
            {
                MoveBackwardCommand.Cmd.Should().Be('B');
            }
        }

        public class Execute : MoveBackwardCommandBaseTests
        {
            [Fact]
            public void WhenValidCommand_CallsMoveBackwardOnRobot()
            {
                var robot = Substitute.For<IRobot>();
                robot.MoveBackward().Returns(true);

                var successfully = MoveBackwardCommand.Execute(robot);

                Assert.True(successfully);
                robot.Received().MoveBackward();
            }
        }
    }
}