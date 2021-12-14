using Mars.Common;
using System.Collections.Generic;

namespace Mars.Services
{
    public interface ICommandService
    {
        /// <summary>
        /// Runs given commands for robot
        /// </summary>
        ServiceResult Run(Robot robot, Plateau plateau, List<char> commands);
    }
}
