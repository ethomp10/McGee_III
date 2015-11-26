using System;

namespace McGee_III
{
    class Room
    {
        // Properties
        public string Name { get; set; }
        public int Level { get; set; }
        public string Descripion { get; set; }
        public bool Enemy { get; set; }

        public bool rollEnemy()
        {
            int roll;
            int chance = 7 - Level; // Increases spawn chance based on level

            Random rnd = new Random();
            roll = rnd.Next(chance);
            if ((roll == 0) && (Level != 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Constructor
        public Room(string name, int level, string description)
        {
            Name = name;
            Level = level;
            Descripion = description;
            Enemy = rollEnemy();
        }
    }
}
