namespace RobotTest.BusinessLogic.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Utilities.Logging;

    [TestClass]
    public class GridTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CantCreateGridWithXLessThanOne()
        {
            var grid = new Grid(0, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CantCreateGridWithYLessThanOne()
        {
            var grid = new Grid(1, 0);
        }
    }
}
