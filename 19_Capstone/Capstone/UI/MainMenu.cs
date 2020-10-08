using Capstone.Classes;
using MenuFramework;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;


namespace Capstone.UI
{


    public class MainMenu : ConsoleMenu
    {
        public MainMenu()
        {
            //    //display when program runs

            //ConsoleMenu mainMenu = new ConsoleMenu();
            //    //(1) Vending Machine Items
            //    //present customer with a list of all items + quantity
            //    //stocked by input file at program startup
            //    //(2) Purchase
            //    //this leads to PurchaseMenu
            //    //(3) Exit

 
            AddOption("Vending Machine Items", DisplayVendingMachineItems);

  
            AddOption("Purchase Item", Purchase);
            AddOption("Exit", Exit);

            Configure(cfg =>
            {
                cfg.ItemForegroundColor = ConsoleColor.Yellow;
                cfg.SelectedItemForegroundColor = ConsoleColor.Red;
                cfg.Title = "Main Menu";
            });

            Show();

        }

        private MenuOptionResult Purchase()
        {
            PurchaseMenu purchaseMenu = new PurchaseMenu();
            purchaseMenu.Show();
            return MenuOptionResult.DoNotWaitAfterMenuSelection;

        }

        private MenuOptionResult DisplayVendingMachineItems()
        {

        }

        private static MenuOptionResult Exit()
        {
            return MenuOptionResult.CloseMenuAfterSelection;
        }

    }


    }
}
