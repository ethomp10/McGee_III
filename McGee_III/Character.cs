using System;

namespace McGee_III
{
	class Character
	{
		// Parameters
		public string Name { get; set; }
		public int Xpos { get; set; }
		public int Ypos { get; set; }
		public int Health { get; set; }

		// Constructor
		public Character (string name)
		{
			Name = name;
			Xpos = 0;
			Ypos = 0;
			Health = Constants.maxHealth;
		}

		// Movement commands
		public void MoveNorth (int max)
		{
			if (Ypos < max - 1) {
				Ypos++;
				Console.WriteLine ("\nX:\t{0}\nY:\t{1}", Xpos, Ypos);
			} else {
				Console.WriteLine ("\nA wall blocks your path.");
			}
		}

		public void MoveEast (int max)
		{
			if (Xpos < max - 1) {
				Xpos++;
				Console.WriteLine ("\nX:\t{0}\nY:\t{1}", Xpos, Ypos);
			} else {
				Console.WriteLine ("\nA wall blocks your path.");
			}
		}

		public void MoveSouth ()
		{
			if (Ypos > 0) {
				Ypos--;
				Console.WriteLine ("\nX:\t{0}\nY:\t{1}", Xpos, Ypos);
			} else {
				Console.WriteLine ("\nA wall blocks your path.");
			}
		}

		public void MoveWest ()
		{
			if (Xpos > 0) {
				Xpos--;
				Console.WriteLine ("\nX:\t{0}\nY:\t{1}", Xpos, Ypos);
			} else {
				Console.WriteLine ("\nA wall blocks your path.");
			}
		}
	}
}
