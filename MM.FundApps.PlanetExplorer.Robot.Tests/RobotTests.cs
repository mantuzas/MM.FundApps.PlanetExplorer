﻿using FluentAssertions;
using MM.FundApps.PlanetExplorer.Robot.Abstractions;
using NSubstitute;
using Xunit;

namespace MM.FundApps.PlanetExplorer.Robot.Tests
{
    public class RobotTests
    {
        public class RobotBaseTests
        {
            protected INavigationComponent NavigationComponent;
            protected Robot Robot;

            public RobotBaseTests()
            {
                NavigationComponent = Substitute.For<INavigationComponent>();
                Robot = new Robot(NavigationComponent);
            }
        }

        public class MoveForward : RobotBaseTests
        {
            [Fact]
            public void WhenMoveRight_ExpectsMoveRightExecuted()
            {
                NavigationComponent.MoveForward().Returns(true);

                var moved = Robot.MoveForward();

                moved.Should().BeTrue();

                NavigationComponent.Received().MoveForward();
            }
        }

        public class MoveBackward : RobotBaseTests
        {
            [Fact]
            public void WhenMoveBackward_ExpectsMoveBackwardExecuted()
            {
                NavigationComponent.MoveBackward().Returns(true);

                var moved = Robot.MoveBackward();

                moved.Should().BeTrue();

                NavigationComponent.Received().MoveBackward();
            }
        }

        public class GetPose : RobotBaseTests
        {
            [Fact]
            public void WhenGetPose_ExpectsPoseReturned()
            {
                var expectedPose = new Pose(new Position(0, 0), CardinalDirection.North);

                NavigationComponent.Pose.Returns(expectedPose);

                var actual = Robot.GetPose();

                actual.CardinalDirection.Should().Be(expectedPose.CardinalDirection);
                actual.Position.X.Should().Be(expectedPose.Position.X);
                actual.Position.Y.Should().Be(expectedPose.Position.Y);
            }
        }

        public class TurnRight : RobotBaseTests
        {
            [Fact]
            public void WhenTurnRight_ExpectsTurnRightExecuted()
            {
                Robot.TurnRight();

                NavigationComponent.Received().TurnRight();
            }
        }

        public class TurnLeft : RobotBaseTests
        {
            [Fact]
            public void WhenTurnLeft_ExpectsTurnLeftExecuted()
            {
                NavigationComponent.TurnLeft();

                Robot.TurnLeft();

                NavigationComponent.Received().TurnLeft();
            }
        }
    }
}