using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Pony : StuffedAnimals
    {

        public string AnimalSound { get; } = "Neigh, Neigh, Yay!";
        public Pony(string slot, string name, decimal price)
        {
            Slot = slot;
            Name = name;
            Price = price;
        }

    }
}
