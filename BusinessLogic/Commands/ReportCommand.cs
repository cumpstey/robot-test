namespace RobotTest.BusinessLogic.Commands
{
    using Utilities.Logging;

    /// <summary>
    /// Class representing a command for the robot to report its position
    /// </summary>
    public class ReportCommand : Command
    {
        #region Methods

        public override State? Execute(State? currentState, Grid grid, ILogger logger)
        {
            if (!currentState.HasValue)
            {
                logger.Log(LogLevel.Warning, "Report command executed when robot not placed.");
                return currentState;
            }

            logger.Log(LogLevel.Info, string.Format("{0},{1},{2}", currentState.Value.Coordinate.X, currentState.Value.Coordinate.Y, currentState.Value.Direction));
            return currentState;
        }

        #endregion
    }
}
