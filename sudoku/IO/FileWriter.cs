using System;
using sudoku.exceptions;
namespace sudoku.IO
{
    public class FileWriter : IWriter
    {
        private const string path = "/Users/idan.beren/Projects/sudoku/sudoku/solutions/result.txt";

        /* gets a solution string grid and prints it into a file 
         and handles exceptions */
        public void WriteOutput(string output)
        {
            bool flag = true;
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.Write(output);
                }
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Could not find the file to print to\n");
                flag = false;
            }
            catch (IOException)
            {
                Console.WriteLine("Could not write to the file properly\n");
                flag = false;
            }
            if (!flag) throw new FileException();
        }
    }
}
