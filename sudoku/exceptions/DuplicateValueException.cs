using System;
namespace sudoku.exceptions
{
	public class DuplicateValueException : Exception
	{
        public DuplicateValueException()
            : base($"Duplicated value in one of the rows, columns or subgrids")
        {
        }
    }
}

