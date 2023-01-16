using System;
namespace sudoku.exceptions
{
    // class of invalid characters in the input
    public class InvalidCharacterException : Exception
    {
        // constructor
        public InvalidCharacterException()
            : base($"Invalid character in the string input\n")
        {
        }
    }
}
