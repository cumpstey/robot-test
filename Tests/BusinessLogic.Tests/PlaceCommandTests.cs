namespace RobotTest.BusinessLogic.Tests
{
    using System;
    using BusinessLogic.Commands;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Utilities.Logging;

    [TestClass]
    public class PlaceCommandTests
    {
        [TestMethod]
        public void IsPlacedOnGrid()
        {
            ILogger logger = new NullLogger();
            var grid = new Grid(5, 5);
            State? state = null;
            var command = new PlaceCommand(3, 3, MoveDirection.East);

            state = command.Execute(state, grid, logger);
            Assert.AreEqual(MoveDirection.East, state.Value.Direction);
            Assert.AreEqual(3, state.Value.Coordinate.X);
            Assert.AreEqual(3, state.Value.Coordinate.Y);
        }

        [TestMethod]
        public void IsNotPlacedOutOfBoundsOfGrid()
        {
            ILogger logger = new NullLogger();
            var grid = new Grid(5, 5);
            State? state = null;
            var command = new PlaceCommand(5, 3, MoveDirection.East);

            state = command.Execute(state, grid, logger);
            Assert.IsFalse(state.HasValue);
        }
    }
}
