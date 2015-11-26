using System;

namespace McGee_III
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			string input = "";

			Console.WriteLine ("+ ----------------------------------- +");
			Console.WriteLine ("|   The Adventure of Mrs. McGee III   |");
			Console.WriteLine ("+ ----------------------------------- +");
			Console.WriteLine ("            ~ Press Enter ~            ");
			Console.ReadLine ();

			Console.Clear ();
			Console.Write ("Please enter your name, adventurer.\n\n> ");
			Character player = new Character (Console.ReadLine ());

			Console.WriteLine ("\nWelcome, Mrs. {0} McGee!", player.Name);

			while (input != "quit") {
				Console.Write ("\n> ");
				input = Console.ReadLine ().ToLower ();
			}
		}
	}
}
