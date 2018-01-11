using Microsoft.Extensions.Logging;
using RobotTest.BusinessLogic;
using RobotTest.BusinessLogic.Commands;

namespace RobotTest.UI.Tests.Commands
{
    /// <summary>
    /// Class representing a command for the robot to remove itself from the grid
    /// </summary>
    public class UnplaceCommand : Command
    {
        #region Methods

        public override State? Execute(ILogger logger, State? currentState, Grid grid)
        {
            return null;
        }

        #endregion
    }
}
