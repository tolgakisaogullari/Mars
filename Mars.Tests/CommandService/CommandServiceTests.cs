using FluentAssertions;
using Mars.Models.Entities;
using Mars.Models.Enums;
using Mars.Services;
using NUnit.Framework;
using System.Linq;

namespace Mars.Tests
{
    [TestFixture]
    public class CommandServiceTests
    {
        //1 2 N
        //LMLMLMLMM
        //Expect: 1 3 N
        [Test]
        public void Should_Be_Success_For_First_Condition()
        {
            var commandService = new CommandService();

            var robot = new Robot
            {
                Coordinate = new Coordinate(1, 2),
                Direction = Direction.North
            };

            var plateau = new Plateau(5, 5);

            var commands = "LMLMLMLMM".ToCharArray().ToList();

            var result = commandService.Run(robot, plateau, commands);

            result.Status.Should().BeTrue();

            robot.Coordinate.X.Should().Be(1);
            robot.Coordinate.Y.Should().Be(3);
            robot.Direction.Should().Be(Direction.North);
        }

        //3 3 E
        //MMRMMRMRRM
        //Expect: 5 1 E
        [Test]
        public void Should_Be_Success_For_Second_Condition()
        {
            var commandService = new CommandService();

            var robot = new Robot
            {
                Coordinate = new Coordinate(3, 3),
                Direction = Direction.East
            };

            var plateau = new Plateau(5, 5);

            var commands = "MMRMMRMRRM".ToCharArray().ToList();

            var result = commandService.Run(robot, plateau, commands);

            result.Status.Should().BeTrue();
            robot.Coordinate.X.Should().Be(5);
            robot.Coordinate.Y.Should().Be(1);
            robot.Direction.Should().Be(Direction.East);
        }

        //0 0 W
        //MMMMM
        //Expect: Error. Out of planeau
        [Test]
        public void Should_Be_Fail_If_RobotCoordinate_Does_Not_Exist()
        {
            var commandService = new CommandService();

            var robot = new Robot
            {
                Coordinate = new Coordinate(0, 0),
                Direction = Direction.West
            };

            var plateau = new Plateau(5, 5);
            plateau.Create();

            var commands = "MMMMMM".ToCharArray().ToList();

            var result = commandService.Run(robot, plateau, commands);

            result.Status.Should().BeFalse();
            result.Message.Should().Be($"The coordinate that you want to move on is out of Mars so you can not move further on {Direction.West} side.");
        }
    }
}
