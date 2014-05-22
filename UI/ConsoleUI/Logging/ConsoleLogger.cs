namespace RobotTest.UI.ConsoleUI.Logging
{
    using System;
    using Utilities.Logging;
    using LogLevel = Utilities.Logging.LogLevel;

    /// <summary>
    /// Logger which logs messages to the console
    /// </summary>
    public class ConsoleLogger : CustomisableTextLogger
    {
        public ConsoleLogger()
            : base(Console.WriteLine)
        { 
        }
    }
}
