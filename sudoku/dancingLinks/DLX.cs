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
            header = CreatDLXList(coverMatrix);
            SIZE = (int)Math.Pow(coverMatrix.Length / AMOUNT_OF_CONSTRAINTS, 1.0 / 5);
        }
        
        /* converts a cover matrix into a quadruple chained list that will
         represent the cover matrix */
        private ColumnNode CreatDLXList(byte[,] coverMatrix)
        {
            // initializes parameters
            int numberOfrows = coverMatrix.GetLength(0);
            int numberOfColumns = coverMatrix.GetLength(1);
            ColumnNode headerNode = new ColumnNode("header");
            List<ColumnNode> columnNodes = new List<ColumnNode>();

            // adds columns to the header node (one for each column in the cover matrix)
            for (int number = 0; number < numberOfColumns; number++)
            {
                ColumnNode columnNode = new ColumnNode(number.ToString());
                columnNodes.Add(columnNode);
                headerNode = (ColumnNode)headerNode.LinkRight(columnNode); // links the header node to the column node
            }
            headerNode = headerNode.right.column ?? headerNode;

            // iterates through the rows of the cover matrix
            for (int row = 0; row < numberOfrows; row++)
            {
                DancingNode? previousNode = null;

                // iterates through the cols of the cover matrix
                for (int col = 0; col < numberOfColumns; col++)
                {

                    // creates a series of nodes which correspond to the ones in the row
                    if (coverMatrix[row, col] == 1)
                    {
                        ColumnNode column = columnNodes[col];
                        DancingNode newNode = new DancingNode(column);
                        previousNode ??= newNode;
                        column.top.LinkDown(newNode); // links the new node to the top of the column node
                        previousNode = previousNode.LinkRight(newNode); // links the new node to the right of the previous node in the row
                        column.size++;
                    }
                }
            }
            headerNode.size = numberOfColumns;
            return headerNode;
        }
    }
}
