using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using RobotTest.BusinessLogic;
using RobotTest.BusinessLogic.Commands;

namespace RobotTest.UI.CommandParsing
{
    public class TextCommandParser
    {
        #region Fields

        private readonly ILogger _logger;

        private readonly Dictionary<string, IndividualCommandParser> _parsers;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new instance of the text command parser
        /// </summary>
        /// <param name="logger">Logger</param>
        /// <param name="registerDefaultParsers">
        /// Registers the parsers for the default commands:
        /// LEFT
        /// MOVE
        /// PLACE x,y,DIRECTION
        /// REPORT
        /// RIGHT
        /// </param>
        public TextCommandParser(ILogger<TextCommandParser> logger, bool registerDefaultParsers = true)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _parsers = new Dictionary<string, IndividualCommandParser>();

            if (registerDefaultParsers)
            {
                RegisterParser("left", ParseLeftCommand);
                RegisterParser("move", ParseMoveCommand);
                RegisterParser("place", ParsePlaceCommand);
                RegisterParser("report", ParseReportCommand);
                RegisterParser("right", ParseRightCommand);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns all registered commands
        /// </summary>
        /// <returns>All registered command names</returns>
        public IEnumerable<string> GetRegisteredCommands()
        {
            return _parsers.Keys;
        }

        /// <summary>
        /// Registers a parser for the given command name.
        /// If a parser for the specified command name was already defined, it will be replaced
        /// </summary>
        /// <param name="commandName">Command name</param>
        /// <param name="parser">Parser</param>
        public void RegisterParser(string commandName, IndividualCommandParser parser)
        {
            if (string.IsNullOrWhiteSpace(commandName))
            {
                throw new ArgumentException("commandName cannot be empty", nameof(commandName));
            }

            _parsers[commandName] = parser ?? throw new ArgumentNullException(nameof(parser));
        }

        /// <summary>
        /// Parse command using the defined parsers. Command name parsing is case insensitive.
        /// </summary>
        /// <param name="input">Command text</param>
        /// <returns>Parsed command; null if parsing fails</returns>
        public Command ParseCommand(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                _logger.LogWarning("Cannot parse empty command");
                return null;
            }

            var formattedInput = input.ToLower();
            var commandName = formattedInput.Contains(' ') ? formattedInput.Substring(0, formattedInput.IndexOf(' ')) : formattedInput;

            if (_parsers.ContainsKey(commandName))
            {
                var commandArgumentsString = formattedInput.Contains(' ') ? formattedInput.Substring(formattedInput.IndexOf(' ')) : null;
                var command = _parsers[commandName](commandArgumentsString);
                if (command == null)
                {
                    _logger.LogWarning($"Failed to parse command '{commandName}'");
                }

                return command;
            }

            _logger.LogWarning($"No parser registered for '{commandName}'");
            return null;
        }

        #endregion

        #region Default parsers

        public Command ParseLeftCommand(string argumentString)
        {
            return string.IsNullOrEmpty(argumentString) ? new RotateCommand(RotateDirection.Left) : null;
        }

        public Command ParseMoveCommand(string argumentString)
        {
            return string.IsNullOrEmpty(argumentString) ? new MoveCommand() : null;
        }

        public Command ParsePlaceCommand(string argumentString)
        {
            if (argumentString == null)
            {
                return null;
            }

            var arguments = argumentString.Split(',').Select(i => i.Trim()).ToArray();
            if (arguments.Length != 3)
            {
                return null;
            }

            if (int.TryParse(arguments[0], out int x)
                && int.TryParse(arguments[1], out int y)
                && Enum.TryParse(arguments[2], true, out MoveDirection direction))
            {
                return new PlaceCommand(x, y, direction);
            }

            return null;
        }

        public Command ParseReportCommand(string argumentString)
        {
            return string.IsNullOrEmpty(argumentString) ? new ReportCommand() : null;
        }

        public Command ParseRightCommand(string argumentString)
        {
            return string.IsNullOrEmpty(argumentString) ? new RotateCommand(RotateDirection.Right) : null;
        }

        #endregion
    }
}
