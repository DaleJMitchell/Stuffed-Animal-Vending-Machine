using System;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            VendingMachine unit = new VendingMachine(); //created a new vending machine
            
            unit.Startup();//running our intial startup method on "unit"
            unit.ShowHomeScreen();

        }
    }
}
