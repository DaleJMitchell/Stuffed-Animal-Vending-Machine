using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Penguin: StuffedAnimals

    {




        public string AnimalSound { get; } = "Squawk, Squawk, Whee!"; 
        public Penguin(string slot, string name, decimal price)
        {
            Slot = slot;
            Name = name;
            Price = price;
        }

    }
}

