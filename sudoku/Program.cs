using System;
using sudoku.board;
using sudoku.solving;
using sudoku.IO;
using System.ComponentModel.DataAnnotations;
using System.Reflection.PortableExecutable;

namespace sudoku
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                IReader consoleReader = new ConsoleReader();
                string input = consoleReader.readInput();
                //IReader fileReader = new FileReader();
                //string input = fileReader.readInput();




                Grid grid = new Grid(input);
                Solver solver = new Solver(grid);
                solver.solveGrid();
                Grid newGrid = solver.Grid;
                Writer writer = new Writer();
                writer.writeGrid(newGrid);
            }
        }
    }
}
