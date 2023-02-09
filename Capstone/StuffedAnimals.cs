using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public abstract class StuffedAnimals
    {
        public string Slot { get; }
        public string Name { get; }

        public decimal Price { get; }

        public string Type { get; }

        public StuffedAnimals() { }



        public void AnimalSound()
        {

        }
    }
}
