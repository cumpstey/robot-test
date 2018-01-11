using System;
using Microsoft.Extensions.Logging;
using RobotTest.BusinessLogic.Commands;

namespace RobotTest.BusinessLogic
{
    /// <summary>
    /// Class representing a robot, with a grid which it can be placed on,
    /// and with the ability to report messages and execute commands.
    /// </summary>
    public class Robot
    {
        #region Fields

        private ILogger _logger;

        private Grid _grid;

        private State? _state;

        #endregion

        #region Constructor

        public Robot(ILogger<Robot> logger, Grid grid)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _grid = grid;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Executes the provided command on the robot's current state
        /// </summary>
        /// <param name="command">Command to execute</param>
        public void ExecuteCommand(Command command)
        {
            _state = command.Execute(_logger, _state, _grid);
        }

        #endregion
    }
}
