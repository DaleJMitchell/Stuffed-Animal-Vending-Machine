using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Cat:StuffedAnimals
    {


        public string AnimalSound { get; } = "Meow, Meow, Meow";
        public Cat(string slot, string name, decimal price)
        {
            Slot = slot;
            Name = name;
            Price = price;
        }

    }
} 
