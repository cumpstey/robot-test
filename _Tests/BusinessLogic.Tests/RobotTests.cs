namespace RobotTest.BusinessLogic.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Utilities.Logging;

    [TestClass]
    public class RobotTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CantCreateRobotWithoutLogger()
        {
            ILogger logger = null;
            var grid = new Grid(1, 1);

            var robot = new Robot(logger, grid);
        }

        [TestMethod]
        public void CanCreateRobotWithLogger()
        {
            ILogger logger = new NullLogger();
            var grid = new Grid(1, 1);

            Assert.IsInstanceOfType(new Robot(logger, grid), typeof(Robot));
        }
    }
}
