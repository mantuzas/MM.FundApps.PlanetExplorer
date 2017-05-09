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
            protected INavigationSystem NavigationSystem;

            protected ITrajectoryCalculator TrajectoryCalculator;

            public NavigationComponentBaseTests()
            {
                Pose = new Pose();
                TrajectoryCalculator = Substitute.For<ITrajectoryCalculator>();
                NavigationSystem = Substitute.For<INavigationSystem>();

                NavigationComponent
                    = new NavigationComponent(Pose,
                        TrajectoryCalculator,
                        NavigationSystem);
            }
        }

        public class MoveForward : NavigationComponentBaseTests
        {
            [Fact]
            public void WhenMoveForward_PoseChanges()
            {
                var destination = new Pose(new Position(0, 1), CardinalDirection.North);

                TrajectoryCalculator.CalculateForward(Pose).Returns(destination);

                NavigationSystem.CanNavigate(destination.Position).Returns(true);

                var moved = NavigationComponent.MoveForward();

                TrajectoryCalculator.Received().CalculateForward(Pose);
                NavigationSystem.Received().CanNavigate(destination.Position);

                moved.Should().BeTrue();

                NavigationComponent.Pose.Should().Be(destination);
            }

            [Fact]
            public void WhenCannotMove_PoseStaysSame()
            {
                var destination = new Pose(new Position(0, 1), CardinalDirection.North);

                TrajectoryCalculator.CalculateForward(Pose).Returns(destination);

                NavigationSystem.CanNavigate(destination.Position).Returns(false);

                var moved = NavigationComponent.MoveForward();

                TrajectoryCalculator.Received().CalculateForward(Pose);
                NavigationSystem.Received().CanNavigate(destination.Position);

                moved.Should().BeFalse();

                NavigationComponent.Pose.Should().Be(Pose);
            }
        }

        public class MoveBackward : NavigationComponentBaseTests
        {
            [Fact]
            public void WhenMoveBackward_PoseChanges()
            {
                var destination = new Pose(new Position(0, -1), CardinalDirection.North);

                TrajectoryCalculator.CalculateBackward(Pose).Returns(destination);
                NavigationSystem.CanNavigate(destination.Position).Returns(true);

                var moved = NavigationComponent.MoveBackward();

                TrajectoryCalculator.Received().CalculateBackward(Pose);
                NavigationSystem.Received().CanNavigate(destination.Position);

                moved.Should().BeTrue();

                NavigationComponent.Pose.Should().Be(destination);
            }

            [Fact]
            public void WhenCannotMove_PoseStaysSame()
            {
                var destination = new Pose(new Position(0, -1), CardinalDirection.North);

                TrajectoryCalculator.CalculateBackward(Pose).Returns(destination);

                NavigationSystem.CanNavigate(destination.Position).Returns(false);

                var moved = NavigationComponent.MoveBackward();

                TrajectoryCalculator.Received().CalculateBackward(Pose);
                NavigationSystem.Received().CanNavigate(destination.Position);

                moved.Should().BeFalse();

                NavigationComponent.Pose.Should().Be(Pose);
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