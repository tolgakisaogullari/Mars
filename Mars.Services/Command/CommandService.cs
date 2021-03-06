using Mars.Common;
using Mars.Models.Entities;
using Mars.Models.Enums;
using System.Collections.Generic;

namespace Mars.Services
{
    public class CommandService : ICommandService
    {
        /// <summary>
        /// Runs given commands for robot
        /// </summary>
        public ServiceResult Run(Robot robot, Plateau plateau, List<char> commands)
        {
            foreach (var command in commands)
            {
                switch (char.ToUpper(command))
                {
                    case 'M':
                        {
                            robot.Coordinate.SetForbiddenDirectionsForCoordinate(plateau.XRange, plateau.YRange);

                            if (robot.Coordinate.ForbiddenDirections.Contains(robot.Direction))
                            {

                                return ServiceResult.Fail($"The coordinate that you want to move on is out of Mars so you can not move further on {robot.Direction.GetDisplayName()} side.");
                            }

                            robot.Coordinate.UpdateCordinateByDirection(robot.Direction);

                            break;
                        }
                    case 'L':
                        {
                            var newDirection = (int)robot.Direction - 90;

                            if (newDirection == -90)
                            {
                                newDirection = 270;
                            }

                            robot.Direction = (Direction)newDirection;
                            break;
                        }
                    case 'R':
                        {
                            var newDirection = (int)robot.Direction + 90;

                            if (newDirection == 360)
                            {
                                newDirection = 0;
                            }

                            robot.Direction = (Direction)newDirection;
                            break;
                        }
                    default:
                        break;
                }


            }

            return ServiceResult.Success();
        }
    }
}
