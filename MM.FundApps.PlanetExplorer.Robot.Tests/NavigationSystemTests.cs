using FluentAssertions;
using MM.FundApps.PlanetExplorer.Robot.Abstractions;
using NSubstitute;
using Xunit;

namespace MM.FundApps.PlanetExplorer.Robot.Tests
{
    public class NavigationSystemTests
    {
        public class NavigationSystemBaseTests
        {
            protected NavigationSystem NavigationSystem;
            protected IPlanet Planet;

            public NavigationSystemBaseTests()
            {
                Planet = Substitute.For<IPlanet>();
                NavigationSystem = new NavigationSystem(Planet);
            }
        }

        public class CanNavigate : NavigationSystemBaseTests
        {
            [Fact]
            public void WhenNextMoveNotInPlanet_CannotNavigate()
            {
                var position = new Position();
                Planet.InPlanet(position).Returns(false);

                var canNavigate = NavigationSystem.CanNavigate(position);

                Planet.Received().InPlanet(position);
                canNavigate.Should().BeFalse();
            }

            [Fact]
            public void WhenNextMoveInPlanet_CanNavigate()
            {
                var position = new Position();
                Planet.InPlanet(position).Returns(true);

                var canNavigate = NavigationSystem.CanNavigate(position);

                Planet.Received().InPlanet(position);
                canNavigate.Should().BeTrue();
            }
        }
    }
}