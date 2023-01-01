using System;
namespace sudoku.exceptions
{
    public class InvalidCharacterException : Exception
    {
        public InvalidCharacterException(char character, int index)
            : base($"Invalid character {character} at index {index} in string input")
        {
        }
    }
}
