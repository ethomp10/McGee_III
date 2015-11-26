using System;

namespace McGee_III
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string input;

            Console.WriteLine("+ ----------------------------------- +");
            Console.WriteLine("|   The Adventure of Mrs. McGee III   |");
            Console.WriteLine("+ ----------------------------------- +");
            Console.WriteLine("            ~ Press Enter ~            ");
            Console.ReadLine();
            Console.Clear();

            Console.Write("Please enter your name, adventurer.\n\n> ");
            Character player = new Character(Console.ReadLine());
            Console.WriteLine("\nWelcome, Mrs. {0} McGee!", player.Name);
            Console.WriteLine("I understand you may be a new player.");
            Console.WriteLine("Would you like a tutorial? (y/n)"); input = ynTrap();

            if (input == "y")
            {
                // Run help command
            }
            else if (input == "n")
            {
                Console.WriteLine("\nVery well, enjoy your adventure, {0}!", player.Name);
            }

                while (input != "quit")
                {
                    Console.Write("\n> ");
                    input = Console.ReadLine().ToLower();
                }
            }

        public static string ynTrap()
        {
            bool valid = false;
            string input = "";

            while (valid == false)
            {
                Console.Write("\n> ");
                input = Console.ReadLine();
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
    }
}
