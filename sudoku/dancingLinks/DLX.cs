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

        /* recursive search method which stores into the result list the 
         nodes that represent the solution of the sudoku grid.
         the method returns true when a solution has been found,
         otherwise false */
        public bool Search()
        {
            // the search is over and the solution has been found, returns true
            if (header.right == header)
            {
                result = new List<DancingNode>(answer);
                return true;
            }

            // selects the column node with the fewest number of nodes and "covers" it
            ColumnNode column = ChooseColumnNode();
            column.Cover();

            // iterates over the rows in the column
            DancingNode row = column.bottom;
            while (row != column)
            {
                // adds the row node into the answer list and "covers" intersected nodes
                answer.Add(row);
                DancingNode index1 = row.right;
                while (index1 != row)
                {
                    index1.column?.Cover();
                    index1 = index1.right;
                }

                // calls itself recursively
                if (Search()) return true;

                // removes the node from the answer list and "uncovers" intersected nodes
                row = answer[answer.Count - 1];
                answer.RemoveAt(answer.Count - 1);
                column = row.column ?? column;
                DancingNode index2 = row.left;
                while (index2 != row)
                {
                    index2.column?.Uncover();
                    index2 = index2.left;
                }
                row = row.bottom;
            }

            // "uncovers" the column node and returns false
            column.Uncover();
            return false;
        }

        /* chooses the column node with the fewest number of dancing nodes 
         (= minimum size) that occurring in a column */
        private ColumnNode ChooseColumnNode()
        {
            ColumnNode minColumn = (ColumnNode)header.right;
            ColumnNode col = (ColumnNode)header.right;

            // iterates over each column
            while (col != header)
            {

                // finds the column with the lowest size
                if (col.size < minColumn.size) minColumn = col;
                col = (ColumnNode)col.right;
            }
            return minColumn;
        }

        /* converts the list of the result into a matrix that will represent the 
         solved sudoku grid */
        public byte[,] DLXListToMatrix()
        {
            byte[,] matrix = new byte[SIZE, SIZE];

            // iterates over the nodes in the result list
            while (result.Count != 0)
            {
                DancingNode resultNode = result[0];
                result.RemoveAt(0);
                DancingNode index = resultNode.right;

                // iterates over the columns 
                while (index != resultNode)
                {

                    // finds the node in the result list that corresponds to the lowest column name
                    if ((index.column != null && resultNode.column != null) &&
                        (Int32.Parse(index.column.name) < Int32.Parse(resultNode.column.name)))
                        resultNode = index;
                    index = index.right;
                }

                // extracts the row, column, and value of the solution from the retrieved node's column name
                int resultNodeName = (int)Int32.Parse(resultNode.column?.name ?? "0");
                int nextNodeName = (int)Int32.Parse(resultNode.right?.column?.name ?? "0");
                int resultRow = resultNodeName / SIZE;
                int resultCol = resultNodeName % SIZE;
                byte resultValue = (byte)(nextNodeName % SIZE + 1);

                // stores the value in the appropriate position in the matrix
                matrix[resultRow, resultCol] = resultValue;
            }
            return matrix;
        }
    }
}
