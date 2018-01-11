using Microsoft.Extensions.Logging;

namespace RobotTest.BusinessLogic.Commands
{
    /// <summary>
    /// Class representing a command for the robot to be placed on the grid
    /// </summary>
    public class PlaceCommand : Command
    {
        #region Constructor

        public PlaceCommand(int x, int y, MoveDirection direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }

        #endregion

        #region Properties

        public int X { get; private set; }

        public int Y { get; private set; }

        public MoveDirection Direction { get; private set; }

        #endregion

        #region Methods

        public override State? Execute(ILogger logger, State? currentState, Grid grid)
        {
            if (X >= 0 && X < grid.X && Y >= 0 && Y < grid.Y)
            {
                return new State(Direction, new Coordinate(X, Y));
            }

            logger.LogWarning("Placed outside the bounds of the grid. Ignoring command.");
            return currentState;
        }

        #endregion
    }
}
