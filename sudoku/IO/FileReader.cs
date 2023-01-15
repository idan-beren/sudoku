using System;
using sudoku.exceptions;
namespace sudoku.IO
{
    public class FileReader : IReader
    {
        // gets an input from the user by a file and handles exceptions
        public string ReadInput()
        {
            Console.WriteLine("enter the path of the file");
            string filePath = Console.ReadLine();
            bool flag = true;
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                    return reader.ReadToEnd();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Could not find the file\n");
                flag = false;
            }
            catch (IOException)
            {
                Console.WriteLine("Could not read the file properly\n");
                flag = false;
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Could not access the file\n");
                flag = false;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("The value cannot be an empty string\n");
                flag = false;
            }
            if (!flag) throw new FileException();
            return string.Empty;
        }
    }
}
