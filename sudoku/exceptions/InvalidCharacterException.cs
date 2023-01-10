using System;
namespace sudoku.exceptions
{
    public class InvalidCharacterException : Exception
    {
        public InvalidCharacterException()
            : base($"Invalid character in the string input")
        {
        }
    }
}
