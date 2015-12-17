﻿using System;

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

			// Start
//			Console.WriteLine ("+ ----------------------------------- +");
//			Console.WriteLine ("|   The Adventure of Mrs. McGee III   |");
//			Console.WriteLine ("+ ----------------------------------- +");
//			Console.WriteLine ("            ~ Press Enter ~            ");
//			Console.ReadLine ();
//			Console.Clear ();
//
//			Console.WriteLine ("You awaken to complete darkness...");
//			Console.WriteLine ("In fact, it was hard to tell you were awake at first.");
//			Console.WriteLine ("How did you get here?");
//			Console.WriteLine ("You don't remember.");
//			Console.Write ("The only thing you can remember is your name...\n\n> ");
//			input = Console.ReadLine ();
//			if (input == "") {
//				Console.WriteLine ("\n... come to think of it, you can't seem to remember that either.");
//			} else {
//				Console.WriteLine ("\n... of course, Mrs. {0} McGee.", input);
//				Console.WriteLine ("That's something at least.");
//			}
//			player = new Character (input);
			player = new Character ("Eric");
//			Console.WriteLine ("Either way, you have to find your way out of here.");
//			Console.WriteLine ("\nI understand you may be a new player.");
//			Console.WriteLine ("Would you like to view a list of commands? (y/n)");
//			input = ynTrap ();
//
//			if (input == "y") {
//				showHelp ();
//				Console.WriteLine ("\nGood luck, {0}!", player.Name);
//			} else if (input == "n") {
//				Console.WriteLine ("\nVery well, good luck {0}!", player.Name);
//			}

			// Make map
			current = new Floor (0);

			// Game loop
			while (runGame == true) {
				local = current.Room [player.Xpos, player.Ypos];
				Console.Write ("\n> ");
				input = Console.ReadLine ().ToLower ();
				switch (input) {

				// Debug commands
				case "map":
					current.PrintTiles ();
					break;
				case "add potion":
					player.AddItem ("potion");
					break;
				case "add key":
					player.AddItem ("key");
					break;
				case "fall":
					current = new Floor (current.Level + 1);
					current.PrintTiles ();
					player.Inventory.Remove ("key");
					player.Xpos++;
					player.Ypos++;
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
				case "e":
					Console.WriteLine ();
					local.Sense ();
					break;
				case "open":
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
					showHelp ();
					break;
				case "quit":
				case "q":
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
					Console.WriteLine ("Type \"help\" for a list of usable commands.");
					break;
				}
			}
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
		public static void showHelp ()
		{
			Console.WriteLine ("\nCOMMAND | ALT\tDESCRIPTION\n");
			Console.WriteLine ("  north | w\tMoves your character north");
			Console.WriteLine ("   west | a\tMoves your character west");
			Console.WriteLine ("  south | s\tMoves your character south");
			Console.WriteLine ("   east | d\tMoves your character east");
			Console.WriteLine ("  sense | e\tGives information on your character's surroundings");
			Console.WriteLine ("    bag | i\tShows your character's inventory");
			Console.WriteLine ("\n   help | ?\tShows these commands");
			Console.WriteLine ("   quit | q\tExits the application");
		}
	}
}
