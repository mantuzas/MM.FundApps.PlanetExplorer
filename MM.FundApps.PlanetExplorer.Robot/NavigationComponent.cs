﻿using MM.FundApps.PlanetExplorer.Robot.Abstractions;

namespace MM.FundApps.PlanetExplorer.Robot
{
    public class NavigationComponent : INavigationComponent
    {
        protected readonly ITrajectoryCalculator TrajectoryCalculator;

        public NavigationComponent(Pose homePose, ITrajectoryCalculator trajectoryCalculator)
        {
            Pose = homePose;
            TrajectoryCalculator = trajectoryCalculator;
        }

        public Pose Pose { get; private set; }

        public bool MoveForward()
        {
            Pose = TrajectoryCalculator.CalculateForward(Pose);
            return true;
        }
    }
}