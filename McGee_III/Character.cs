using System;
using System.Collections.Generic;

namespace McGee_III
{
	class Character
	{
		// Parameters
		public string Name { get; set; }
		public int Xpos { get; set; }
		public int Ypos { get; set; }
		public int Health { get; set; }
		public List<string> Inventory { get ; set; }

		// Constructor
		public Character (string name)
		{
			Name = name;
			Xpos = 0;
			Ypos = 0;
			Health = Constants.maxHealth;
			Inventory = new List<string> ();
		}

		// Movement commands
		public bool MoveNorth (int max)
		{
			if (Ypos < max - 1) {
				Ypos++;
				Console.WriteLine ("\nYou take a step to the north.");
				return true;
			} else {
				Console.WriteLine ("\nA wall blocks your path.");
				return false;
			}
		}

		public bool MoveEast (int max)
		{
			if (Xpos < max - 1) {
				Xpos++;
				Console.WriteLine ("\nYou take a step to the east.");
				return true;
			} else {
				Console.WriteLine ("\nA wall blocks your path.");
				return false;
			}
		}

		public bool MoveSouth ()
		{
			if (Ypos > 0) {
				Ypos--;
				Console.WriteLine ("\nYou take a step to the south.");
				return true;
			} else {
				Console.WriteLine ("\nA wall blocks your path.");
				return false;
			}
		}

		public bool MoveWest ()
		{
			if (Xpos > 0) {
				Xpos--;
				Console.WriteLine ("\nYou take a step to the west.");
				return true;
			} else {
				Console.WriteLine ("\nA wall blocks your path.");
				return false;
			}
		}

		// Other methods
		public void AddItem (string item)
		{
			if (HasItem (item) == false) {
				Inventory.Add (item);
				Console.WriteLine ("\nYou found a {0}!", item);
			} else {
				Console.WriteLine ("\nYou already have a {0}.", item);
			}
		}

		public bool HasItem (string item)
		{
			bool check = false;
			for (int i = 0; i < Inventory.Count; i++) {
				if (Inventory [i] == item) {
					check = true;
				}
			}
			return check;
		}

		public void ShowItems ()
		{
			if (Inventory.Count < 1) {
				Console.WriteLine ("\nThere's nothing here...");
			} else {
				Console.WriteLine ("\nYou have the following item(s):");
				for (int i = 0; i < Inventory.Count; i++) {
					Console.WriteLine ("- {0}", Inventory [i]);
				}
			}
		}
	}
}
