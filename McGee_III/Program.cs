using System;

namespace McGee_III
{
	class MainClass
	{
		public static void Main ()
		{
			Console.Title = "The Adventure of Mrs. McGee III";

			// Variables
			string input;
			bool runGame = true;
			Character player;
			Floor current;
			Tile local;

			KwameMessage ();

			// Start
			Console.WriteLine ("+ ----------------------------------- +");
			Console.WriteLine ("|   The Adventure of Mrs. McGee III   |");
			Console.WriteLine ("+ ----------------------------------- +");
			Console.WriteLine ("            ~ Press Enter ~            ");
			Console.ReadLine ();
			Console.Clear ();

			Console.WriteLine ("You awaken to complete darkness...");
			Console.WriteLine ("In fact, it was hard to tell you were awake at first.");
			Console.WriteLine ("How did you get here?");
			Console.WriteLine ("You don't remember.");
			Console.Write ("The only thing you can remember is your name...\n\n> ");
			input = Console.ReadLine ();
			if (input == "") {
				Console.WriteLine ("\n... come to think of it, you can't seem to remember that either.");
			} else {
				Console.WriteLine ("\n... of course, Mrs. {0} McGee.", input);
				Console.WriteLine ("That's something at least.");
			}
			player = new Character (input);
			Console.WriteLine ("Either way, you have to find your way out of here.");
			Console.WriteLine ("\nI understand you may be a new player.");
			Console.WriteLine ("Would you like to view a list of commands? (y/n)");
			input = YNTrap ();

			if (input == "y") {
				ShowHelp ();
				Console.WriteLine ("\nGood luck, {0}!", player.Name);
			} else if (input == "n") {
				Console.WriteLine ("\nVery well, good luck {0}!", player.Name);
			}

			// Make map
			current = new Floor (0);

			// Game loop
			while (runGame == true) {
				local = current.Room [player.Xpos, player.Ypos];
				Console.Write ("\n> ");
				input = Console.ReadLine ().ToLower ();
				switch (input) {

				// Debug commands
				case "debug":
				case "~":
					ShowDebug ();
					break;
				case "/map":
				case "/m":
					current.PrintTiles ();
					break;
				case "/key":
				case "/k":
					player.AddItem ("key");
					break;
				case "/potion":
				case "/p":
					player.AddItem ("potion");
					break;
				case "/dump":
				case "/d":
					player.Inventory.Remove ("key");
					player.Inventory.Remove ("potion");
					Console.WriteLine ("\nInventory cleared.");
					break;
				
				// Player commands
				case "north":
				case "w":
					if (player.MoveNorth (current.Size) == true) {
						local = current.Room [player.Xpos, player.Ypos];
						local.Sense ();

					}
					break;
				case "east":
				case "d":
					if (player.MoveEast (current.Size) == true) {
						local = current.Room [player.Xpos, player.Ypos];
						local.Sense ();
					}
					break;
				case "south":
				case "s":
					if (player.MoveSouth () == true) {
						local = current.Room [player.Xpos, player.Ypos];
						local.Sense ();
					}
					break;
				case "west":
				case "a":
					if (player.MoveWest () == true) {
						local = current.Room [player.Xpos, player.Ypos];
						local.Sense ();
					}
					break;
				case "sense":
				case "f":
					Console.WriteLine ();
					local.Sense ();
					break;
				case "open":
				case "e":
					if (local.IsDoor == true) {
						if (player.HasItem ("key") == true) {
							Console.WriteLine ("\nYou use the key to open the door, but it gets stuck in the lock.");
							player.Inventory.Remove ("key");
							Console.WriteLine ("Carefully, you slip through the hole to the floor below.");
							Console.WriteLine ("The echo of your feet hitting the floor seems to reverberate more...");
							Console.WriteLine ("This floor must be larger than before.");
							current = new Floor (current.Level + 1);
							player.Xpos++;
							player.Ypos++;
						} else {
							Console.WriteLine ("\nThe door is locked.");
						}
					} else {
						Console.WriteLine ("\nThere is nothing to open.");
					}
					break;
				case "bag":
				case "i":
					player.ShowItems ();
					break;
				case "help":
				case "?":
					ShowHelp ();
					break;
				case "quit":
				case "q":
					Console.WriteLine ("\nAre you sure you want to quit? (y/n)");
					input = YNTrap ();
					if (input == "y") {
						runGame = false;
					} else if (input == "n") {
						Console.WriteLine ("\nDidn't think so!");
					}
					break;
				default:
					Console.WriteLine ("\nI don't understand this command.");
					Console.WriteLine ("Type \"help\" for a list of usable commands.");
					break;
				}
			}
		}

		// Validate (y/n) input
		public static string YNTrap ()
		{
			bool valid = false;
			string input = "";

			while (valid == false) {
				Console.Write ("\n> ");
				input = Console.ReadLine ().ToLower ();
				switch (input) {
				case "y":
				case "yes":
					input = "y";
					valid = true;
					break;
				case "n":
				case "no":
					input = "n";
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
		public static void ShowHelp ()
		{
			Console.WriteLine ("\nCOMMAND | ALT\tDESCRIPTION\n");
			Console.WriteLine ("  north | w\tMoves your character north");
			Console.WriteLine ("   west | a\tMoves your character west");
			Console.WriteLine ("  south | s\tMoves your character south");
			Console.WriteLine ("   east | d\tMoves your character east");
			Console.WriteLine ("   open | e\tOpens a locked door (only works if your character has a key)");
			Console.WriteLine ("  sense | f\tGives information on your character's surroundings");
			Console.WriteLine ("    bag | i\tShows your character's inventory");
			Console.WriteLine ("\n   help | ?\tShows these commands");
			Console.WriteLine ("  debug | ~\tShows debug commands (for Kwame only)");
			Console.WriteLine ("   quit | q\tExits the application");
		}

		public static void ShowDebug ()
		{
			Console.WriteLine ("\nCOMMAND | ALT\tDESCRIPTION\n");
			Console.WriteLine ("   /map | /m\tPrints each tile's position and description");
			Console.WriteLine ("   /key | /k\tAdds a key to your character's inventory");
			Console.WriteLine ("/potion | /p\tAdds a potion to your character's inventory");
			Console.WriteLine ("  /dump | /d\tEmpties your character's inventory");
		}

		public static void KwameMessage ()
		{
			string input;

			Console.WriteLine ("Hey Kwame,");

			Console.WriteLine ("\nSo I realize my game doesn't really have most of the requirements for the assignment.");
			Console.WriteLine ("In high school, I did a text-based RPG that was pretty much identical to this project,");
			Console.WriteLine ("so instead of simply copying that over, I wanted to challenge myself by trying something");
			Console.WriteLine ("a little different.");

			Console.WriteLine ("\nThe goal of my game is to descend a pyramid in complete darkness. You have to find a");
			Console.WriteLine ("trap door on each floor, and unlock it with a key. My game does make use of multiple");
			Console.WriteLine ("classes, properties and includes several commands that the user can type when prompted.");
			Console.WriteLine ("In addition, it has collision detection, dynamically sized rooms (based on the player’s");
			Console.WriteLine ("depth in the pyramid) and a very basic inventory system that the player can view at any");
			Console.WriteLine ("time.");

			Console.WriteLine ("\nI was unable to complete the game 100%, but it does have a pretty modular skeleton that");
			Console.WriteLine ("could easily be improved upon. Because there are still some missing components (such as");
			Console.WriteLine ("item spawns and obstacles), I’ve included a few debug commands so you can manipulate your");
			Console.WriteLine ("inventory and see layout of each floor.");

			Console.WriteLine ("\nI hope this is enough to get me a decent mark, I wanted to talk to you about this earlier");
			Console.WriteLine ("and see if it was acceptable, but I couldn’t get a hold of you. I sincerely hope you enjoy");
			Console.WriteLine ("my game!");

			Console.WriteLine ("\nType \"I have read the terms and conditions\" to continue.");

			Console.Write ("\n> ");
			input = Console.ReadLine ().ToLower ();

			while (input != "i have read the terms and conditions") {
				Console.WriteLine ("\nPlease type \"I have read the terms and conditions\" to continue.");
				Console.Write ("\n> ");
				input = Console.ReadLine ().ToLower (); 
			}

			Console.Clear ();
		}
	}
}
