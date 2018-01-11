namespace RobotTest.UI.Tests
{
    using System;
    using BusinessLogic.Commands;
    using CommandParsing;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RobotTest.UI.Tests.Commands;
    using UI.CommandParsing;
    using Utilities.Logging;

    [TestClass]
    public class TextCommandParserTests
    {
        [TestMethod]
        public void ParsePlaceCommand()
        {
            var logger = new NullLogger();
            var commandParser = new TextCommandParser(logger);

            var input = "PLACE 3,3,NORTH";
            var command = commandParser.ParseCommand(input);
            Assert.IsInstanceOfType(command, typeof(PlaceCommand));

            input = "place 1, 2,East";
            command = commandParser.ParseCommand(input);
            Assert.IsInstanceOfType(command, typeof(PlaceCommand));

            input = "place 1,2,East,";
            command = commandParser.ParseCommand(input);
            Assert.IsNull(command);

            input = "place 1;2;East";
            command = commandParser.ParseCommand(input);
            Assert.IsNull(command);
        }

        [TestMethod]
        public void ParseMoveCommand()
        {
            var logger = new NullLogger();
            var commandParser = new TextCommandParser(logger);

            var input = "MOVE";
            var command = commandParser.ParseCommand(input);
            Assert.IsInstanceOfType(command, typeof(MoveCommand));

            input = "move";
            command = commandParser.ParseCommand(input);
            Assert.IsInstanceOfType(command, typeof(MoveCommand));

            input = "move 1";
            command = commandParser.ParseCommand(input);
            Assert.IsNull(command);
        }

        [TestMethod]
        public void ParseRotateCommand()
        {
            var logger = new NullLogger();
            var commandParser = new TextCommandParser(logger);

            var input = "LEFT";
            var command = commandParser.ParseCommand(input);
            Assert.IsInstanceOfType(command, typeof(RotateCommand));

            input = "left";
            command = commandParser.ParseCommand(input);
            Assert.IsInstanceOfType(command, typeof(RotateCommand));

            input = "left 1";
            command = commandParser.ParseCommand(input);
            Assert.IsNull(command);

            input = "RIGHT";
            command = commandParser.ParseCommand(input);
            Assert.IsInstanceOfType(command, typeof(RotateCommand));

            input = "right";
            command = commandParser.ParseCommand(input);
            Assert.IsInstanceOfType(command, typeof(RotateCommand));

            input = "right 1";
            command = commandParser.ParseCommand(input);
            Assert.IsNull(command);
        }

        [TestMethod]
        public void ParseReportCommand()
        {
            var logger = new NullLogger();
            var commandParser = new TextCommandParser(logger);

            var input = "REPORT";
            var command = commandParser.ParseCommand(input);
            Assert.IsInstanceOfType(command, typeof(ReportCommand));

            input = "report";
            command = commandParser.ParseCommand(input);
            Assert.IsInstanceOfType(command, typeof(ReportCommand));

            input = "report 1";
            command = commandParser.ParseCommand(input);
            Assert.IsNull(command);
        }

        [TestMethod]
        public void ParseUnrecognisedCommand()
        {
            var logger = new NullLogger();
            var commandParser = new TextCommandParser(logger);

            string input = null;
            var command = commandParser.ParseCommand(input);
            Assert.IsNull(command);

            input = "   ";
            command = commandParser.ParseCommand(input);
            Assert.IsNull(command);

            input = "blurb";
            command = commandParser.ParseCommand(input);
            Assert.IsNull(command);
        }

        [TestMethod]
        public void RegisterAndParseCustomCommand()
        {
            var logger = new NullLogger();
            var commandParser = new TextCommandParser(logger);
            commandParser.RegisterParser("unplace", IndividualCommandParsers.ParseUnplaceCommand);

            var input = "UNPLACE";
            var command = commandParser.ParseCommand(input);
            Assert.IsInstanceOfType(command, typeof(UnplaceCommand));

            input = "unplace";
            command = commandParser.ParseCommand(input);
            Assert.IsInstanceOfType(command, typeof(UnplaceCommand));

            input = "unplace 1";
            command = commandParser.ParseCommand(input);
            Assert.IsNull(command);
        }
    }
}
