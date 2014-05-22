namespace RobotTest.BusinessLogic
{
    using System;
    using Commands;
    using Utilities.Logging;

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

        public Robot(ILogger logger, Grid grid)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }

            _logger = logger;
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
            _state = command.Execute(_state, _grid, _logger);
        }

        #endregion
    }
}
