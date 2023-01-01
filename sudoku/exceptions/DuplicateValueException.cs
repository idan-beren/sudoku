using System;
namespace sudoku.exceptions
{
	public class DuplicateValueException : Exception
	{
        public DuplicateValueException(int row, int col)
            : base($"Duplicated value in position ({row}, {col})")
        {
        }
    }
}
