using System;
using Microsoft.Extensions.Logging;

namespace RobotTest.BusinessLogic.Commands
{
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

        public override State? Execute(ILogger logger, State? currentState, Grid grid)
        {
            if (!currentState.HasValue)
            {
                logger.LogWarning("Rotate command executed when robot not placed.");
                return currentState;
            }

            var directionCount = Enum.GetValues(typeof(MoveDirection)).Length;
            var newDirection = (MoveDirection)(((int)currentState.Value.Direction + (int)Direction + directionCount) % directionCount);
            return new State(newDirection, currentState.Value.Coordinate);
        }

        #endregion
    }
}
