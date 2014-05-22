namespace RobotTest.BusinessLogic.Tests
{
    using System;
    using BusinessLogic.Commands;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Utilities.Logging;

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
            state = command.Execute(state, grid, logger);

            command = new ReportCommand();
            state = command.Execute(state, grid, logger);

            Assert.AreEqual("3,3,East", output);
        }

        [TestMethod]
        public void ReportsErrorWhenNotPlaced()
        {
            string output = null;
            ILogger logger = new CustomisableTextLogger(delegate(string message)
            {
                output = message;
            });
            var grid = new Grid(5, 5);
            State? state = null;

            var command = new ReportCommand();
            state = command.Execute(state, grid, logger);

            Assert.IsTrue(output != null && output.StartsWith("Error:"));
        }
    }
}
