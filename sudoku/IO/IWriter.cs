using System;

namespace sudoku.IO
{
    public interface IWriter
    {
        // writes the output to the user
        public void WriteOutput(string output);
    }
}
