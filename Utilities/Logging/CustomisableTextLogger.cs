namespace RobotTest.Utilities.Logging
{
    using System;

    /// <summary>
    /// Logger which formats the messages for logging, but allows the actual logging to be handled elsewhere
    /// </summary>
    public class CustomisableTextLogger : ILogger
    {
        #region Fields

        private Action<string> _action;

        #endregion

        #region Constructor

        public CustomisableTextLogger(Action<string> action)
        {
            _action = action;
        }

        #endregion

        #region Methods

        public void Log(LogLevel level, string message)
        {
            if (_action == null)
            {
                return;
            }

            var formattedMessage = level == LogLevel.Info ? message : string.Concat(level, ": ", message);
            _action(formattedMessage);
        }

        #endregion
    }
}
