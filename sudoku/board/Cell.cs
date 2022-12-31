using System;
using System.Collections;
using System.Xml.Linq;

namespace sudoku.board
{
	public class Cell
	{
		private char value; // value of the cell
		private List<char>? options; // list of the possible values to the cell

        /* constructor - gets the value of the cell. sets the value,
		if the value != '0' sets the option list. */
        public Cell(char value, int gridSize)
		{
            this.value = value;
            if (value != '0')
			{
				options = new List<char>();
				for (int i = 1; i < gridSize + 1; i++)
				{
					options.Add((char)(i + '0'));
				}
			}
		}

		// getter and setter for the value quality
        public char Value
        {
            get { return value; }
            set { this.value = value; }
        }

		// getter for the options list
		public List<char>? Options
		{
			get { return options; }
		}

		// removes the given value from the options list
		public void removeOption(char option)
		{
			if (options != null)
				options.Remove(option);
		}
    }
}
