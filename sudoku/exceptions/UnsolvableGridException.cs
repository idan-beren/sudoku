using System;
namespace sudoku.exceptions
{
    public class UnsolvableGridException : Exception
    {
        public UnsolvableGridException()
            : base($"\nunsolvable grid\n")
        {
        }
    }
}
