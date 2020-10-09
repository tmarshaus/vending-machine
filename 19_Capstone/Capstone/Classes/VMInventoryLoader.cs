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
            string filePath = @"..\..\..\..\vendingmachine.csv";

            //We will use a SortedDictionary derived from this list in the VendingMachine Class 
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
                        Product product = new Product(slotLocation, productName, price, type);
                        vendingMachineProducts.Add(product);
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
