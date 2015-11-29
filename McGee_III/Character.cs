using System;

namespace McGee_III
{
    public class Character
    {
        // Parameters
		public string Name;
		public int Xpos;
		public int Ypos;
		public int Health; //{ get; set; }

		public void moveNorth()
		{
			int yPre = Ypos;
			if (Ypos > 0) {
				Ypos--;
				Console.WriteLine ("\nYou moved from {1},{0} to {2},{0}.", Xpos, yPre, Ypos);
			} else {
				Console.WriteLine ("\nYou cannot go that way.");
			}
		}

		public void moveEast()
		{
			int xPre = Xpos;
			if (Xpos < 2) {
				Xpos++;
				Console.WriteLine ("\nYou moved from {0},{1} to {0},{2}.", Ypos, xPre, Xpos);
			} else {
				Console.WriteLine ("\nYou cannot go that way.");
			}
		}

		public void moveSouth()
		{
			int yPre = Ypos;
			if (Ypos < 2) {
				Ypos++;
				Console.WriteLine ("\nYou moved from {1},{0} to {2},{0}.", Xpos, yPre, Ypos);
			} else {
				Console.WriteLine ("\nYou cannot go that way.");
			}
		}

		public void moveWest()
		{
			int xPre = Xpos;
			if (Xpos > 0) {
				Xpos--;
				Console.WriteLine("\nYou moved from {0},{1} to {0},{2}", Ypos, xPre, Xpos);
			} else {
				Console.WriteLine ("\nYou cannot go that way.");
			}
		}

        // Constructor
        public Character(string name)
        {
            Name = name;
			Xpos = 0;
			Ypos = 0;
            Health = Constants.maxHealth;
        }
    }
}
