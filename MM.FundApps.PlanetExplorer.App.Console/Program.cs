using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
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
        public static IConfigurationRoot Configuration { get; set; }

        private static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddOptions();

            /*
            // Configuring PlanetOptions.
            var planetOptions = Options.Create(new PlanetOptions()
            {
                PlanetBoundary = new PlanetBoundary(-1, 11, -1, 11),
                Obstacles = new List<Position>()
                {
                    new Position(1, 1)
                }
            });
            serviceCollection.AddSingleton(planetOptions);
            */

            // Configuring PlanetOptions from Configuration file.
            serviceCollection.Configure<PlanetOptions>(Configuration.GetSection("PlanetOptions"));

            // Robot
            serviceCollection
                .AddScoped<ICommand, MoveForwardCommand>()
                .AddScoped<ICommand, MoveBackwardCommand>()
                .AddScoped<ICommand, TurnRightCommand>()
                .AddScoped<ICommand, TurnLeftCommand>()
                .AddScoped(sp => sp.GetServices<ICommand>().ToArray())
                .AddScoped<IRobotCommandFactory, RobotCommandFactory>()
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

            System.Console.ReadLine();
        }
    }
}