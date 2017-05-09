using MM.FundApps.PlanetExplorer.Robot.Abstractions;

namespace MM.FundApps.PlanetExplorer.Robot
{
    public class Robot : IRobot
    {
        protected readonly INavigationComponent NavigationComponent;

        public Robot(INavigationComponent navigationComponent)
        {
            NavigationComponent = navigationComponent;
        }

        public bool MoveForward()
        {
            return NavigationComponent.MoveForward();
        }

        public bool MoveBackward()
        {
            return NavigationComponent.MoveBackward();
        }

        public void TurnRight()
        {
            NavigationComponent.TurnRight();
        }

        public void TurnLeft()
        {
            NavigationComponent.TurnLeft();
        }

        public Pose GetPose()
        {
            return NavigationComponent.Pose;
        }
    }
}