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
		public bool IsDoor { get; set; }

		// Constructor
		public Tile (int x, int y, int seed, bool door)
		{
			Xpos = x;
			Ypos = y;
			Seed = seed;
			IsDoor = door;
			Descripion = MakeDescription ();
		}

		// Methods
		public string MakeDescription ()
		{
			if (IsDoor == true) {
				return "You feel a door beneath your feet...";
			} else {
				if ((Seed >= 0) && (Seed <= 200)) {
					return "There are a few stones and cracks in the floor.";
				} else if ((Seed >= 201) && (Seed <= 400)) {
					return "You feel a mouse crawl over your foot... gross.";
				} else if ((Seed >= 401) && (Seed <= 600)) {
					return "Nothing but dust.";
				} else if ((Seed >= 601) && (Seed <= 800)) {
					return "You feel water dripping from the ceiling.";
				} else {
					return "You can feel rust on this part of the floor.";
				}
			}
		}

		public void Sense ()
		{
			Console.WriteLine (Descripion);
			Console.WriteLine ("Position: ({0},{1})", Xpos, Ypos);
		}
	}
}
