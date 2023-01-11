using System;
namespace sudoku.dancingLinks
{
    /* gets a string which represents the sudoku grid, then converts it into
	 a matrix which represents the sudoku grid, then converts it into
	 a spare cover matrix which represents the options to fill the empty values
	 in the sudoku grid*/
    public class Converter
	{
		private int GRID_SIZE; // size of the sudoku grid
		private int SUBGRID_SIZE; // size of the subgrid
        private string input; // string which represents the sudoku grid
        private byte[,] matrix; // matrix which represents the sudoku grid
		private byte[,] coverMatrix; // matrix which represents the cover matrix
		private const int AMOUNT_OF_CONSTRAINTS = 4; // amount of constraints (cell, row, col, subgrid)

        /* constructor - calculates the size of the grid and subgrid, 
         initializes the matrix and cover matrix */
        public Converter(string input)
		{
			this.input = input;
            GRID_SIZE = (int)Math.Sqrt(input.Length);
			SUBGRID_SIZE = (int)Math.Sqrt(GRID_SIZE);
            matrix = new byte[GRID_SIZE, GRID_SIZE];
			coverMatrix = new byte[GRID_SIZE * GRID_SIZE * GRID_SIZE, GRID_SIZE * GRID_SIZE * AMOUNT_OF_CONSTRAINTS];
        }

		/* converts a string which represents the sudoku grid into a matrix
		 which represents the sudoku grid*/
		private void StringToMatrix()
		{
			for (int row = 0; row < GRID_SIZE; row++)
				for (int col = 0; col < GRID_SIZE; col++)
					matrix[row, col] = (byte)(input[row * GRID_SIZE + col] - '0');
        }
	}
}
