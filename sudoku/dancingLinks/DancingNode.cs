using System;
namespace sudoku.dancingLinks
{
	/* represents a dancing node */
	public class DancingNode
	{
        public DancingNode left; // pointer to the node in the left
        public DancingNode right; // pointer to the node in the right
        public DancingNode top; // pointer to the node in the top
        public DancingNode bottom; // pointer to the node in the bottom
        public ColumnNode? column; // pointer to the column node

        /* constructor - initializes the pointers properties */
        public DancingNode()
		{
			left = this;
			right = this;
			top = this;
			bottom = this;
            column = null;
		}

        // another constructor - gets the column node and sets it
        public DancingNode(ColumnNode column) : this()
		{
			this.column = column;
		}
    }
}
