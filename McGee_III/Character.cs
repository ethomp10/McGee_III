using System;

namespace McGee_III
{
    public class Character
    {
        // Parameters
        public string Name { get; set; }
        public int Health { get; set; }

        // Constructor
        public Character(string name)
        {
            Name = name;
            Health = Constants.maxHealth;
        }
    }
}
