using System;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            VendingMachine unit = new VendingMachine(); //created a new vending machine
            
            unit.Startup();//running our startup method on "unit"

            Console.WriteLine(unit.inventory);//print our inventory
        }
    }
}
