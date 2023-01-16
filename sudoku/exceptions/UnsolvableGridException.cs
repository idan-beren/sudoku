using System;
namespace sudoku.exceptions
{
    // class of an unsolable grid exception
    public class UnsolvableGridException : Exception
    {
        // constructor
        public UnsolvableGridException()
            : base($"\nunsolvable grid\n")
        {
        }
    }
}
