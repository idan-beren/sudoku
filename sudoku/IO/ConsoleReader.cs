using System;
namespace sudoku.IO
{
    // class of reading the input from the console
    public class ConsoleReader : IReader
    {
        // gets an input from the user by the console. returns the input.
        public string ReadInput()
        {
            Console.WriteLine("enter the sudoku grid");
            return Console.ReadLine();
        }
    }
}
