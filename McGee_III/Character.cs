using System;

namespace McGee_III
{
    public class Character
    {
        // Parameters
        public string Name;
        public int Xpos;
        public int Ypos;
        public int Health;

        public void moveNorth()
        {
            if (Ypos < 2)
            {
                Ypos++;
                Console.WriteLine("\nY:\t{0}\nX:\t{1}", Xpos, Ypos);
            }
            else
            {
                Console.WriteLine("\nA wall blocks your path.");
            }
        }

        public void moveEast()
        {
            if (Xpos < 2)
            {
                Xpos++;
                Console.WriteLine("\nY:\t{0}\nX:\t{1}", Xpos, Ypos);
            }
            else
            {
                Console.WriteLine("\nA wall blocks your path.");
            }
        }

        public void moveSouth()
        {
            if (Ypos > 0)
            {
                Ypos--;
                Console.WriteLine("\nY:\t{0}\nX:\t{1}", Xpos, Ypos);
            }
            else
            {
                Console.WriteLine("\nA wall blocks your path.");
            }
        }

        public void moveWest()
        {
            if (Xpos > 0)
            {
                Xpos--;
                Console.WriteLine("\nY:\t{0}\nX:\t{1}", Xpos, Ypos);
            }
            else
            {
                Console.WriteLine("\nA wall blocks your path.");
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
