namespace MM.FundApps.PlanetExplorer.Robot.Abstractions
{
    public interface ITrajectoryCalculator
    {
        Pose CalculateForward(Pose currentPose);

        Pose CalculateBackward(Pose currentPose);

        Pose CalculateRight(Pose currentPose);
    }
}