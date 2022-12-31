using System;
namespace sudoku.board
{
	public class Grid
	{
		private Cell[,] cells; // matrix of cells
        private int ROW_SIZE; // size of the raw
        private int COL_SIZE; // size of the column
        private int SUBGRID_SIZE; // size of the subgrid

        /* constructor - gets a string which represents the grid and 
         creats the grid */
        public Grid(string stringGrid)
		{
            calcSizes(stringGrid);
            cells = new Cell[ROW_SIZE,COL_SIZE];
            stringToGrid(stringGrid);
		}

        /* calculates the sizes qualities according to the length of the 
         given string */
		private void calcSizes(string stringGrid)
		{
            ROW_SIZE = (int)Math.Sqrt(stringGrid.Length);
            COL_SIZE = ROW_SIZE;
            SUBGRID_SIZE = (int)Math.Sqrt(ROW_SIZE);
        }

        // convert the string into a grid
        private void stringToGrid(string stringGrid)
        {
            int row = 0, col = 0;
            for (int index = 0; index < stringGrid.Length; index++)
            {
                if (index % ROW_SIZE == 0 && index != 0)
                {
                    row++;
                    col = 0;
                }
                cells[row, col].Value = stringGrid[index];
                col++;
            }
        }

        // getter for the row size
        public int rowSize
        {
            get { return ROW_SIZE;  }
        }

        // getter for the column size
        public int colSize
        {
            get { return COL_SIZE; }
        }

        // getter for the subgrid size
        public int subgridSize
        {
            get { return SUBGRID_SIZE; }
        }
    }
}
