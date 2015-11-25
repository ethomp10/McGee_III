using System;

namespace McGee_III
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");

			Character player = new Character ();
			player.name = Console.ReadLine ();
			Console.WriteLine ("{0}", player.name);
			Console.WriteLine ("{0}", Constants.maxHealth);
		}
	}
}
