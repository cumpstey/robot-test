using System;
using Microsoft.Extensions.Logging;

namespace RobotTest.BusinessLogic.Commands
{
    /// <summary>
    /// Class representing a command for the robot to move
    /// </summary>
    public class MoveCommand : Command
    {
        #region Methods

        public override State? Execute(ILogger logger, State? currentState, Grid grid)
        {
            if (!currentState.HasValue)
            {
                logger.LogWarning("Move command executed when robot not placed.");
                return currentState;
            }

            var movement = new Tuple<int, int>(0, 0);
            switch (currentState.Value.Direction)
            {
                case MoveDirection.North:
                    movement = new Tuple<int, int>(0, 1);
                    break;
                case MoveDirection.East:
                    movement = new Tuple<int, int>(1, 0);
                    break;
                case MoveDirection.South:
                    movement = new Tuple<int, int>(0, -1);
                    break;
                case MoveDirection.West:
                    movement = new Tuple<int, int>(-1, 0);
                    break;
            }

            var state = new State(currentState.Value.Direction, new Coordinate(currentState.Value.Coordinate.X + movement.Item1, currentState.Value.Coordinate.Y + movement.Item2));
            if (state.Coordinate.X >= 0 && state.Coordinate.X < grid.X && state.Coordinate.Y >= 0 && state.Coordinate.Y < grid.Y)
            {
                return state;
            }

            return currentState;
        }

        #endregion
    }
}
