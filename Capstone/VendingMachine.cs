using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Capstone
{
    public class VendingMachine
    {
        public int InventoryQuantity { get; set; }

        public List<StuffedAnimals> inventory = new List<StuffedAnimals>();//possible for loop look for 3rd index for type 

        public void Startup()
        {            
            string filePath = @"C:\Users\Student\workspace\c-sharp-minicapstonemodule1-team0\vendingmachine.csv"; //this is our inv.txt where all our items live
            try
            {
                using (StreamReader sr = new StreamReader(filePath))//read our filepath
                {                  
                                       
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine(); //reading each line
                        string[] lineArray = line.Split("|");//split each line into seperate indexes
                                             
                        StuffedAnimals item = new StuffedAnimals(lineArray[0], lineArray[1], decimal.Parse(lineArray[2]), lineArray[3]);//feeding our constructor values and parsing our price to be monies and not a string
                        inventory.Add(item);//adds the line to the list                        
                    } 
                }
            }
            catch (Exception ex)
            { 
                Console.WriteLine("oops try again");
                Console.WriteLine(ex.Message);
            }
            
            Console.WriteLine("Welcome to Vendo-Matic 800");

            Console.WriteLine("Hello! Please select 1, 2, 3:");
                Console.WriteLine("1) Display Items");
                Console.WriteLine("2) Purchase");
                Console.WriteLine("3) Exit");
           
            string userInput = Console.ReadLine();
            if (userInput == "1") 
            {
                foreach (StuffedAnimals animal in inventory) 
                {
                    Console.WriteLine($"{animal.Slot} | {animal.Name} | {animal.Price} | {animal.GetQuanity()}");
                }
               
            }
            if (userInput == "2") 
            { 
            
            }
            if (userInput == "3")
            {
                Console.WriteLine("Thank you for using the Vendo-Matic 800");
                
                 //maybe find a way to make the console close automatically later.........Environment.Exit(0);
            }





        }
        






    }
}
