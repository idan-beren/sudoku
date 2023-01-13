using System;
using sudoku.validating;

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
            Validator validator = new Validator(); //
            validator.ValidateGrid(matrix); //
        }

		/* converts a matrix into a cover matrix -
		 fills the cover matrix (spare binary matrix) which represents the options
		 to fill the empty values in the sudoku grid, by taking into account
		 the constrains and the values in the matrix which represents the grid*/
		private void MatrixToCoverMatrix()
		{
            // initializes parameters that will track the positions in the cover matrix.
            int rowPosition = 0;
			int cellConstraintPosition = 0;
			int rowConstraintPosition = GRID_SIZE * GRID_SIZE * 2;
			int colConstraintPosition = GRID_SIZE * GRID_SIZE;
			int subgridConstraintPosition = GRID_SIZE * GRID_SIZE * 3;

			// iterates over each row of the matrix
			for (int row = 0; row < GRID_SIZE; row++)
			{

                // iterates over each column of the matrix
                for (int col = 0; col < GRID_SIZE; col++)
				{
					int subgridPosition = (row / SUBGRID_SIZE) * SUBGRID_SIZE + col / SUBGRID_SIZE;

                    // for each cell in the matrix iterates over a range of (1 - GRID_SIZE+1)
                    for (int option = 1; option < GRID_SIZE + 1; option++)
					{

                        // if the value of the current cell equals zero or considered to be an option
                        if (matrix[row, col] == 0 || matrix[row, col] == option)
						{

                            /* sets values in the cover matrix to one, its represents the constraints (row, column, subgrid, cell)
                             that must be satisfied in order to fill an empty cell with a specific option */
                            coverMatrix[rowPosition, cellConstraintPosition] = 1;
                            coverMatrix[rowPosition, rowConstraintPosition + option - 1] = 1;
                            coverMatrix[rowPosition, colConstraintPosition] = 1;
                            coverMatrix[rowPosition, subgridConstraintPosition + option - 1 + (subgridPosition * GRID_SIZE)] = 1;
                        }
						rowPosition++;
						colConstraintPosition++;
					}
					cellConstraintPosition++;
				}
				rowConstraintPosition += GRID_SIZE;
                colConstraintPosition = GRID_SIZE * GRID_SIZE;
            }
        }

        /* calls stringToMatrix() and matrixToCoverMatrix() and returns 
         the cover matrix*/
        public byte[,] GetCoverMatrix()
		{
			StringToMatrix();
			MatrixToCoverMatrix();
			return coverMatrix;
		}
	}
}
