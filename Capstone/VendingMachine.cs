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

        public List<StuffedAnimals> inventory = new List<StuffedAnimals>();

        public void Startup()
        {
            
            string filePath = "\"C:\\Users\\Student\\workspace\\c-sharp-minicapstonemodule1-team0\\vendingmachine.csv\"";
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] lineArray =  line.Split("|");
                        

                        
                    }
                }
                
            }
        }

    }
        

        
        

    



}
