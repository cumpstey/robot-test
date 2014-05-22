namespace RobotTest.Utilities.Logging
{
    using Utilities.Logging;

    /// <summary>
    /// Logger which doesn't log the messages anywhere
    /// </summary>
    public class NullLogger : CustomisableTextLogger
    {
        public NullLogger()
            : base(null)
        {
        }
    }
}
