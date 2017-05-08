﻿namespace MM.FundApps.PlanetExplorer.Robot.Abstractions
{
    public interface ITrajectoryCalculator
    {
        Pose CalculateForward(Pose currentPose);
    }
}