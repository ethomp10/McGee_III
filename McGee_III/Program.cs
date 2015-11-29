﻿using System;

namespace McGee_III
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.Title = "The Adventure of Mrs. McGee III";

            string input;
            bool runGame = true;
            Character player;
            Room[,] map;
            Room local;

            Console.WriteLine("+ ----------------------------------- +");
            Console.WriteLine("|   The Adventure of Mrs. McGee III   |");
            Console.WriteLine("+ ----------------------------------- +");
            Console.WriteLine("            ~ Press Enter ~            ");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("You awaken to complete darkness...");
            Console.WriteLine("In fact, it was hard to tell you were awake at first.");
            Console.WriteLine("How did you get here?");
            Console.WriteLine("You don't remember.");
            Console.Write("The only thing you can remember is your name...\n\n> ");
            input = Console.ReadLine();
            if (input == "")
            {
                Console.WriteLine("\n... come to think of it, you can't seem to remember that either.");
            }
            else
            {
                Console.WriteLine("\n... of course, Mrs. {0} McGee.", input);
                Console.WriteLine("That's something at least.");
            }
            player = new Character(input);
            Console.WriteLine("Either way, you have to find your way out of here.");
            Console.WriteLine("\nI understand you may be a new player.");
            Console.WriteLine("Would you like to view a list of commands? (y/n)");
            input = ynTrap();

            if (input == "y")
            {
                showHelp();
                Console.WriteLine("\nGood luck, {0}!", player.Name);
            }
            else if (input == "n")
            {
                Console.WriteLine("\nVery well, good luck {0}!", player.Name);
            }

            map = makeMap();

            // Game loop
            while (runGame == true)
            {
                local = map[player.Xpos, player.Ypos];
                Console.Write("\n> ");
                input = Console.ReadLine().ToLower();
                switch (input)
                {

                    case "map": // DEBUG COMMAND
                        Console.WriteLine();
                        for (int y = 0; y < 3; y++)
                        {
                            for (int x = 0; x < 3; x++)
                            {
                                Console.WriteLine("Room:\t({0},{1})\t{2}", x, y, map[x, y].Descripion);
                            }
                        }
                        break;
                    case "sense":
                    case "e":
                        local.sense();
                        Console.WriteLine("\nX:\t{0}\nY:\t{1}\n{2}", player.Xpos, player.Ypos, local.Descripion);
                        break;
                    case "north":
                    case "w":
                        player.moveNorth();
                        break;
                    case "east":
                    case "d":
                        player.moveEast();
                        break;
                    case "south":
                    case "s":
                        player.moveSouth();
                        break;
                    case "west":
                    case "a":
                        player.moveWest();
                        break;
                    case "help":
                        showHelp();
                        break;
                    case "quit":
                    case "q":
                        Console.WriteLine("\nAre you sure you want to quit? (y/n)");
                        input = ynTrap();
                        if (input == "y")
                        {
                            runGame = false;
                        }
                        else if (input == "n")
                        {
                            Console.WriteLine("\nDidn't think so!");
                        }
                        break;
                    default:
                        Console.WriteLine("\nI don't understand this command.");
                        Console.WriteLine("Type \"help\" for a list of usable commands.");
                        break;
                }
            }
        }

        // Generate map
        public static Room[,] makeMap()
        {
            Room[,] tempMap = new Room[3, 3];
            Random rnd = new Random();
            int seed;

            for (int y = 0; y < 3; y++)
            {

                for (int x = 0; x < 3; x++)
                {
                    seed = rnd.Next(1000);
                    tempMap[x, y] = new Room(seed, x, y);
                }
            }

            return tempMap;
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
                    case "yes":
                        input = "y"; valid = true;
                        break;
                    case "n":
                    case "no":
                        input = "n"; valid = true;
                        break;
                    default:
                        Console.WriteLine("\nPlease enter a 'y' or 'n'.");
                        break;
                }
            }

            return input;
        }

        // Print list of usable commands
        public static void showHelp()
        {
            Console.WriteLine("\nCOMMAND | ALT\tDESCRIPTION");
            Console.WriteLine();
            Console.WriteLine("  sense | e\tGives information on the player's surroundings");
            Console.WriteLine("  north | w\tMoves the character north");
            Console.WriteLine("   west | a\tMoves the character west");
            Console.WriteLine("  south | s\tMoves the character south");
            Console.WriteLine("   east | d\tMoves the character east");
            Console.WriteLine();
            Console.WriteLine("   quit | q\tExits the application");
        }
    }
}
