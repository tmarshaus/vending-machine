using Capstone.Classes;
using MenuFramework;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Capstone.UI
{
    public class PurchaseMenu : ConsoleMenu
    {

        private VendingMachine VendingMachine;
        public decimal CurrentMoneyProvided { get; set; } = 0;

        public PurchaseMenu(VendingMachine vendingMachine)
        {
            AddOption("Feed Money", FeedMoney);
            AddOption("Select Product", SelectProduct);
            AddOption("Finish Transaction", FinishTransaction);
            
            //Display current money provided 

            Configure(cfg =>
                {
                    cfg.ItemForegroundColor = ConsoleColor.Yellow;
                    cfg.SelectedItemForegroundColor = ConsoleColor.Red;
                    cfg.Title = "Main Menu";
                });

        }

        private MenuOptionResult FinishTransaction()
        {
            //Return change 
           
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


            //log end of transaction (date time, GIVE CHANGE, initial balance, end balance)

            //Go back to main menu to start again 
            return MenuOptionResult.WaitThenCloseAfterSelection;

        }

        
        private MenuOptionResult SelectProduct(Product product)
        {
            //Display list of products 

            foreach (KeyValuePair<string, List<Product>> kvp in VendingMachine.vendingMachineInventory)
            {
                Console.WriteLine($"{kvp.Key}|{kvp.Value[0].ProductName}|{kvp.Value[0].Price}|{kvp.Value[0].Quantity}");
            }

            //Ask user for Slot Location
            Console.WriteLine("Please input the Slot Location of the item you would like to purchase: ");
            //Read slot location 
            string userInputKey = Console.ReadLine().ToUpper();

            //If not a usable slot location, return error, return to purchase menu
            if (!VendingMachine.vendingMachineInventory.ContainsKey(userInputKey))
            {
                Console.WriteLine("Invalid selection. Please re-enter key");
                return MenuOptionResult.WaitAfterMenuSelection;
            }

            //If product slot location is valid 
            else
            {
                //If product quantity == 0, inform customer, return to purchase menu
                if ((userInputKey == product.SlotLocation) && (product.Quantity == 0))
                {
                    Console.WriteLine("This product is sold out. Please select another item.");
                    return MenuOptionResult.WaitAfterMenuSelection;
                }
                //Else if product is available 
                else
                {
                    //Subtract 1 from quantity
                    product.Quantity--;

                    //Subtract price from current money 
                    CurrentMoneyProvided -= product.Price;

                    //Print item name, cost, money remaining, specialized message
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
                }

            }
            
            //Kick back out to purchase menu 
            return MenuOptionResult.DoNotWaitAfterMenuSelection;
        }

        
        private MenuOptionResult FeedMoney()
        {            
            
            Console.Write("Input Money ($1, 2, 5, 10 only) ");
            decimal inputAmount = decimal.Parse (Console.ReadLine());
            CurrentMoneyProvided += inputAmount;

            //log date time, feed money, initial balance, current balance

            return MenuOptionResult.DoNotWaitAfterMenuSelection;
                        
        }
    }
}
