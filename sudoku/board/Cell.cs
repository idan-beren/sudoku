using System;
using System.Collections;
using System.Xml.Linq;
using Microsoft.VisualBasic.FileIO;

namespace sudoku.board
{
    public class Cell
    {
        private char value; // value of the cell
        private List<char>? options; // list of the possible values to the cell
        private int numOfOptions; // number of options

        /* constructor - gets the value of the cell. sets the value,
		if the value == '0' sets the option list. */
        public Cell(char value, int gridSize)
        {
            this.value = value;
            numOfOptions = 0;
            if (value == '0')
            {
                options = new List<char>();
                for (int i = 1; i < gridSize + 1; i++)
                {
                    options.Add((char)(i + '0'));
                    numOfOptions++;
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

        // getter for the number of options
        public int NumOfOptions
        {
            get { return numOfOptions; }
        }

        // returns the first option in the options list, otherwise null
        public char? firstOption()
        {
            if (options != null)
                return options[0];
            else
                return null;
        }

        // removes the given value from the options list
        public void removeOption(char option)
        {
            if (options != null)
            {
                options.Remove(option);
                numOfOptions--;
            }
        }
    }
}
