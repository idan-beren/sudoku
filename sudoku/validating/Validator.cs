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
            for (int index = 0; index < grid.GetLength(0); index++)
                if (!ValidateRow(grid, index) || !ValidateCol(grid, index) || !ValidateSubgrid(grid, index)) return false;
            return true;
        }

        /* returns true if there are not duplicates in any of the rows */
        private bool ValidateRow(byte[,] grid, int row)
        {
            int size = grid.GetLength(0);
            int[] rowFlag = new int[size];
            for (int col = 0; col < size; col++)
                if (grid[row, col] != 0) rowFlag[grid[row, col] - 1]++;
            return CheckFlag(rowFlag);
        }

        /* returns true if there are not duplicates in any of the columns */
        private bool ValidateCol(byte[,] grid, int col)
        {
            int size = grid.GetLength(1);
            int[] colFlag = new int[size];
            for (int row = 0; row < size; row++)
                if (grid[row, col] != 0) colFlag[grid[row, col] - 1]++;
            return CheckFlag(colFlag);
        }

        /* returns true if there are not duplicates in any of the subgrids */
        private bool ValidateSubgrid(byte[,] grid, int index)
        {
            int gridSize = grid.GetLength(0);
            int subgridSize = (int)Math.Sqrt(gridSize);
            int[] subgridFlag = new int[gridSize];
            int newIndex = index / subgridSize;
            for (int row = newIndex * subgridSize; row < newIndex * subgridSize + subgridSize; row++)
                for (int col = newIndex * subgridSize; col < newIndex * subgridSize + subgridSize; col++)
                    if (grid[row, col] != 0) subgridFlag[grid[row, col] - 1]++;
            return CheckFlag(subgridFlag);
        }

        /* returns false if there are items in the array that bigger then one,
         otherwise returns true */
        private bool CheckFlag(int[] flag)
        {
            for (int item = 0; item < flag.Length; item++)
                if (flag[item] > 1) return false;
            return true;
        }
    }
}
