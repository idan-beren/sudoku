using System;
namespace sudoku.IO
{
	public class userCommunication
	{
		private string choice; // the choice of the user
		private string input; // input from the user 

        /* constructor - initializes the choice and the input */
        public userCommunication()
		{
			choice = "";
			input = "";
		}

        /* gets from the user the  */
		public void recive()
		{
            Console.WriteLine("enter the number of the option you want\n" +
                "1: input by the console\n" +
                "2: input by a file\n" +
                "3: exit\n");
            choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    IReader consoleReader = new ConsoleReader();
                    input = consoleReader.ReadInput();
                    break;
                case "2":
                    IReader fileReader = new FileReader();
                    input = fileReader.ReadInput();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("invalid option\n");
                    recive();
                    break;
            }
        }

        /* */
        public void send(byte[,] grid)
        {
            if (choice == "2")
            {
                IWriter fileWriter = new FileWriter();
                fileWriter.WriteGrid(grid);
            }
            IWriter consoleWriter = new ConsoleWriter();
            consoleWriter.WriteGrid(grid);
        }

        // getter for the input
        public string Input
        {
            get { return input; }
        }
    }
}
