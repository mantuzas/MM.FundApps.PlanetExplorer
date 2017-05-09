using System;
using FluentAssertions;
using MM.FundApps.PlanetExplorer.Robot.Abstractions;
using Xunit;

namespace MM.FundApps.PlanetExplorer.Robot.Tests
{
    public class TrajectoryCalculatorTests
    {
        public class TrajectoryCalculatorBaseTests
        {
            protected TrajectoryCalculator TrajectoryCalculator;

            public TrajectoryCalculatorBaseTests()
            {
                TrajectoryCalculator = new TrajectoryCalculator();
            }

            protected void AssertPose(Pose expected, Pose current)
            {
                expected.CardinalDirection.Should().Be(current.CardinalDirection);

                AssertPosition(expected.Position, current.Position);
            }

            protected void AssertPosition(Position expected, Position current)
            {
                expected.X.Should().Be(current.X);
                expected.Y.Should().Be(current.Y);
            }
        }

        public class CalculateForward : TrajectoryCalculatorBaseTests
        {
            [Fact]
            public void WhenEastAndMoveForward_ShouldMovedToEast()
            {
                var currentPose = new Pose(new Position(0, 0), CardinalDirection.East);
                var expected = new Pose(new Position(1, 0), CardinalDirection.East);

                var actual = TrajectoryCalculator.CalculateForward(currentPose);

                AssertPose(expected, actual);
            }

            [Fact]
            public void WhenNonExistingDirection_ThrowsException()
            {
                var currentPose = new Pose(new Position(0, 0), (CardinalDirection)(-1));
                Assert.Throws<NotSupportedException>(() => TrajectoryCalculator.CalculateForward(currentPose));
            }

            [Fact]
            public void WhenNorthAndMoveForward_ShouldMovedToNorth()
            {
                var currentPose = new Pose(new Position(0, 0), CardinalDirection.North);
                var expected = new Pose(new Position(0, 1), CardinalDirection.North);

                var actual = TrajectoryCalculator.CalculateForward(currentPose);

                AssertPose(expected, actual);
            }

            [Fact]
            public void WhenSouthAndMoveForward_ShouldMovedToSouth()
            {
                var currentPose = new Pose(new Position(0, 0), CardinalDirection.South);
                var expected = new Pose(new Position(0, -1), CardinalDirection.South);

                var actual = TrajectoryCalculator.CalculateForward(currentPose);

                AssertPose(expected, actual);
            }

            [Fact]
            public void WhenWestAndMoveForward_ShouldMovedToWest()
            {
                var currentPose = new Pose(new Position(0, 0), CardinalDirection.West);
                var expected = new Pose(new Position(-1, 0), CardinalDirection.West);

                var actual = TrajectoryCalculator.CalculateForward(currentPose);

                AssertPose(expected, actual);
            }
        }

        public class CalculateBackward : TrajectoryCalculatorBaseTests
        {
            [Fact]
            public void WhenEastAndMoveBackward_ShouldMovedToEast()
            {
                var currentPose = new Pose(new Position(0, 0), CardinalDirection.East);
                var expected = new Pose(new Position(-1, 0), CardinalDirection.East);

                var actual = TrajectoryCalculator.CalculateBackward(currentPose);

                AssertPose(expected, actual);
            }

            [Fact]
            public void WhenNonExistingDirection_ThrowsException()
            {
                var currentPose = new Pose(new Position(0, 0), (CardinalDirection)(-1));
                Assert.Throws<NotSupportedException>(() => TrajectoryCalculator.CalculateBackward(currentPose));
            }

            [Fact]
            public void WhenNorthAndMoveBackward_ShouldMovedToSouth()
            {
                var currentPose = new Pose(new Position(0, 0), CardinalDirection.North);
                var expected = new Pose(new Position(0, -1), CardinalDirection.North);

                var actual = TrajectoryCalculator.CalculateBackward(currentPose);

                AssertPose(expected, actual);
            }

            [Fact]
            public void WhenSouthAndMoveBackward_ShouldMovedToNorth()
            {
                var currentPose = new Pose(new Position(0, 0), CardinalDirection.South);
                var expected = new Pose(new Position(0, 1), CardinalDirection.South);

                var actual = TrajectoryCalculator.CalculateBackward(currentPose);

                AssertPose(expected, actual);
            }

            [Fact]
            public void WhenWestAndMoveBackward_ShouldMovedToEast()
            {
                var currentPose = new Pose(new Position(0, 0), CardinalDirection.West);
                var expected = new Pose(new Position(1, 0), CardinalDirection.West);

                var actual = TrajectoryCalculator.CalculateBackward(currentPose);

                AssertPose(expected, actual);
            }
        }
    }
}