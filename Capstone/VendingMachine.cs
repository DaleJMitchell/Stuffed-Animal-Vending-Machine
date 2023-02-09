using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        }

        public void ShowHomeScreen() 
        {
            Console.WriteLine("Hello! Please select 1, 2, 3:");
            Console.WriteLine("1) Display Items");
            Console.WriteLine("2) Purchase");
            Console.WriteLine("3) Exit");
            string userInput = Console.ReadLine();
            if (userInput == "1")
            {
                DisplayInventory();
            }
            else if (userInput == "2")
            {
                Purchase();
            }
            else if (userInput == "3")
            {
                Exit();
            }
        }

        public void DisplayInventory()
        {
            foreach (StuffedAnimals animal in inventory)
                {
                    Console.WriteLine($"{animal.Slot} | {animal.Name} | {animal.Price} | {animal.GetQuanity()}");
                }
        }
        
        
        decimal currentMoney = 0.00M;


        public void Purchase()
        {
            Console.WriteLine($"Current money provided: {currentMoney}"); 
            Console.WriteLine("1) Feed Money");
            Console.WriteLine("2) Select Product");
            Console.WriteLine("3) Finish Transation");
            string userInput = Console.ReadLine();
            if (userInput == "1")
            {
                FeedMoney();
            }
            else if (userInput == "2")
            {
                SelectProduct();
            }
            else if (userInput == "3")
            {
                FinishTransaction();
            }
        }

        public void FeedMoney()
        {
            int dollarInput = 0;
            Console.WriteLine("Please enter currency in whole dollar amounts:");
            try
            {
                dollarInput = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                currentMoney += dollarInput;
                Purchase();
            }
        }

        public void SelectProduct()
        {
            DisplayInventory();
            Console.WriteLine("Please choose an item (i.e. D2):");
            string userInput = Console.ReadLine();
            foreach (StuffedAnimals animal in inventory)
            {
                if (userInput == animal.Slot)
                {
                    animal.Quantity--;
                    Console.WriteLine($"{animal.Name} | {animal.Price} | current money: {currentMoney}");
                    animal.Message();
                    currentMoney -= animal.Price;
                }
                else if (animal.Quantity == 0)
                {
                    Console.WriteLine($"{animal.Name} sold out.");
                }
                else
                {
                    Console.WriteLine("Please choose a valid item.");
                }
                Purchase();
            }
        }
        //Getting stuck on A1, not looping through
        //We can buy even if we're sold out.........uhhhhhh.....

        public void FinishTransaction()
        {

        }


        public void Exit()
        {
            Console.WriteLine("Thank you for using the Vendo-Matic 800");

            //maybe find a way to make the console close automatically later.........Environment.Exit(0);
        }


            
        






    }
}
