using System;

namespace sudoku.IO
{
    public class ConsoleWriter : IWriter
    {
        /* gets a solution string grid and prints in into the console */
        public void WriteOutput(string output)
        {
            Console.WriteLine("\n" + output);
        }

        /* gets a sudoku grid and prints it into the console */
        public void WriteGrid(byte[,] grid)
        {
            int gridSize = grid.GetLength(0);
            int subgridSize = (int)Math.Sqrt(gridSize);
            Console.WriteLine();
            for (int row = 0; row < gridSize; row++)
            {
                for (int col = 0; col < gridSize; col++)
                {
                    Console.Write(" " + (char)(grid[row, col] + '0'));
                    if ((col + 1) % subgridSize == 0) Console.Write(" ");
                }
                Console.WriteLine();
                if ((row + 1) % subgridSize == 0) Console.WriteLine();
            }
        }
    }
}
