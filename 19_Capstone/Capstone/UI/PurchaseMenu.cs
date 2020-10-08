using Capstone.Classes;
using MenuFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.UI
{
    public class PurchaseMenu : ConsoleMenu
    {
        public decimal CurrentMoneyProvided { get; set; } = 0;

        public PurchaseMenu()
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

        private MenuOptionResult SelectProduct()
        {
            //Display list of products 

            //Ask user for Slot Location
            Console.WriteLine("Please input the Slot Location of the item you would like to purchase: ");
            //Read slot location 
            Console.ReadLine();

            //If not a usable slot location, return error, return to purchase menu
 

            //If product slot location is valid 

                //If product is sold out, inform customer, return to purchase menu
                
                //Else if product is available 
                   
                    //Print item name, cost, money remaining, specialized message
            
                    //Subtract 1 from quantity
                    // key[quantity] --;

                    //Subtract price from current money 
                    //CurrentMoneyProvided -= Product Price

                    //log date time, purchase, initial balance, current balance

                   

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
