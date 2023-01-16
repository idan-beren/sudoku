using System;
namespace sudoku.IO
{
    // reader interface
    public interface IReader
    {
        // gets an input from the user. returns the input.
        public string ReadInput();
    }
}
