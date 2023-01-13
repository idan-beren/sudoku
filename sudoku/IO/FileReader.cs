using System;
namespace sudoku.IO
{
    public class FileReader : IReader
    {
        // gets an input from the user by a file
        public string ReadInput()
        {
            Console.WriteLine("enter the path of the file");
            string filePath = Console.ReadLine();
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                    return reader.ReadToEnd();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Could not find the file\n");
                return string.Empty;
            }
            catch (IOException)
            {
                Console.WriteLine("Could not read the file properly\n");
                return string.Empty;
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Could not access the file\n");
                return string.Empty;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("The value cannot be an empty string\n");
                return string.Empty;
            }
        }
    }
}
