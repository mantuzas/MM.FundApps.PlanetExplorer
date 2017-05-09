using FluentAssertions;
using MM.FundApps.PlanetExplorer.Robot.Abstractions;
using NSubstitute;
using Xunit;

namespace MM.FundApps.PlanetExplorer.Robot.Tests
{
    public class NavigationComponentTests
    {
        public class NavigationComponentBaseTests
        {
            protected Pose Pose;
            protected NavigationComponent NavigationComponent;

            protected ITrajectoryCalculator TrajectoryCalculator;

            public NavigationComponentBaseTests()
            {
                Pose = new Pose();
                TrajectoryCalculator = Substitute.For<ITrajectoryCalculator>();
                NavigationComponent
                    = new NavigationComponent(Pose,
                        TrajectoryCalculator);
            }
        }

        public class MoveForward : NavigationComponentBaseTests
        {
            [Fact]
            public void WhenMoveForward_PoseChanges()
            {
                var destination = new Pose(new Position(0, 1), CardinalDirection.North);

                TrajectoryCalculator.CalculateForward(Pose).Returns(destination);

                var moved = NavigationComponent.MoveForward();

                TrajectoryCalculator.Received().CalculateForward(Pose);

                moved.Should().BeTrue();

                NavigationComponent.Pose.Should().Be(destination);
            }
        }

        public class MoveBackward : NavigationComponentBaseTests
        {
            [Fact]
            public void WhenMoveBackward_PoseChanges()
            {
                var destination = new Pose(new Position(0, -1), CardinalDirection.North);

                TrajectoryCalculator.CalculateBackward(Pose).Returns(destination);

                var moved = NavigationComponent.MoveBackward();

                TrajectoryCalculator.Received().CalculateBackward(Pose);

                moved.Should().BeTrue();

                NavigationComponent.Pose.Should().Be(destination);
            }
        }

        public class TurnRight : NavigationComponentBaseTests
        {
            [Fact]
            public void WhenTurns_PoseChanges()
            {
                var destination = new Pose(new Position(0, 0), CardinalDirection.East);

                TrajectoryCalculator.CalculateRight(Pose).Returns(destination);

                NavigationComponent.TurnRight();

                TrajectoryCalculator.Received().CalculateRight(Pose);

                NavigationComponent.Pose.Should().Be(destination);
            }
        }

        public class TurnLeft : NavigationComponentBaseTests
        {
            [Fact]
            public void WhenTurns_PoseChanges()
            {
                var destination = new Pose(new Position(0, 0), CardinalDirection.West);

                TrajectoryCalculator.CalculateLeft(Pose).Returns(destination);

                NavigationComponent.TurnLeft();

                TrajectoryCalculator.Received().CalculateLeft(Pose);

                NavigationComponent.Pose.Should().Be(destination);
            }
        }
    }
}