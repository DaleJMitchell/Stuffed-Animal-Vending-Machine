using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class StuffedAnimals
    {
        public string Slot { get; set; }
        public string Name { get; set;  }
        public decimal Price { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; } = 5;

        public StuffedAnimals(string slot, string name, decimal price, string type) 
        { 
            Slot= slot;
            Name= name;
            Price= price;
            Type= type;
        }

        public string GetQuanity() 
        {
            if (Quantity > 0)
            {                 
                return $"There are {Quantity} {Type}(s) remaining";
            }
            else 
            {
                return "SOLD OUT...Please select another item";
            }
        }

        public void Message()
        {
            if (Type == "Duck")
            {
                Console.WriteLine("Quack, Quack, Splash!");
            }
            if (Type == "Penguin")
            {
                Console.WriteLine("Squawk, Squawk, Whee!");
            }
            if (Type == "Cat")
            {
                Console.WriteLine("Meow, Meow, Meow!");
            }
            if (Type == "Pony")
            {
                Console.WriteLine("Neigh, Neigh, Yay!");
            }
        }
    }
}
