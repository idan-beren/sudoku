using System;

namespace sudoku.IO
{
	public class FileWriter : IWriter
	{
        /* gets a grid object and prints it into a file*/
        public void WriteGrid(byte[,] grid)
		{
			string path = "/Users/idan.beren/Projects/sudoku/sudoku/solutions/result.txt";
            using (StreamWriter sw = new StreamWriter(path))
            {
                int gridSize = grid.GetLength(0);
                int subgridSize = (int)Math.Sqrt(gridSize);
                Console.WriteLine();
                for (int row = 0; row < gridSize; row++)
                {
                    for (int col = 0; col < gridSize; col++)
                    {
                        sw.Write(" " + (char)(grid[row, col] + '0'));
                        if ((col + 1) % subgridSize == 0) sw.Write(" ");
                    }
                    sw.WriteLine();
                    if ((row + 1) % subgridSize == 0) sw.WriteLine();
                }
            }

        }
	}
}
