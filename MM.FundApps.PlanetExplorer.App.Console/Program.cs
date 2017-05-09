using System.Linq;
using Microsoft.Extensions.DependencyInjection;
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
           
            // Robot
            serviceCollection
                .AddScoped<ICommand, MoveForwardCommand>()
                .AddScoped(sp => sp.GetServices<ICommand>().ToArray())
                .AddScoped<IRobotCommandFactory, RobotCommandFactory>()
                .AddSingleton<Pose>(new Pose(new Position(0, 0), CardinalDirection.North))
                .AddScoped<ITrajectoryCalculator, TrajectoryCalculator>()
                .AddScoped<INavigationComponent, NavigationComponent>()
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