using Mars.Models.Enums;
using System.Collections.Generic;

namespace Mars.Models.Entities
{
    public class Coordinate
    {
        public Coordinate(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.ForbiddenDirections = new List<Direction>();
        }

        /// <summary>
        /// Horizonal side
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Vertical side
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Limitations of the mars
        /// </summary>
        public List<Direction> ForbiddenDirections { get; set; }

        /// <summary>
        /// Updates cordinate by direction
        /// </summary>
        public void UpdateCordinateByDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.West:
                    {
                        X = X - 1;
                        break;
                    }
                case Direction.North:
                    {
                        Y = Y + 1;
                        break;
                    }
                case Direction.East:
                    {
                        X = X + 1;
                        break;
                    }
                case Direction.South:
                    {
                        Y = Y - 1;
                        break;
                    }
            }
        }

        /// <summary>
        /// Set forbidden directions for the coordinate
        /// </summary>
        public void SetForbiddenDirectionsForCoordinate(int xRange, int yRange)
        {
            ForbiddenDirections = new List<Direction>();

            if (X == 0)
            {
                ForbiddenDirections.Add(Direction.West);
            }
            else if (X == xRange)
            {
                ForbiddenDirections.Add(Direction.East);
            }

            if (Y == 0)
            {
                ForbiddenDirections.Add(Direction.South);
            }
            else if (Y == yRange)
            {
                ForbiddenDirections.Add(Direction.North);
            }
        }
    }
}
