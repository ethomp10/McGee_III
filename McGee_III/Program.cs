using System;

namespace McGee_III
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("+ ----------------------------------- +");
			Console.WriteLine ("|   The Adventure of Mrs. McGee III   |");
			Console.WriteLine ("+ ----------------------------------- +");
			Console.WriteLine ("            ~ Press Enter ~            ");
			Console.ReadLine ();
			Console.Clear ();

			Console.Write ("Please enter your name, adventurer.\n\n> ");
			Character player = new Character (Console.ReadLine ());
			Console.WriteLine ("\nWelcome, Mrs. {0} McGee!", player.Name);
			Console.WriteLine ("\nI understand you may be a new player.");
			Console.WriteLine ("\nWould you like a tutorial? (y/n)"); ynTrap ();


		
//				
//			if (input == "y") {
//				// Run help command
//			} else if (input == "n") {
//				Console.WriteLine ("Very well, enjoy your adventure, {0}!", player.Name);
//			} else {
//				
		



//			while (input != "quit") {
//				Console.Write ("\n> ");
//				input = Console.ReadLine ().ToLower ();
//			}
		}

		public static void ynTrap ()
		{
			
		}
	}
}
