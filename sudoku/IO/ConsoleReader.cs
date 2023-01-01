using System;
namespace sudoku.IO
{
	public class ConsoleReader : IReader
	{
		// gets an input from the user by the console
		public string readInput()
		{
            return Console.ReadLine();
        }
	}
}
