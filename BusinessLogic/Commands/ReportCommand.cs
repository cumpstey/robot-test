using Microsoft.Extensions.Logging;

namespace RobotTest.BusinessLogic.Commands
{
    /// <summary>
    /// Class representing a command for the robot to report its position
    /// </summary>
    public class ReportCommand : Command
    {
        #region Methods

        public override State? Execute(ILogger logger, State? currentState, Grid grid)
        {
            if (!currentState.HasValue)
            {
                logger.LogWarning("Report command executed when robot not placed.");
                return currentState;
            }

            logger.LogInformation(string.Format("{0},{1},{2}", currentState.Value.Coordinate.X, currentState.Value.Coordinate.Y, currentState.Value.Direction));
            return currentState;
        }

        #endregion
    }
}
