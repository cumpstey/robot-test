﻿using RobotTest.BusinessLogic.Commands;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RobotTest.BusinessLogic.Tests
{
    [TestClass]
    public class ReportCommandTests
    {
        [TestMethod]
        public void ReportsPositionWhenPlaced()
        {
            string output = null;
            ILogger logger = new CustomisableTextLogger(delegate(string message)
            {
                output = message;
            });
            var grid = new Grid(5, 5);
            State? state = null;

            Command command = new PlaceCommand(3, 3, MoveDirection.East);
            state = command.Execute(logger, state, grid);

            command = new ReportCommand();
            state = command.Execute(logger, state, grid);

            Assert.AreEqual("3,3,East", output);
        }

        [TestMethod]
        public void ReportsWarningWhenNotPlaced()
        {
            string output = null;
            ILogger logger = new CustomisableTextLogger(delegate(string message)
            {
                output = message;
            });
            var grid = new Grid(5, 5);
            State? state = null;

            var command = new ReportCommand();
            state = command.Execute(logger, state, grid);

            Assert.IsTrue(output != null && output.StartsWith("Warning:"));
        }
    }
}
