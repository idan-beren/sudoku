using System;
namespace sudoku.dancingLinks
{
	public class DLXSolver
	{
		public byte[,] Solve(string input)
		{
            Watch watch = new Watch();
            watch.Start();
            Converter converter = new Converter(input);
            DLX dlx = new DLX(converter.GetCoverMatrix());
            byte[,] resultMatrix = dlx.DLXListToMatrix();
            watch.Stop();
            Console.WriteLine("\nElapsed time: {0} milliseconds",
                    watch.GetElapsedTime());
            return resultMatrix;
        }
	}
}
