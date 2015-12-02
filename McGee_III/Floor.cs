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
			Room = new Tile[Size, Size];
			for (int y = 0; y < Size; y++) {
				for (int x = 0; x < Size; x++) {
					Room [x, y] = new Tile (x, y, rnd.Next (1000));
				}
			}
		}

		// DEBUG
		public void PrintTiles ()
		{
			Console.WriteLine ();
			for (int y = 0; y < Size; y++) {
				for (int x = 0; x < Size; x++) {
					Console.WriteLine (Room [x, y].Descripion);
				}
			}
		}
	}
}
