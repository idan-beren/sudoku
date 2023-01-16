using System;
namespace sudoku.exceptions
{
    // class of duplication in row, column or cell in the sudoku grid
	public class DuplicateValueException : Exception
	{
        // constructor
        public DuplicateValueException()
            : base($"Duplicated value in one of the rows, columns or subgrids\n")
        {
        }
    }
}
