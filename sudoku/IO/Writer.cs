using System;
using sudoku.board;

namespace sudoku.IO
{
	public class Writer
	{
        /* gets a grid object and prints it into the console*/
		public void writeGrid(Grid grid)
		{
            Console.WriteLine();
            for (int row = 0; row < grid.rowSize; row++)
            {
                for (int col = 0; col < grid.colSize; col++)
                {
                    Console.Write(" " + grid.Cells[row, col].Value);
                    if ((col + 1) % grid.subgridSize == 0) Console.Write(" ");
                }
                Console.WriteLine();
                if ((row + 1) % grid.subgridSize == 0) Console.WriteLine();
            }
        }
	}
}
