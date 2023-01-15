using System;
using sudoku.IO;
using sudoku.validating;
using System.Reflection.PortableExecutable;
using sudoku.dancingLinks;
using sudoku.exceptions;
namespace sudoku
{
    /* main class */
    public class Program
    {
        /* main - creats a sudoku object */
        static void Main(string[] args)
        {
            Sudoku sudoku = new Sudoku();
            sudoku.Sequance();
        }
    }
}
