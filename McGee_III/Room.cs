using System;

namespace McGee_III
{
    class Room
    {
        enum Types { Safe, Door }

        // Properties
        public string Descripion;
        public int Xpos;
        public int Ypos;
        public int Type;
        public int Seed;

        public void sense()
        {
            // THIS NEEDS REWORKING
            if (Xpos == 0)
            {
                Console.Write("\nYou feel a wall to the west");
                if (Ypos == 0)
                {
                    Console.Write(" and south.");
                }
                else if (Ypos == 2)
                {
                    Console.Write(" and north.");
                }
                else
                {
                    Console.Write(".");
                }
            }
        }

        // Constructor
        public Room(int seed, int x, int y)
        {
            Xpos = x;
            Ypos = y;
            Seed = seed;
            Descripion = "Seed:\t" + Seed;
        }
    }
}
