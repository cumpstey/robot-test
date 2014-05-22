namespace RobotTest.BusinessLogic
{
    using System;

    /// <summary>
    /// Representation of a two dimensional grid on which a robot can be placed
    /// </summary>
    public struct Grid
    {
        #region Fields

        public int X;

        public int Y;

        #endregion

        #region Constructor

        public Grid(int x, int y)
        {
            if (x <= 0)
            {
                throw new ArgumentException("x must be positive.", "x");
            }

            if (y <= 0)
            {
                throw new ArgumentException("y must be positive.", "y");
            }

            X = x;
            Y = y;
        }

        #endregion
    }
}
