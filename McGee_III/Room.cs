using System;

namespace McGee_III
{
    class Room
    {
        // Properties
        public int Seed;
		public string Descripion;

        // Constructor
		public Room(int seed)
        {
			Seed = seed;
			Descripion = "Seed:\t" + Seed;
        }
    }
}
