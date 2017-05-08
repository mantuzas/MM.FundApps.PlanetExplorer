namespace MM.FundApps.PlanetExplorer.Robot.Abstractions
{
    public interface IRobot
    {
        bool MoveForward();

        Pose GetPose();
    }
}