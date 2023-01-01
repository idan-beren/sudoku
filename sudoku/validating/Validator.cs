using System;
using sudoku.exceptions;

namespace sudoku.validating
{
	public class Validator
	{
		public Validator()
		{
		}

		/* calls the validate functions and throws an exception they return false*/
		public void validateGrid(string stringGrid)
		{
			if (!validateSize(stringGrid)) throw new InvalidGridSizeException();
            if (!validateCharacters(stringGrid)) throw new InvalidCharacterException();
        }

		/* returns true if the size of the grid is valid, otherwise false */
		private bool validateSize(string stringGrid)
		{
			return Math.Sqrt(stringGrid.Length) % 10 == 0;
		}

		/* returns true if all the characthers in the string are valid, 
		 otherwise false*/
		private bool validateCharacters(string stringGrid)
		{
			int size = (int)Math.Sqrt(stringGrid.Length);
			for (int i = 0; i < stringGrid.Length; i++)
				if (stringGrid[i] < '0' || stringGrid[i] > (char)(size)) return false;
			return true;
        }
	}
}
