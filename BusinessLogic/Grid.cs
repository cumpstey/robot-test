namespace RobotTest.BusinessLogic
{
    using System;

    /// <summary>
    /// Representation of a two dimensional grid on which a robot can be placed
    /// </summary>
    public class Grid
    {
        #region Constructor

        public Grid(int x, int y)
        {
            if (x <= 0)
            {
                throw new ArgumentException("x must be positive.", nameof(x));
            }

            if (y <= 0)
            {
                throw new ArgumentException("y must be positive.", nameof(y));
            }

            X = x;
            Y = y;
        }

        #endregion

        #region Properties

        public int X { get; private set; }

        public int Y { get; private set; }

        #endregion
    }
}
