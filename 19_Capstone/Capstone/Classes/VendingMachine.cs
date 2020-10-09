using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        private FileLogger fileLogger = new FileLogger();
        public decimal CurrentMoneyProvided { get; set; } = 0;

        //Set up a SortedDictionary to store inventory
        public SortedDictionary<string, Product> vendingMachineInventory; 

        //Create a constructor for class 
        public VendingMachine(IEnumerable<Product> productList)
        {
            //Load the inventory Dictionary for lookup by SlotLocation - each Key will point to a product assigned to it 
            this.vendingMachineInventory = new SortedDictionary<string, Product>();

            //Loop through the products
            foreach (Product product in productList)
            {
                vendingMachineInventory[product.SlotLocation] = product;
            }
        }

        public string[] SlotLocations
        {
            //Return a string array of Slot Locations 
            get
            {
                List<string> slotLocations = new List<string>();

                //vendingMachineInventory.Keys gets us all Keys/Slot Locations
                foreach (string slot in vendingMachineInventory.Keys)
                {
                    slotLocations.Add(slot);
                }
                return slotLocations.ToArray();
            }
        }

        //public Product[] GetProductInfoForSlotLocation(string slot)
        //{
        //    //Return the product information for a specific Slot Location 
            
        //    //Looks up the slot location and returns the product info for the slot
        //    if (vendingMachineInventory.ContainsKey(slot))
        //    {
        //        return vendingMachineInventory[slot].ToArray();
        //    }

        //    return new List<Product>().ToArray();
        //}

        public void FeedMoneyToCurrentBalance(decimal inputAmount) //DONE
        {
            decimal initialBalance = CurrentMoneyProvided;
            CurrentMoneyProvided += inputAmount;
            fileLogger.AuditLogEntry("feedMoney", initialBalance, CurrentMoneyProvided, null);
        }

        public void PurchaseProduct(Product product)
        {
                             
            //Subtract 1 from quantity
            product.Quantity--;

            //Set initial balance for FileLogger

            decimal initialBalance = CurrentMoneyProvided;

            //Subtract price from current money 
            CurrentMoneyProvided -= product.Price;

            //Print item name, cost, money remaining, specialized message
            //Switch if we have time to menu 
            if (product.Type == "Chip")
            {
                Console.WriteLine($"{product.ProductName} | {product.Price}");
                Console.WriteLine($"Remaining Balance: {CurrentMoneyProvided}");
                Console.WriteLine("Crunch Crunch, Yum!");
            }
            else if (product.Type == "Candy")
            {
                Console.WriteLine($"{product.ProductName} | {product.Price}");
                Console.WriteLine($"Remaining Balance: {CurrentMoneyProvided}");
                Console.WriteLine("Munch Munch, Yum!");
            }
            else if (product.Type == "Drink")
            {
                Console.WriteLine($"{product.ProductName} | {product.Price}");
                Console.WriteLine($"Remaining Balance: {CurrentMoneyProvided}");
                Console.WriteLine("Glug Glug, Yum!");
            }
            else
            {
                Console.WriteLine($"{product.ProductName} | {product.Price}");
                Console.WriteLine($"Remaining Balance: {CurrentMoneyProvided}");
                Console.WriteLine("Chew Chew, Yum!");
            }

            //log date time, purchase, initial balance, current balance

            fileLogger.AuditLogEntry("purchase", initialBalance, CurrentMoneyProvided, product);
                            
        }

        public void ReturnChange()
        {
            int nickels = 0;
            int dimes = 0;
            int quarters = 0;
            decimal initialBalance = CurrentMoneyProvided;
            Console.WriteLine($"Remaining Balance: ${CurrentMoneyProvided}");
            while (CurrentMoneyProvided > 0)
            {
                if (CurrentMoneyProvided >= .25m)
                {
                    CurrentMoneyProvided -= 0.25m;
                    quarters++;
                }
                else if (CurrentMoneyProvided >= 0.10m)
                {
                    CurrentMoneyProvided -= .10m;
                    dimes++;
                }
                else
                {
                    CurrentMoneyProvided -= .05m;
                    nickels++;
                }
            }
            Console.WriteLine($"Your change is being distributed as {quarters} quarters, {dimes} dimes and {nickels} nickels. The current balance is {CurrentMoneyProvided}.");

            fileLogger.AuditLogEntry("giveChange", initialBalance, CurrentMoneyProvided, null);

        }

    }
}
