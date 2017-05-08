using System.Collections.Generic;
using MM.FundApps.PlanetExplorer.Robot.Abstractions.Commands;

namespace MM.FundApps.PlanetExplorer.RemoteControlCenter.Abstractions
{
    public interface IRobotCommandController
    {
        ICollection<ICommand> ReadCommands();
    }
}