using MenuFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.UI
{
    public class PurchaseMenu : ConsoleMenu
    {
        public PurchaseMenu()
        {
            AddOption("Feed Money", FeedMoney);


            AddOption("Select Product", SelectProduct);
            AddOption("Finish Transaction", FinishTransaction);

            Configure(cfg =>
                {
                    cfg.ItemForegroundColor = ConsoleColor.Yellow;
                    cfg.SelectedItemForegroundColor = ConsoleColor.Red;
                    cfg.Title = "Main Menu";
                });

        }

        private MenuOptionResult FinishTransaction()
        {
            throw new NotImplementedException();
        }

        private MenuOptionResult SelectProduct()
        {
            throw new NotImplementedException();
        }

        private MenuOptionResult FeedMoney()
        {
            decimal CurrentMoneyProvided = 0;
            
            Console.WriteLine("Input Money ($1, 2, 5, 10 only)");
            decimal inputAmount = decimal.Parse (Console.ReadLine());
            CurrentMoneyProvided += inputAmount;

            return MenuOptionResult.WaitThenCloseAfterSelection;
            //string v = CurrentMoneyProvided.ToString();
            
        }
    }
}
