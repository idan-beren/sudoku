using System;
using sudoku.exceptions;

namespace sudoku.validating
{
    public class Validator
    {
        /* calls the validate functions on a string and throws an exception when they return false */
        public void ValidateStringGrid(string stringGrid)
        {
            if (!ValidateSize(stringGrid)) throw new InvalidGridSizeException();
            if (!ValidateCharacters(stringGrid)) throw new InvalidCharacterException();
        }

        /* calls the validate function on a matrix and throws an exception when it return false */
        public void ValidateGrid(byte[,] grid)
        {
            if (!ValidateDuplicates(grid)) throw new DuplicateValueException();
        }

        /* returns true if the size of the grid is valid, otherwise false */
        private bool ValidateSize(string stringGrid)
        {
            double gridSize = Math.Sqrt(stringGrid.Length);
            double subgridSize = Math.Sqrt(gridSize);
            return gridSize % 1 == 0 && subgridSize % 1 == 0 && stringGrid.Length != 0;
        }

        /* returns true if all the characthers in the string are valid, 
		 otherwise false*/
        private bool ValidateCharacters(string stringGrid)
        {
            int size = (int)Math.Sqrt(stringGrid.Length);
            for (int i = 0; i < stringGrid.Length; i++)
                if (stringGrid[i] < '0' || stringGrid[i] > (char)(size + '0')) return false;
            return true;
        }

        /* returns true if there are not any duplicated values in any
		 row, column or subgrid, otherwise false*/
        private bool ValidateDuplicates(byte[,] grid)
        {
            /* initializes grid and subgrid sizes, and the arrays that indicates 
             if there are duplicates in the rows, columns and subgrids */
            int gridSize = grid.GetLength(0);
            int subgridSize = (int)Math.Sqrt(gridSize);
            int[,] rowsFlag = new int[gridSize, gridSize];
            int[,] colsFlag = new int[gridSize, gridSize];
            int[,] subgridsFlag = new int[gridSize, gridSize];

            // iterates over each row
            for (int row = 0; row < gridSize; row++)
            {
                // iterates over each col
                for (int col = 0; col < gridSize; col++)
                {
                    int subgrid = (row / subgridSize) * subgridSize + (col / subgridSize);

                    // for each cell that is not empty (equals zero)
                    if (grid[row, col] != 0)
                    {
                        // updates the flag arrays
                        if (rowsFlag[row, grid[row, col] - 1] == 0 &&
                            colsFlag[col, grid[row, col] - 1] == 0 &&
                            subgridsFlag[subgrid, grid[row, col] - 1] == 0)
                        {
                            rowsFlag[row, grid[row, col] - 1] = 1;
                            colsFlag[col, grid[row, col] - 1] = 1;
                            subgridsFlag[subgrid, grid[row, col] - 1] = 1;
                        }
                        else
                            return false; 
                    }
                }
            }
            return true;
        }
    }
}
