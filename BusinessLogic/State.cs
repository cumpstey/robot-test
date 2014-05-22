namespace RobotTest.BusinessLogic
{
    /// <summary>
    /// Representation of the current state of a robot,
    /// indicating its position on the grid and current
    /// direction
    /// </summary>
    public struct State
    {
        #region Fields

        public MoveDirection Direction;

        public Coordinate Coordinate;

        #endregion

        #region Constructor

        public State(MoveDirection direction, Coordinate coordinate)
        {
            Direction = direction;
            Coordinate = coordinate;
        }

        #endregion
    }
}
