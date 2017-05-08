using System.Collections.Generic;
using MM.FundApps.PlanetExplorer.RemoteControlCenter.Abstractions;
using MM.FundApps.PlanetExplorer.Robot.Abstractions.Commands;

namespace MM.FundApps.PlanetExplorer.RemoteControlCenter
{
    public class RobotCommandController : IRobotCommandController
    {
        protected readonly IHardwareInputDevice HardwareInputDevice;

        protected readonly IRobotCommandFactory RobotCommandFactory;

        public RobotCommandController(IHardwareInputDevice hardwareInputDevice,
            IRobotCommandFactory robotCommandFactory)
        {
            HardwareInputDevice = hardwareInputDevice;
            RobotCommandFactory = robotCommandFactory;
        }

        public ICollection<ICommand> ReadCommands()
        {
            var commandsInput = HardwareInputDevice.Capture();

            var commands = new List<ICommand>();

            if (string.IsNullOrWhiteSpace(commandsInput))
                return commands;

            foreach (var commandInput in commandsInput)
            {
                var command = RobotCommandFactory.Get(commandInput);
                if (command == null)
                    throw new InvalidCommandException(commandInput);

                commands.Add(command);
            }

            return commands;
        }
    }
}