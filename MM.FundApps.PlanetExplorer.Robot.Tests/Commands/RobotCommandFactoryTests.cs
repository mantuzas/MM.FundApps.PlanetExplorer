using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using MM.FundApps.PlanetExplorer.Robot.Abstractions.Commands;
using MM.FundApps.PlanetExplorer.Robot.Commands;
using NSubstitute;
using Xunit;

namespace MM.FundApps.PlanetExplorer.Robot.Tests.Commands
{
    public class RobotCommandFactoryTests
    {
        public class Get
        {
            [Fact]
            public void WhenNoCommandsDeclared_ReturnsNull()
            {
                var robotCommandFactory = new RobotCommandFactory(Enumerable.Empty<ICommand>());
                var nonExistingCommand = robotCommandFactory.Get('E');

                nonExistingCommand.Should().BeNull();
            }

            [Fact]
            public void WhenCommandsDeclared_ReturnsExpectedCommandNull()
            {
                var command = Substitute.For<ICommand>();
                command.Cmd.Returns('E');

                var robotCommandFactory = new RobotCommandFactory(new List<ICommand>() { command });
                var nonExistingCommand = robotCommandFactory.Get('E');

                nonExistingCommand.Should().NotBeNull();
            }
        }
    }
}