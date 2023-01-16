using System;
namespace sudoku.exceptions
{
    // class of invalid size of the sudoku grid
    public class InvalidGridSizeException : Exception
    {
        // constructor
        public InvalidGridSizeException()
            : base($"Invalid grid size\n")
        {
        }
    }
}
