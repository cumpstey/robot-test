namespace RobotTest.BusinessLogic.Commands
{
    using Utilities.Logging;

    public abstract class Command
    {
        /// <summary>
        /// Executes this command on the provided <see cref="State"/>
        /// </summary>
        /// <param name="currentState">Current state</param>
        /// <param name="grid">Grid</param>
        /// <param name="logger">Logger</param>
        /// <returns>New state</returns>
        public abstract State? Execute(State? currentState, Grid grid, ILogger logger);
    }
}
