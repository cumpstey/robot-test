﻿using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RobotTest.BusinessLogic.Tests
{
    [TestClass]
    public class RobotTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CantCreateRobotWithoutLogger()
        {
            ILogger<Robot> logger = null;
            var grid = new Grid(1, 1);

            var robot = new Robot(logger, grid);
        }

        [TestMethod]
        public void CanCreateRobotWithLogger()
        {
            var logger = new NullLogger<Robot>();
            var grid = new Grid(1, 1);

            Assert.IsInstanceOfType(new Robot(logger, grid), typeof(Robot));
        }
    }
}
