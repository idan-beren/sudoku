using System;
using System.Collections;
using System.Data.Common;

namespace sudoku.dancingLinks
{
    /* class of quadruple chained list representing the cover matrix that has 
     already created in the converter class */
    public class DLX
	{
        private ColumnNode header; // pointer to the start of the quadruple list
        private List<DancingNode> answer; // list that represents the answer
        private List<DancingNode> result; // list that represents the result
        private int SIZE; // size of the sudoku grid
        private const int AMOUNT_OF_CONSTRAINTS = 4; // amount of constraints (cell, row, col, subgrid)

        /* constructor - initializes the answer and result lists, creats a
         dlx list and stores the start of it un the header, caculates the size
         of the grid and calls the Search method */
        public DLX(byte[,] coverMatrix)
		{
            answer = new List<DancingNode>();
            result = new List<DancingNode>();
            SIZE = (int)Math.Pow(coverMatrix.Length / AMOUNT_OF_CONSTRAINTS, 1.0 / 5);
        }
    }
}
