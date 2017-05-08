using System;
using System.Collections.Generic;
using System.Text;

namespace MM.FundApps.PlanetExplorer.Robot.Abstractions
{
    public class Pose
    {
        public Pose() : this(new Position(), CardinalDirection.North)
        {
        }

        public Pose(Position position, CardinalDirection cardinalDirection)
        {
            Position = position;
            CardinalDirection = cardinalDirection;
        }

        public Position Position { get; }

        public CardinalDirection CardinalDirection { get; }
    }
}
