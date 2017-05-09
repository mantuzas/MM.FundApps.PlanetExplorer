﻿using System.Collections.Generic;
using FluentAssertions;
using Microsoft.Extensions.Options;
using MM.FundApps.PlanetExplorer.Robot.Abstractions;
using NSubstitute;
using Xunit;

namespace MM.FundApps.PlanetExplorer.Robot.Tests
{
    public class PlanetTests
    {
        public class PlanetBaseTests
        {
            protected Planet Planet;
            protected IOptions<PlanetOptions> PlanetOptions;

            public PlanetBaseTests()
            {
                PlanetOptions = Substitute.For<IOptions<PlanetOptions>>();
            }
        }

        public class Inbound : PlanetBaseTests
        {
            public Inbound()
            {
                PlanetOptions.Value.PlanetBoundary = new PlanetBoundary(-5, 5, -10, 10);
                Planet = new Planet(PlanetOptions);
            }

            [Fact]
            public void WhenXPositionIsLessThanMinX_ShouldBeOutbound()
            {
                var inbound = Planet.InPlanet(new Position(-5, 0));
                inbound.Should().BeFalse();
            }

            [Fact]
            public void WhenXPositionIsGreaterThanMaxX_ShouldBeOutbound()
            {
                var inbound = Planet.InPlanet(new Position(5, 0));
                inbound.Should().BeFalse();
            }

            [Fact]
            public void WhenYPositionIsLessThanMinY_ShouldBeOutbound()
            {
                var inbound = Planet.InPlanet(new Position(0, -10));
                inbound.Should().BeFalse();
            }

            [Fact]
            public void WhenYPositionIsGreaterThanMaxY_ShouldBeOutbound()
            {
                var inbound = Planet.InPlanet(new Position(0, 10));
                inbound.Should().BeFalse();
            }

            [Fact]
            public void WhenXandYPositionsAreInsideBounds_ShouldBeInbound()
            {
                var inbound = Planet.InPlanet(new Position(0, 0));
                inbound.Should().BeTrue();
            }
        }
    }
}
