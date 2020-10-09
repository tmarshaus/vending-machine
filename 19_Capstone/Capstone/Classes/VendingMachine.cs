using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    

    public class VendingMachine
    {

        public decimal CurrentMoneyProvided { get; set; } = 0;

        //Set up a SortedDictionary to store inventory
        public SortedDictionary<string, List<Product>> vendingMachineInventory; 

        //Create a constructor for class 
        public VendingMachine(IEnumerable<Product> productList)
        {
            //Load the inventory Dictionary for lookup by SlotLocation - each Key will point to a product assigned to it 
            this.vendingMachineInventory = new SortedDictionary<string, List<Product>>();

            //Loop through the products
            foreach (Product product in productList)
            {
                if (!vendingMachineInventory.ContainsKey(product.SlotLocation))
                {
                    //Add the KVP with SlotLocation as the Key and a new empty List<product> as the value
                    vendingMachineInventory[product.SlotLocation] = new List<Product>();
                }

                vendingMachineInventory[product.SlotLocation].Add(product);

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

        public Product[] GetProductInfoForSlotLocation(string slot)
        {
            //Return the product information for a specific Slot Location 
            
            //Looks up the slot location and returns the product info for the slot
            if (vendingMachineInventory.ContainsKey(slot))
            {
                return vendingMachineInventory[slot].ToArray();
            }

            return new List<Product>().ToArray();

        }

        public void FeedMoneyToCurrentBalance(decimal inputAmount) //DONE
        {
            CurrentMoneyProvided += inputAmount;
        }

        public void PurchaseProduct(Product userInputKey)
        {
                             
            //Subtract 1 from quantity
            userInputKey.Quantity--;

            //Subtract price from current money 
            CurrentMoneyProvided -= userInputKey.Price;

            //Print item name, cost, money remaining, specialized message
            if (userInputKey.Type == "Chip")
            {
                Console.WriteLine($"{userInputKey.ProductName} | {userInputKey.Price}");
                Console.WriteLine($"Remaining Balance: {CurrentMoneyProvided}");
                Console.WriteLine("Crunch Crunch, Yum!");
            }
            else if (userInputKey.Type == "Candy")
            {
                Console.WriteLine($"{userInputKey.ProductName} | {userInputKey.Price}");
                Console.WriteLine($"Remaining Balance: {CurrentMoneyProvided}");
                Console.WriteLine("Munch Munch, Yum!");
            }
            else if (userInputKey.Type == "Drink")
            {
                Console.WriteLine($"{userInputKey.ProductName} | {userInputKey.Price}");
                Console.WriteLine($"Remaining Balance: {CurrentMoneyProvided}");
                Console.WriteLine("Glug Glug, Yum!");
            }
            else
            {
                Console.WriteLine($"{userInputKey.ProductName} | {userInputKey.Price}");
                Console.WriteLine($"Remaining Balance: {CurrentMoneyProvided}");
                Console.WriteLine("Chew Chew, Yum!");
            }

            //log date time, purchase, initial balance, current balance
                            
        }

        public void ReturnChange()
        {
            int nickels = 0;
            int dimes = 0;
            int quarters = 0;

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
        }

    }
}
