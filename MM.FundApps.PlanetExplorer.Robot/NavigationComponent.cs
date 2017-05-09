using MM.FundApps.PlanetExplorer.Robot.Abstractions;

namespace MM.FundApps.PlanetExplorer.Robot
{
    public class NavigationComponent : INavigationComponent
    {
        protected readonly ITrajectoryCalculator TrajectoryCalculator;

        protected readonly INavigationSystem NavigationSystem;

        public NavigationComponent(Pose homePose, 
            ITrajectoryCalculator trajectoryCalculator,
            INavigationSystem navigationSystem)
        {
            Pose = homePose;
            TrajectoryCalculator = trajectoryCalculator;
            NavigationSystem = navigationSystem;
        }

        public Pose Pose { get; private set; }

        public bool MoveForward()
        {
            var pose = TrajectoryCalculator.CalculateForward(Pose);

            if (!NavigationSystem.CanNavigate(pose.Position))
                return false;

            Pose = pose;
            return true;
        }

        public bool MoveBackward()
        {
            var pose = TrajectoryCalculator.CalculateBackward(Pose);

            if (!NavigationSystem.CanNavigate(pose.Position))
                return false;

            Pose = pose;
            return true;
        }

        public void TurnRight()
        {
            Pose = TrajectoryCalculator.CalculateRight(Pose);
        }

        public void TurnLeft()
        {
            Pose = TrajectoryCalculator.CalculateLeft(Pose);
        }
    }
}