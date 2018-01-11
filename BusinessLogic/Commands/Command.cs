using Microsoft.Extensions.Logging;

namespace RobotTest.BusinessLogic.Commands
{

    public abstract class Command
    {
        /// <summary>
        /// Executes this command on the provided <see cref="State"/>
        /// </summary>
        /// <param name="currentState">Current state</param>
        /// <param name="grid">Grid</param>
        /// <param name="logger">Logger</param>
        /// <returns>New state</returns>
        public abstract State? Execute(ILogger logger, State? currentState, Grid grid);
    }
}
