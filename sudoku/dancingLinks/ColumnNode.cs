using System;
namespace sudoku.dancingLinks
{
    /* represents a column node */
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
    }
}
