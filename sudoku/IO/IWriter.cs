using System;

namespace sudoku.IO
{
	public interface IWriter
	{
        // writes the solution to the user
        public void WriteGrid(byte[,] grid);
    }
}
