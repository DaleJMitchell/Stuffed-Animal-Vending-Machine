using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Duck: StuffedAnimals 
    {
        public string AnimalSound { get; } = "Quack, Quack, Splach!";

        public Duck(string slot, string name, decimal price)
        {
            Slot = slot;
            Name = name;
            Price = price;
        }


    }
}
