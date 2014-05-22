namespace RobotTest.BusinessLogic.Tests
{
    using System;
    using BusinessLogic.Commands;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Utilities.Logging;

    [TestClass]
    public class MoveCommandTests
    {
        [TestMethod]
        public void MovesNorthWhenNotAtEdge()
        {
            MovesWhenNotAtEdge(new State(MoveDirection.North, new Coordinate(3, 3)), new Coordinate(3, 4));
        }

        [TestMethod]
        public void MovesEastWhenNotAtEdge()
        {
            MovesWhenNotAtEdge(new State(MoveDirection.East, new Coordinate(3, 3)), new Coordinate(4, 3));
        }

        [TestMethod]
        public void MovesSouthWhenNotAtEdge()
        {
            MovesWhenNotAtEdge(new State(MoveDirection.South, new Coordinate(3, 3)), new Coordinate(3, 2));
        }

        [TestMethod]
        public void MovesWestWhenNotAtEdge()
        {
            MovesWhenNotAtEdge(new State(MoveDirection.West, new Coordinate(3, 3)), new Coordinate(2, 3));
        }

        private void MovesWhenNotAtEdge(State? state, Coordinate expected)
        {
            ILogger logger = new NullLogger();
            var grid = new Grid(5, 5);
            var command = new MoveCommand();

            state = command.Execute(state, grid, logger);
            Assert.AreEqual(expected, state.Value.Coordinate);
        }

        [TestMethod]
        public void DoesNotMoveNorthWhenAtEdge()
        {
            DoesNotMoveWhenAtEdge(new State(MoveDirection.North, new Coordinate(3, 4)));
        }

        [TestMethod]
        public void DoesNotMoveEastWhenAtEdge()
        {
            DoesNotMoveWhenAtEdge(new State(MoveDirection.East, new Coordinate(4, 3)));
        }

        [TestMethod]
        public void DoesNotMoveSouthWhenAtEdge()
        {
            DoesNotMoveWhenAtEdge(new State(MoveDirection.South, new Coordinate(3, 0)));
        }

        [TestMethod]
        public void DoesNotMoveWestWhenAtEdge()
        {
            DoesNotMoveWhenAtEdge(new State(MoveDirection.West, new Coordinate(0, 3)));
        }

        private void DoesNotMoveWhenAtEdge(State? state)
        {
            var expected = state.Value.Coordinate;

            ILogger logger = new NullLogger();
            var grid = new Grid(5, 5);
            var command = new MoveCommand();

            state = command.Execute(state, grid, logger);
            Assert.AreEqual(expected, state.Value.Coordinate);
        }
    }
}
