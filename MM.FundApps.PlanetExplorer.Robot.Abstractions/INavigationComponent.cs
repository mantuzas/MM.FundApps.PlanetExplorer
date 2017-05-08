using System;
using System.Collections.Generic;
using System.Text;

namespace MM.FundApps.PlanetExplorer.Robot.Abstractions
{
    public interface INavigationComponent
    {
        Pose Pose { get; }

        bool MoveForward();
    }
}
