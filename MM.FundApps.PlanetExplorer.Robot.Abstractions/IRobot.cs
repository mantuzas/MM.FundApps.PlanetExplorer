namespace MM.FundApps.PlanetExplorer.Robot.Abstractions
{
    public interface IRobot
    {
        bool MoveForward();

        bool MoveBackward();

        void TurnRight();

        void TurnLeft();

        Pose GetPose();
    }
}