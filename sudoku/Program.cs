using System;
using sudoku.IO;
using sudoku.validating;
using System.Reflection.PortableExecutable;
using sudoku.dancingLinks;
using sudoku.exceptions;
namespace sudoku
{
    public class Program
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            string input = reader.ReadInput();
            Validator validator = new Validator();
            try
            {
                validator.ValidateStringGrid(input);
            }
            catch (InvalidCharacterException ice)
            {
                Console.WriteLine(ice.Message);
                return;
            }
            catch (InvalidGridSizeException igse)
            {
                Console.WriteLine(igse.Message);
                return;
            }
            DLXSolver dlxSolver = new DLXSolver();
            byte[,] result = dlxSolver.Solve(input);
            IWriter writer = new ConsoleWriter();
            writer.WriteGrid(result);
        }
    }
}
