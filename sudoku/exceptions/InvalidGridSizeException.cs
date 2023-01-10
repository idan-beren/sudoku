using System;
namespace sudoku.exceptions
{
    public class InvalidGridSizeException : Exception
    {
        public InvalidGridSizeException()
            : base($"Invalid grid size")
        {
        }
    }
}

