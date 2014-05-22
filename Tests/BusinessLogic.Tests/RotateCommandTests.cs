namespace RobotTest.BusinessLogic.Tests
{
    using System;
    using BusinessLogic.Commands;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Utilities.Logging;

    [TestClass]
    public class RotateCommandTests
    {
        [TestMethod]
        public void Rotates()
        {
            ILogger logger = new NullLogger();
            var grid = new Grid(5, 5);
            State? state = new State(MoveDirection.East, new Coordinate(1, 3));
            var command = new RotateCommand(RotateDirection.Left);

            state = command.Execute(state, grid, logger);
            Assert.AreEqual(MoveDirection.North, state.Value.Direction);
            Assert.AreEqual(1, state.Value.Coordinate.X);
            Assert.AreEqual(3, state.Value.Coordinate.Y);

            state = command.Execute(state, grid, logger);
            Assert.AreEqual(MoveDirection.West, state.Value.Direction);

            command = new RotateCommand(RotateDirection.Right);

            state = command.Execute(state, grid, logger);
            Assert.AreEqual(MoveDirection.North, state.Value.Direction);

            state = command.Execute(state, grid, logger);
            Assert.AreEqual(MoveDirection.East, state.Value.Direction);
            Assert.AreEqual(1, state.Value.Coordinate.X);
            Assert.AreEqual(3, state.Value.Coordinate.Y);
        }
    }
}
