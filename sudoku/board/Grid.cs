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
            for (int row = 0; row < ROW_SIZE; row++)
                for (int col = 0; col < COL_SIZE; col++)
                    cells[row, col] = new Cell(stringGrid[row * ROW_SIZE + col], ROW_SIZE);
        }

        // getter for the cells matrix
        public Cell[,] Cells
        {
            get { return cells; }
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
