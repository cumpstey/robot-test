namespace RobotTest.BusinessLogic.Commands
{
    using System;
    using Utilities.Logging;

    /// <summary>
    /// Class representing a command for the robot to rotate left or right
    /// </summary>
    public class RotateCommand : Command
    {
        #region Constructor

        public RotateCommand(RotateDirection direction)
        {
            Direction = direction;
        }

        #endregion

        #region Properties

        public RotateDirection Direction { get; private set; }

        #endregion

        #region Methods

        public override State? Execute(State? currentState, Grid grid, ILogger logger)
        {
            if (!currentState.HasValue)
            {
                logger.Log(LogLevel.Warning, "Rotate command executed when robot not placed.");
                return currentState;
            }

            var directionCount = Enum.GetValues(typeof(MoveDirection)).Length;
            var newDirection = (MoveDirection)(((int)currentState.Value.Direction + (int)Direction + directionCount) % directionCount);
            return new State(newDirection, currentState.Value.Coordinate);
        }

        #endregion
    }
}
