using System;
namespace sudoku.dancingLinks
{
    /* represents a column node in the dlx list */
	public class ColumnNode : DancingNode
	{
		public int size; // amount of dancing nodes in the column
		public string name; // serial number of the column

        /* constructor - initializes the properties of the class */
        public ColumnNode(string name) : base()
		{
			size = 0;
			this.name = name;
			column = this;
		}

        /* disconects the links from the node if this node is considered as
         an option to the value*/
        public void Cover()
        {
            DisconectLeftAndRight(); // disconects the links to right and left
            DancingNode row = bottom;

            // iterates over the rows in the dlx list
            while (row != this)
            {
                DancingNode col = row.right;

                // iterates over the columns in the dlx list
                while (col != row)
                {
                    col.DisconectTopAndBottom(); // disconects the links to top and bottom
                    if (col.column != null) col.column.size--;
                    col = col.right;
                }
                row = row.bottom;
            }
        }

        /* reconnects the links for the node if this node is not considered as
         an option to the value*/
        public void Uncover()
        {
            DancingNode row = top;

            // iterates over the rows in the dlx list
            while (row != this)
            {
                DancingNode col = row.left;

                // iterates over the columns in the dlx list
                while (col != row)
                {
                    col.ReconnectTopAndBottom(); // resconects the links to top and bottom
                    if (col.column != null) col.column.size++;
                    col = col.left;
                }
                row = row.top;
            }
            ReconnectLeftAndRight(); // resconects the links to right and left
        }
    }
}
