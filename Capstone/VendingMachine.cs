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
            ShowHomeScreen(); 
        }


        decimal currentMoney = 0.00M;


        public void Purchase()
        {
            Console.WriteLine($"Current money provided: {currentMoney}");
            Console.WriteLine("1) Feed Money");
            Console.WriteLine("2) Select Product");
            Console.WriteLine("3) Finish Transation");
            string userInput = Console.ReadLine();

            //Dictionary<string, StuffedAnimals> animalDict = new Dictionary<string, StuffedAnimals>();

            //foreach (StuffedAnimals animal in inventory)
            //{
            //    animalDict.Add(animal.Slot, animal);
            //}

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
            userInput= userInput.ToUpper(); 

            Dictionary<string, StuffedAnimals> animalDict = new Dictionary<string, StuffedAnimals>();

            foreach (StuffedAnimals singleAnimal in inventory)
            {
                animalDict.Add(singleAnimal.Slot, singleAnimal);
            }

            StuffedAnimals animal = animalDict[userInput];

            if (userInput == animal.Slot && animal.Quantity > 0)
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
            else if(currentMoney <animal.Price)
            {
                Console.WriteLine("Insufficient funds, add money or select new option."); 
            }
            else
            {
                Console.WriteLine("Please choose a valid item.");
            }
            Purchase();
        }



        //foreach (StuffedAnimals animal in inventory)
        //{
        //    if (userInput == animal.Slot)
        //    {
        //        animal.Quantity--;
        //        Console.WriteLine($"{animal.Name} | {animal.Price} | current money: {currentMoney}");
        //        animal.Message();
        //        currentMoney -= animal.Price;
        //    }
        //    else if (animal.Quantity == 0)
        //    {
        //        Console.WriteLine($"{animal.Name} sold out.");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Please choose a valid item.");
        //    }
        int numberDollars = 0;
        int numberQuarters = 0;
        int numberDimes = 0;
        int numberNickels = 0; 
        
        public void GiveChange()
        {
            while(currentMoney > 0M)
            {
                if(currentMoney >= 1.00M)
                {
                    currentMoney -= 1.00M; 
                    numberDollars++; 
                }
               else if (currentMoney < 1.00M && currentMoney >= .25M)
                {
                    currentMoney -= .25M;
                    numberQuarters++;
                }
                else if (currentMoney <.25M && currentMoney >= .10M)
                {
                    currentMoney -= .10M;
                    numberDimes++;
                
                }
               else if (currentMoney < .10M && currentMoney >=.05M)
                {
                    currentMoney -= .05M;
                    numberNickels++;
                }
                else
                {
                    currentMoney = currentMoney; 
                }
            }
            string heresYourChange = "Your change is ";
            if (numberDollars > 0)
            {
                heresYourChange += $"{numberDollars} dollars ";
            }
            if (numberQuarters > 0)
            {
                heresYourChange += $"{numberQuarters} quarters ";
            }
            if (numberDimes > 0)
            {
                heresYourChange += $"{numberDimes} dimes ";
            }
            if (numberNickels > 0)
            {
                heresYourChange += $"{numberNickels} nickels";
            }
            Console.WriteLine($"{heresYourChange} ");
            Console.WriteLine($"Current Balance: {currentMoney}"); 
            ShowHomeScreen(); 
        }
        
        
        
        
        
        
        public void FinishTransaction()
        {
            GiveChange(); 
        }


        public void Exit()
        {
            Console.WriteLine("Thank you for using the Vendo-Matic 800");

            //maybe find a way to make the console close automatically later.........Environment.Exit(0);
        }
    }
}
//Getting stuck on A1, not looping through
//We can buy even if we're sold out.........uhhhhhh.....
