namespace RobotTest.UI.Tests.CommandParsing
{
    using BusinessLogic.Commands;
    using Commands;

    public static class IndividualCommandParsers
    {
        public static Command ParseUnplaceCommand(string argumentString)
        {
            return string.IsNullOrEmpty(argumentString) ? new UnplaceCommand() : null;
        }
    }
}
