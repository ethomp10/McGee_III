using System;

namespace McGee_III
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.Title = "The Adventure of Mrs. McGee III";

			string input;
			bool runGame = true;
			Character player;
			Room[,] map;

			Console.WriteLine ("+ ----------------------------------- +");
			Console.WriteLine ("|   The Adventure of Mrs. McGee III   |");
			Console.WriteLine ("+ ----------------------------------- +");
			Console.WriteLine ("            ~ Press Enter ~            ");
			Console.ReadLine ();
			Console.Clear ();

			Console.Write ("Please enter your name, adventurer.\n\n> ");
			player = new Character (Console.ReadLine ()); // Get players name
			Console.WriteLine ("\nWelcome, Mrs. {0} McGee!", player.Name);
			Console.WriteLine ("I understand you may be a new player.");
			Console.WriteLine ("Would you like a tutorial? (y/n)");
			input = ynTrap ();

			if (input == "y") {
				showHelp ();
			} else if (input == "n") {
				Console.WriteLine ("\nVery well, enjoy your adventure, {0}!", player.Name);
			}

			map = makeMap ();

			// Game loop
			while (runGame == true) {
				Console.Write ("\n> ");
				input = Console.ReadLine ().ToLower ();
				switch (input) {
				case "map": // DEBUG COMMAND
					Console.WriteLine ();
					for (int i = 0; i < 3; i++) {
						for (int j = 0; j < 3; j++) {
							Console.WriteLine ("Room:\t{0},{1}\t{2}", i, j, map [i, j].Descripion);
						}
					}
					break;
				case "look":
					for (int i = 0; i < 3; i++) {
						for (int j = 0; j < 3; j++) {
							if ((player.Xpos == j) && (player.Ypos == i))
								Console.WriteLine ("\nRoom:\t{0},{1}\n{2}", player.Ypos, player.Xpos, map [i,j].Descripion); 
							}
						}
					break;
				case "north":
					player.moveNorth ();
					break;
				case "east":
					player.moveEast ();
					break;
				case "south":
					player.moveSouth ();
					break;
				case "west":
					player.moveWest ();
					break;
				case "help":
					showHelp ();
					break;
				case "cmd":
					printCommands ();
					break;
				case "quit":
					Console.WriteLine ("\nAre you sure you want to quit? (y/n)");
					input = ynTrap ();
					if (input == "y") {
						runGame = false;
					} else if (input == "n") {
						Console.WriteLine ("\nDidn't think so!");
					}
					break;
				default:
					Console.WriteLine ("\nI don't understand this command.");
					Console.WriteLine ("Type \"cmd\" for a list of usable commands.");
					break;
				}
			}
		}

		// Generate map
		public static Room[,] makeMap ()
		{
			Room[,] tempMap = new Room[3, 3];
			Random rnd = new Random ();
			int seed;

			for (int i = 0; i < 3; i++) {
				
				for (int j = 0; j < 3; j++) {
					seed = rnd.Next (1000);
					tempMap [i, j] = new Room (seed);
				}
			}

			return tempMap;
		}

		// Print user manual
		public static void showHelp ()
		{
			Console.Clear ();
			Console.WriteLine ("~ The Adventure of Mrs. McGee III: Official User Manual ~");
			Console.WriteLine ("\nThroughout your adventure, you will have to control yourself by typing commands.");
			Console.WriteLine ("Whenever an angle bracket \">\" is printed, you may enter any of the following commands:");
			printCommands ();
		}

		// Validate (y/n) input
		public static string ynTrap ()
		{
			bool valid = false;
			string input = "";

			while (valid == false) {
				Console.Write ("\n> ");
				input = Console.ReadLine ().ToLower ();
				switch (input) {
				case "y":
				case "n":
					valid = true;
					break;
				default:
					Console.WriteLine ("\nPlease enter a 'y' or 'n'.");
					break;
				}
			}

			return input;
		}

		// Print list of usable commands
		public static void printCommands ()
		{
			Console.WriteLine ("\nCOMMAND\t\tDESCRIPTION");
			Console.WriteLine ();
			Console.WriteLine ("look\t\tGives information on the current room");
			Console.WriteLine ("north\t\tMoves the character north");
			Console.WriteLine ("east\t\tMoves the character east");
			Console.WriteLine ("south\t\tMoves the character south");
			Console.WriteLine ("west\t\tMoves the character west");
			Console.WriteLine ();
			Console.WriteLine ("help\t\tShows manual");
			Console.WriteLine ("cmd\t\tLists these commands");
			Console.WriteLine ("quit\t\tExits the application");
		}
	}
}
