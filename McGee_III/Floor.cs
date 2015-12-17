using System;

namespace McGee_III
{
	class Floor
	{
		Random rnd = new Random ();

		// Properties
		public Tile[,] Room { get; set; }
		public int Level { get; set; }
		public int Size { get; set; }

		// Constructor
		public Floor (int level)
		{
			Level = level;
			Size = Level * 2 + 1;

			// Determine door's location
			int doorX = rnd.Next (Size);
			int doorY = rnd.Next (Size);
			bool door;

			// Generate floor
			Room = new Tile[Size, Size];
			for (int y = 0; y < Size; y++) {
				for (int x = 0; x < Size; x++) {
					if ((x == doorX) && (y == doorY)) {
						door = true;
					} else {
						door = false;
					}
					Room [x, y] = new Tile (x, y, rnd.Next (1000), door);
				}
			}
		}

		// Debug
		public void PrintTiles ()
		{
			string tag;

			Console.WriteLine ();
			for (int y = 0; y < Size; y++) {
				for (int x = 0; x < Size; x++) {
					if (Room [x, y].IsDoor == true) {
						tag = "[DOOR]";
					} else {
						tag = "[TILE]";
					}
					Console.WriteLine ("{0} ({1},{2})\tDescription: {3}", tag, x, y, Room [x, y].Descripion);
				}
			}
		}
	}
}
