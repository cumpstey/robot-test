namespace RobotTest.Utilities.Logging
{
    public interface ILogger
    {
        /// <summary>
        /// Log the message with the specified level
        /// </summary>
        /// <param name="level">Level of the message</param>
        /// <param name="message">Message</param>
        void Log(LogLevel level, string message);
    }
}
