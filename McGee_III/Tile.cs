using System;

namespace McGee_III
{
	class Tile
	{
		// Properties
		public string Descripion { get; set; }
		public int Xpos { get; set; }
		public int Ypos { get; set; }
		public int Seed { get; set; }

		// Constructor
		public Tile (int x, int y, int seed)
		{
			Xpos = x;
			Ypos = y;
			Seed = seed;
			Descripion = string.Format ("Tile: ({0},{1})\tSeed: {2}", Xpos, Ypos, Seed);
		}

		// Methods
		public void Sense ()
		{
			Console.WriteLine ();
			Console.WriteLine (Descripion);
		}
	}
}
