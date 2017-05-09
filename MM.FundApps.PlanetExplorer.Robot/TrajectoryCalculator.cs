using System;
using MM.FundApps.PlanetExplorer.Robot.Abstractions;

namespace MM.FundApps.PlanetExplorer.Robot
{
    public class TrajectoryCalculator : ITrajectoryCalculator
    {
        public Pose CalculateForward(Pose currentPose)
        {
            Position position;

            switch (currentPose.CardinalDirection)
            {
                case CardinalDirection.North:
                    position = new Position(currentPose.Position.X, currentPose.Position.Y + 1);
                    break;
                case CardinalDirection.East:
                    position = new Position(currentPose.Position.X + 1, currentPose.Position.Y);
                    break;
                case CardinalDirection.South:
                    position = new Position(currentPose.Position.X, currentPose.Position.Y - 1);
                    break;
                case CardinalDirection.West:
                    position = new Position(currentPose.Position.X - 1, currentPose.Position.Y);
                    break;
                default:
                    throw new NotSupportedException();
            }

            return new Pose(position, currentPose.CardinalDirection);
        }

        public Pose CalculateBackward(Pose currentPose)
        {
            Position position;

            switch (currentPose.CardinalDirection)
            {
                case CardinalDirection.North:
                    position = new Position(currentPose.Position.X, currentPose.Position.Y - 1);
                    break;
                case CardinalDirection.East:
                    position = new Position(currentPose.Position.X - 1, currentPose.Position.Y);
                    break;
                case CardinalDirection.South:
                    position = new Position(currentPose.Position.X, currentPose.Position.Y + 1);
                    break;
                case CardinalDirection.West:
                    position = new Position(currentPose.Position.X + 1, currentPose.Position.Y);
                    break;
                default:
                    throw new NotSupportedException();
            }

            return new Pose(position, currentPose.CardinalDirection);
        }
    }
}