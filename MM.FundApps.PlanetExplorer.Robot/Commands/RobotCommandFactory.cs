using System.Collections.Generic;
using System.Linq;
using MM.FundApps.PlanetExplorer.Robot.Abstractions.Commands;

namespace MM.FundApps.PlanetExplorer.Robot.Commands
{
    public class RobotCommandFactory : IRobotCommandFactory
    {
        protected readonly IReadOnlyDictionary<char, ICommand> Commands;

        public RobotCommandFactory(IEnumerable<ICommand> vechileCommands)
        {
            Commands = vechileCommands.ToDictionary(i => i.Cmd, z => z);
        }

        public ICommand Get(char command)
        {
            return Commands.ContainsKey(command) ? Commands[command] : null;
        }
    }
}