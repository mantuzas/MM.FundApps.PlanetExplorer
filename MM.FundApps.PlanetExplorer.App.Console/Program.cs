using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MM.FundApps.PlanetExplorer.RemoteControlCenter;
using MM.FundApps.PlanetExplorer.RemoteControlCenter.Abstractions;
using MM.FundApps.PlanetExplorer.Robot;
using MM.FundApps.PlanetExplorer.Robot.Abstractions;
using MM.FundApps.PlanetExplorer.Robot.Abstractions.Commands;
using MM.FundApps.PlanetExplorer.Robot.Commands;

namespace MM.FundApps.PlanetExplorer.App.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();

            var planetOptions = Options.Create(new PlanetOptions()
            {
                PlanetBoundary = new PlanetBoundary(-1, 11, -1, 11),
                Obstacles = new List<Position>()
                {
                    new Position(1, 1)
                }
            });

            // Robot
            serviceCollection
                .AddScoped<ICommand, MoveForwardCommand>()
                .AddScoped<ICommand, MoveBackwardCommand>()
                .AddScoped<ICommand, TurnRightCommand>()
                .AddScoped<ICommand, TurnLeftCommand>()
                .AddScoped(sp => sp.GetServices<ICommand>().ToArray())
                .AddScoped<IRobotCommandFactory, RobotCommandFactory>()
                .AddSingleton(planetOptions)
                .AddSingleton<Pose>(new Pose(new Position(0, 0), CardinalDirection.North))
                .AddScoped<ITrajectoryCalculator, TrajectoryCalculator>()
                .AddScoped<INavigationComponent, NavigationComponent>()
                .AddScoped<INavigationSystem, NavigationSystem>()
                .AddScoped<IPlanet, Planet>()
                .AddScoped<IRobot, Robot.Robot>();

            // RemoteControlCenter
            serviceCollection
                .AddScoped<IHardwareInputDevice, HardwareInputDevice>()
                .AddScoped<IHardwareOutputDevice, HardwareOutputDevice>()
                .AddScoped<IRobotCommandController, RobotCommandController>()
                .AddScoped<IRemoteControlCenter, RemoteControlCenter.RemoteControlCenter>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Execute
            var remoteControlCenter = serviceProvider.GetService<IRemoteControlCenter>();
            remoteControlCenter.Execute();
        }
    }
}