using System;

namespace McGee_III
{
    public class Tile
    {
        // Properties
        public string Descripion;
        public int Xpos;
        public int Ypos;
        public int Seed;

        public void sense()
        {
            Console.WriteLine();
            Console.WriteLine(Descripion);
        }

        // Constructor
        public Tile(int x, int y, int seed)
        {
            Xpos = x;
            Ypos = y;
            Seed = seed;
            Descripion = string.Format("Tile: ({0},{1})\tSeed: {2}", Xpos, Ypos, Seed);
        }
    }
}
