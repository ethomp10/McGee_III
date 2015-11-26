using System;

namespace McGee_III
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.Title = "The Adventure of Mrs. McGee III";

            string input;
            bool runGame = true;

            Console.WriteLine("+ ----------------------------------- +");
            Console.WriteLine("|   The Adventure of Mrs. McGee III   |");
            Console.WriteLine("+ ----------------------------------- +");
            Console.WriteLine("            ~ Press Enter ~            ");
            Console.ReadLine();
            Console.Clear();

            Console.Write("Please enter your name, adventurer.\n\n> ");
            Character player = new Character(Console.ReadLine()); // Get players name
            Console.WriteLine("\nWelcome, Mrs. {0} McGee!", player.Name);
            Console.WriteLine("I understand you may be a new player.");
            Console.WriteLine("Would you like a tutorial? (y/n)"); input = ynTrap();

            if (input == "y")
            {
                showHelp();
            }
            else if (input == "n")
            {
                Console.WriteLine("\nVery well, enjoy your adventure, {0}!", player.Name);
            }


            while (runGame == true)
            {
                Console.Write("\n> ");
                input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "help":
                        showHelp();
                        break;
                    case "cmd":
                        printCommands();
                        break;
                    case "quit":
                        runGame = false;
                        break;
                    default:
                        Console.WriteLine("\nI don't understand this command.");
                        Console.WriteLine("Type \"cmd\" for a list of usable commands.");
                        break;
                }
            }
        }

        // Print user manual
        public static void showHelp()
        {
            Console.Clear();
            Console.WriteLine("~ The Adventure of Mrs. McGee III: Official User Manual ~");
            Console.WriteLine("\nThroughout your adventure, you will have to control yourself by typing commands.");
            Console.WriteLine("Whenever an angle bracket \">\" is printed, you may enter any of the following commands:");
            printCommands();
        }

        // Validate (y/n) input
        public static string ynTrap()
        {
            bool valid = false;
            string input = "";

            while (valid == false)
            {
                Console.Write("\n> ");
                input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "y":
                    case "n":
                        valid = true;
                        break;
                    default:
                        Console.WriteLine("\nPlease enter a 'y' or 'n'.");
                        break;
                }
            }

            return input;
        }

        // Print list of usable commands
        public static void printCommands()
        {
            Console.WriteLine("\nCOMMAND\t\tDESCRIPTION");
            Console.WriteLine("help\t\tShows manual");
            Console.WriteLine("cmd\t\tLists these commands");
            Console.WriteLine("quit\t\tExits the application");
        }
    }
}
