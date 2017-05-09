using System;
using FluentAssertions;
using Xunit;

namespace MM.FundApps.PlanetExplorer.Robot.Abstractions.Tests
{
    public class PlanetBoundaryTests
    {
        public class Constructor
        {
            [Fact]
            public void WhenParametersAreValid_AssignsValues()
            {
                Assert.Throws<ArgumentException>(() => new PlanetBoundary(-1, 1, 0, 0));
            }

            [Fact]
            public void WhenXCoordinatesAresSame_ThowsExceptions()
            {
                Assert.Throws<ArgumentException>(() => new PlanetBoundary(0, 0, -1, 1));
            }

            [Fact]
            public void WhenCoordinatesAreValid_ConstructsCorrectPlanetBoundary()
            {
                var planetBoundary = new PlanetBoundary(-1, 1, -2, 2);

                planetBoundary.Should().NotBeNull();
                planetBoundary.MinX.Should().Be(-1);
                planetBoundary.MaxX.Should().Be(1);
                planetBoundary.MinY.Should().Be(-2);
                planetBoundary.MaxY.Should().Be(2);
            }
        }
    }
}
