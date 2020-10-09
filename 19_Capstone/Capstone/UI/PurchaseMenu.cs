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
        private Product Product;
        

        public PurchaseMenu(VendingMachine vendingMachine, Product product)
        {
            VendingMachine = vendingMachine;
            Product = product;

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

            Console.Write("Input Money ($1, $2, $5, $10 only) ");
            decimal inputAmount = decimal.Parse(Console.ReadLine());
            if (inputAmount != 1 || inputAmount != 2 || inputAmount != 5 || inputAmount != 10)
            {
                Console.WriteLine("Dollar amount entered was not valid. Please press Enter to continue.");
                return MenuOptionResult.WaitAfterMenuSelection;
            }
            else
            {
                VendingMachine.FeedMoneyToCurrentBalance(inputAmount);

                //log date time, feed money, initial balance, current balance

                return MenuOptionResult.DoNotWaitAfterMenuSelection;
            }

        }
        
        private MenuOptionResult SelectProduct()
        {
            //Display list of products 
            foreach (KeyValuePair<string, List<Product>> kvp in VendingMachine.vendingMachineInventory)
            {
                Console.WriteLine($"{kvp.Key}|{kvp.Value[0].ProductName}|{kvp.Value[0].Price}|{kvp.Value[0].Quantity}");
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

            //Else if product quantity == 0, inform customer, return to purchase menu
            //if ((userInputKey = Product.SlotLocation) && (Product.Quantity == 0))    
            else if (VendingMachine.vendingMachineInventory.ContainsKey(userInputKey) && (Product.Quantity == 0))
            {
                Console.WriteLine("This product is sold out. Please select another item.");
                return MenuOptionResult.WaitAfterMenuSelection;
            }
            //Else call method 
            //else
            //{
            //    VendingMachine.PurchaseProduct();
            //}


            //Kick back out to purchase menu 
            return MenuOptionResult.DoNotWaitAfterMenuSelection;
        }
        private MenuOptionResult FinishTransaction()
        {
            VendingMachine.ReturnChange();

            //log end of transaction (date time, GIVE CHANGE, initial balance, end balance)

            //Go back to main menu to start again 
            return MenuOptionResult.WaitThenCloseAfterSelection;

        }



    }
}
