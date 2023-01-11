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

        // links a node under the current node
        public DancingNode LinkDown(DancingNode node)
        {
            node.bottom = bottom;
            node.bottom.top = node;
            node.top = this;
            bottom = node;
            return node;
        }

        /* links a node right to the current node */
        public DancingNode LinkRight(DancingNode node)
        {
            node.right = right;
            node.right.left = node;
            node.left = this;
            right = node;
            return node;
        }

        // disconects the links between the node and the two nodes at its sides
        public void DisconectLeftAndRight()
        {
            left.right = right;
            right.left = left;
        }

        // reconnects the links between the node and the two nodes at its sides
        public void ReconnectLeftAndRight()
        {
            left.right = this;
            right.left = this;
        }

        // disconects the links between the node and the two nodes above and below it
        public void DisconectTopAndBottom()
        {
            top.bottom = bottom;
            bottom.top = top;
        }

        // reconnects the links between the node and the two nodes above and below it
        public void ReconnectTopAndBottom()
        {
            top.bottom = this;
            bottom.top = this;
        }
    }
}
