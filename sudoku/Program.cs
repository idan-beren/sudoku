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
            while (true)
            {
                userCommunication communication = new userCommunication();
                communication.recive();
                string input = communication.Input;
                Validator validator = new Validator();
                Converter converter = new Converter(input);
                converter.StringToMatrix();
                try
                {
                    validator.ValidateStringGrid(input);
                    validator.ValidateGrid(converter.Matrix);
                }
                catch (InvalidCharacterException ice)
                {
                    Console.WriteLine(ice.Message);
                    continue;
                }
                catch (InvalidGridSizeException igse)
                {
                    Console.WriteLine(igse.Message);
                    continue;
                }
                catch (DuplicateValueException dve)
                {
                    Console.WriteLine(dve.Message);
                    continue;
                }
                DLXSolver dlxSolver = new DLXSolver();
                try
                {
                    dlxSolver.Solve(input); 
                }
                catch (UnsolvableGridException uge)
                {
                    Console.WriteLine(uge.Message);
                    continue;
                }
                if (dlxSolver.ResultMatrix != null)
                    communication.send(dlxSolver.ResultMatrix);
            }
        }
    }
}
