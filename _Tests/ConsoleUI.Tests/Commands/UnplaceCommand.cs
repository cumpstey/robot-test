namespace RobotTest.UI.Tests.Commands
{
    using BusinessLogic;
    using BusinessLogic.Commands;
    using Utilities.Logging;

    /// <summary>
    /// Class representing a command for the robot to remove itself from the grid
    /// </summary>
    public class UnplaceCommand : Command
    {
        #region Methods

        public override State? Execute(State? currentState, Grid grid, ILogger logger)
        {
            return null;
        }

        #endregion
    }
}
