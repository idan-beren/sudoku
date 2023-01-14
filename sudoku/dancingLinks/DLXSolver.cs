using System;
using sudoku.exceptions;
namespace sudoku.dancingLinks
{
    /* class which is responsible to solve the sudoko grid
     it gets the sudoku grid and then returns the solution of it
     it uses the dlx algorithm to solve the sudoku grid */
    public class DLXSolver
	{
        private byte[,]? resultMatrix; // matrix which represents the solution of the sudoku grid

        // constructor - initializes the result matrix to null
        public DLXSolver()
        {
            resultMatrix = null;
        }

        /* solves the sudoku grid. this method gets and returns the same format 
         (= string). it gets a string which represents the sudoku grid to solve
         and returns a string which represents the sudoku grid after solving.
         this method stores the result matrix into a property of the class */
        public string Solve(string input)
		{
            Watch watch = new Watch();
            watch.Start();
            Converter converter = new Converter(input);
            converter.StringToMatrix();
            DLX dlx = new DLX(converter.GetCoverMatrix());
            if (!dlx.Search()) throw new UnsolvableGridException();
            resultMatrix = dlx.DLXListToMatrix();
            watch.Stop();
            Console.WriteLine("\nElapsed time: {0} milliseconds",
                    watch.GetElapsedTime());
            return converter.MatrixToString(resultMatrix);
        }

        // getter for the result matrix 
        public byte[,]? ResultMatrix
        {
            get { return resultMatrix; }
        }
	}
}
