﻿using RobotTest.BusinessLogic.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Logging;

namespace RobotTest.BusinessLogic.Tests
{
    [TestClass]
    public class RotateCommandTests
    {
        [TestMethod]
        public void Rotates()
        {
            ILogger logger = new NullLogger<object>();
            var grid = new Grid(5, 5);
            State? state = new State(MoveDirection.East, new Coordinate(1, 3));
            var command = new RotateCommand(RotateDirection.Left);

            state = command.Execute(logger, state, grid);
            Assert.AreEqual(MoveDirection.North, state.Value.Direction);
            Assert.AreEqual(1, state.Value.Coordinate.X);
            Assert.AreEqual(3, state.Value.Coordinate.Y);

            state = command.Execute(logger, state, grid);
            Assert.AreEqual(MoveDirection.West, state.Value.Direction);

            command = new RotateCommand(RotateDirection.Right);

            state = command.Execute(logger, state, grid);
            Assert.AreEqual(MoveDirection.North, state.Value.Direction);

            state = command.Execute(logger, state, grid);
            Assert.AreEqual(MoveDirection.East, state.Value.Direction);
            Assert.AreEqual(1, state.Value.Coordinate.X);
            Assert.AreEqual(3, state.Value.Coordinate.Y);
        }
    }
}
