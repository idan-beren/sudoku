using System;
using sudoku.dancingLinks;
using sudoku.exceptions;
using sudoku.IO;
using sudoku.validating;

namespace sudoku
{
    /* takes care of the sequance of the programm */
	public class Sudoku
	{
        private DLXSolver dlxSolver; // dlx solver object
        private userCommunication communication; // user communication object
        private string input; // string input which represents the sudoku grid
        private string output; // output input which represents the sudoku grid

        /* constructor - initializes the properties */
        public Sudoku()
        {
            dlxSolver = new DLXSolver();
            communication = new userCommunication();
            input = string.Empty;
            output = string.Empty;
        }

        /* calls the reading, validating solving and writing functions */
        public void Sequance()
        {
            while (true)
            {
                if (!Reading()) continue;
                if (!Validation(input)) continue;
                if (!Solving(input)) continue;
                if (!Writing()) continue;
            }
        }

        /* reads input from the user and handles exceptions. returns false if
         an exception were occured, true otherwise */
        private bool Reading()
        {
            try
            {
                communication.recive();
            }
            catch (FileException)
            {
                return false;
            }
            input = communication.Input;
            return true;
        }

        /* writes the solution grid and handles exceptions. returns false if
         an exception were occured, true otherwise */
        private bool Writing()
        {
            try
            {
                if (dlxSolver.ResultMatrix != null)
                    communication.send(dlxSolver.ResultMatrix, output);
            }
            catch (FileException)
            {
                return false;
            }
            return true;
        }

        /* solves the sudoku and handles exceptions. returns false if
         an exception were occured, true otherwise */
        private bool Solving(string input)
        {
            try
            {
                output = dlxSolver.Solve(input);
            }
            catch (UnsolvableGridException uge)
            {
                Console.WriteLine(uge.Message);
                return false;
            }
            return true;
        }

        /* validates the sudoku string and grid and handles exceptions. 
         returns false if an exception were occured, true otherwise */
        private bool Validation(string input)
        {
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
                return false;
            }
            catch (InvalidGridSizeException igse)
            {
                Console.WriteLine(igse.Message);
                return false;
            }
            catch (DuplicateValueException dve)
            {
                Console.WriteLine(dve.Message);
                return false;
            }
            return true;
        }
	}
}
