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
        //private Product Product;

        public PurchaseMenu(VendingMachine vendingMachine)
        {
            VendingMachine = vendingMachine;
            

            AddOption("Feed Money", FeedMoney); //TODO: Need to add Log ability
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

        private MenuOptionResult FeedMoney() //Need to Log 
        {
            //int amount = GetInteger("Input Money ($1, $2, $5, $10 only)", null, [1, 2, 5, 10]);

            Console.Write("Input Money ($1, $2, $5, $10 only) ");
            string userInput = Console.ReadLine().Trim();
            if (userInput == "1" || userInput == "2" || userInput == "5" || userInput == "10")
            {
                decimal inputAmount = decimal.Parse(userInput);
                VendingMachine.FeedMoneyToCurrentBalance(inputAmount);
                return MenuOptionResult.DoNotWaitAfterMenuSelection; 
            }
            else
            {
                Console.WriteLine("Dollar amount entered was not valid. Please press Enter to continue.");
                return MenuOptionResult.WaitAfterMenuSelection;
            }

        }
        
        private MenuOptionResult SelectProduct()
        {
            //Display list of products 
            foreach (KeyValuePair<string, Product> kvp in VendingMachine.vendingMachineInventory)
            {
                Console.WriteLine($"{kvp.Key}|{kvp.Value.ProductName}|{kvp.Value.Price:c}|{kvp.Value.Quantity}");
            }

            //Ask user for Slot Location
            Console.Write("Please input the Slot Location of the item you would like to purchase: ");

            //Read slot location 
            string userInputKey = Console.ReadLine().ToUpper();

            //If not a usable slot location, return error, return to purchase menu
            if (!VendingMachine.vendingMachineInventory.ContainsKey(userInputKey))
            {
                Console.WriteLine("Invalid selection. Please re-enter key");
                return MenuOptionResult.WaitAfterMenuSelection;
            }

            //product will hold user request
            Product product = VendingMachine.vendingMachineInventory[userInputKey];

            //Else if product quantity == 0, inform customer, return to purchase menu
            if (product.Quantity == 0)
            {
                Console.WriteLine("This product is sold out. Please select another item.");
                return MenuOptionResult.WaitAfterMenuSelection;
            }
            
            //Else call method
            else
            {
                VendingMachine.PurchaseProduct(product);
            }

            //Kick back out to purchase menu 
            return MenuOptionResult.WaitAfterMenuSelection;
        }
        private MenuOptionResult FinishTransaction()
        {
            VendingMachine.ReturnChange();

            //log end of transaction (date time, GIVE CHANGE, initial balance, end balance)

            //Go back to main menu to start again 
            return MenuOptionResult.WaitThenCloseAfterSelection;

        }

        protected override void OnBeforeShow()
        {
            Console.WriteLine($"Current Money Provided: {VendingMachine.CurrentMoneyProvided:c}"); 
        }

    }
}
