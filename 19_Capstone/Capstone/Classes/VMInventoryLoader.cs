using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class VMInventoryLoader 
    {
        public IEnumerable<Product> StockProducts()
        {
            //Use a hardcoded file path for now - Can talk to Mike about adding .csv file to the .exe file
            string filePath = @"C:\Users\Student\Git\c-module-1-capstone-team-7\19_Capstone\vendingmachine.csv";

            //We will use a SortedDictionary derived from this list in VendingMachine Class 
            try
            {
                //Create a new List of Product for the inventory in the csv file
                List<Product> vendingMachineProducts = new List<Product>();

                //Open the file
                using (StreamReader streamReader = new StreamReader(filePath))
                {
                    while (!streamReader.EndOfStream)
                    {
                        string input = streamReader.ReadLine();
                        string[] fields = input.Split("|");
                        string slotLocation = fields[0];
                        string productName = fields[1];
                        decimal price = decimal.Parse(fields[2]);
                        string type = fields[3];
                    }
                }
                return vendingMachineProducts;
            }
            catch(IOException exception)
            {
                Console.WriteLine("There is an error reading the file");
                Console.WriteLine(exception.Message);
                return new List<Product>();
            }
        }
    }
}
