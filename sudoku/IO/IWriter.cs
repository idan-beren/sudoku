using System;

namespace sudoku.IO
{
    // writer interface
    public interface IWriter
    {
        // writes the output to the user
        public void WriteOutput(string output);
    }
}
