using Mars.Common;
using Mars.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mars
{
    internal class Program
    {
        private readonly static Dictionary<string, Direction> _directionWithSymbol = new()
        {
            { "W", Direction.West },
            { "N", Direction.North },
            { "E", Direction.East },
            { "S", Direction.South }
        };

        static void Main(string[] args)
        {
            var service = new CommandService();

            while (true)
            {
                BeginningProcessStart(out int xRange, out int yRange, out int startX, out int startY, out string startDirection, out List<char> commands);

                var plateau = new Plateau(xRange, yRange);

                plateau.Create();

                // We have already created all coordinates while was creating plateau, so we can get robot's coordinate from there
                var robotCoordinate = plateau.Coordinates
                    .Where(d => d.X == startX && d.Y == startY)
                    .FirstOrDefault();

                if (robotCoordinate == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You can not move to the coordinate which is out of Mars!");
                    continue;
                }

                var robotDirection = _directionWithSymbol
                    .Where(x => x.Key.ToUpper() == startDirection)
                    .Select(x => x.Value).First();

                var robot = new Robot
                {
                    Coordinate = robotCoordinate,
                    Direction = robotDirection
                };

                var result = service.Run(robot, plateau, commands);

                ProcessCommandRunResult(result, robot);
            }
        }

        private static void ProcessCommandRunResult(ServiceResult result, Robot robot)
        {
            if (!result.Status)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine($"{robot.Coordinate.X} {robot.Coordinate.Y} {_directionWithSymbol.FirstOrDefault(x => x.Value == robot.Direction).Key}");
            }
        }

        /// <summary>
        /// Beginning process start
        /// </summary>
        private static void BeginningProcessStart(out int xRange, out int yRange, out int startX, out int startY, out string startDirection, out List<char> commands)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Please give any X and Y numbers separated by space for Mars surface area.");

            var xAndyRangeAsString = Console.ReadLine();

            xRange = Convert.ToInt32(xAndyRangeAsString.Split(" ")[0]);
            yRange = Convert.ToInt32(xAndyRangeAsString.Split(" ")[1]);

            Console.WriteLine("Please give coordinate numbers and direction values separated by space for Rover.");
            var roverBeginningInfo = Console.ReadLine();

            startX = Convert.ToInt32(roverBeginningInfo.Split(" ")[0]);
            startY = Convert.ToInt32(roverBeginningInfo.Split(" ")[1]);
            startDirection = roverBeginningInfo.Split(" ")[2].ToUpper();

            Console.WriteLine("Please give your commands for Rover.");
            commands = Console.ReadLine().ToCharArray().ToList();
        }
    }
}