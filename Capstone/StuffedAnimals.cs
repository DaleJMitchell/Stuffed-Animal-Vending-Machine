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
        public string Message 
        {
            get
            {
                if (Type == "Duck")
                {
                    return "Quack, Quack, Splash!";
                }
                else if (Type == "Penguin")
                {
                    return "Squawk, Squawk, Whee!";
                }
                else if (Type == "Cat")
                {
                    return "Meow, Meow, Meow!";
                }
                else if (Type == "Pony")
                {
                    return "Neigh, Neigh, Yay!";
                }
                else
                {
                    return "";
                }
            }
        }

        public StuffedAnimals(string slot, string name, decimal price, string type) 
        { 
            Slot= slot;
            Name= name;
            Price= price;
            Type= type;
        }

        public string ShowQuanity() //can be tested
        {
            if (Quantity > 0)
            {                 
                string message = $"There are {Quantity} {Type}(s) remaining";
                return message;                
            }
            else
            {
                string soldOut = "SOLD OUT...Please select another item";
                return soldOut;
            }
        }
    }
}
