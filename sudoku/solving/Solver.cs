using System;
using sudoku.board;

namespace sudoku.solving
{
	public class Solver
	{
		private Grid grid; // grid to solve

        // constructor - sets the grid
        public Solver(Grid grid)
		{
			this.grid = grid;
		}

        /* solves the grid.
         first, searches for an empty cell. if not found, the grid is solved,
         otherwise checks for the empty cell its for its value by is list
         of options. (it does this recursively till the grid is solved) */
        public bool solveGrid()
        {
            (int, int)? emptyCell = findEmptyCell();
            if (emptyCell == null)
                return true;
            int row = emptyCell.Value.Item1, col = emptyCell.Value.Item2;
            List<char> options = grid.Cells[row, col].Options ?? new List<char>();
            foreach (char option in options)
            {
                if (checkOption(option, (row, col)))
                {
                    grid.Cells[row, col].Value = option;
                    if (solveGrid())
                        return true;
                    grid.Cells[row, col].Value = '0';
                }
            }
            return false;
        }

        /* searches for the next empty cell. if finds returns a tuple of 
		 the position, otherswise returns null.
		 (this method prioritizes cells with less options in the option list) */
        private (int, int)? findEmptyCell()
		{
			(int, int)? minPos = null;
			for (int row = 0; row < grid.rowSize; row++)
				for (int col = 0; col < grid.colSize; col++)
					if (grid.Cells[row, col].Value == '0')
					{
						if (minPos == null)
                            minPos = (row, col);
						else
						{
							if (grid.Cells[row, col].NumOfOptions <
								grid.Cells[minPos.Value.Item1, minPos.Value.Item2].NumOfOptions)
                                minPos = (row, col);
                        }
					}
			return minPos;
		}

		/* checks if the option is possible. gets a value and its position
		 and returns true if its possible, otherwise returns false*/
		private bool checkOption(char value, (int, int) pos)
		{
            for (int i = 0; i < grid.rowSize; i++)
                if (grid.Cells[pos.Item1, i].Value == value && pos.Item2 != i)
                    return false;
            for (int i = 0; i < grid.colSize; i++)
                if (grid.Cells[i, pos.Item2].Value == value && pos.Item1 != i)
                    return false;
            int subGridX = pos.Item2 / grid.subgridSize;
            int subGridY = pos.Item1 / grid.subgridSize;
            for (int i = subGridY * grid.subgridSize; i < subGridY * grid.subgridSize + grid.subgridSize; i++)
                for (int j = subGridX * grid.subgridSize; j < subGridX * grid.subgridSize + grid.subgridSize; j++)
                    if (grid.Cells[i, j].Value == value && (i, j) != pos)
                        return false;
            return true;
        }

        // getter for the grid
        public Grid Grid
        {
            get { return grid; }
        }
    }
}
