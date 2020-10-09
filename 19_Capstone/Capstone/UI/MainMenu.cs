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

        private VendingMachine VendingMachine;
        private Product Product;

        public MainMenu(VendingMachine vendingMachine)
        {
            VendingMachine = vendingMachine;
            
            

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
        private MenuOptionResult DisplayVendingMachineItems()
        {
            //Print a list of SlotLocation, ProductName, Price, Quantity

            foreach (KeyValuePair<string, List<Product>> kvp in VendingMachine.vendingMachineInventory)
            {
                Console.WriteLine($"{kvp.Key}|{kvp.Value[0].ProductName}|{kvp.Value[0].Price}|{kvp.Value[0].Quantity}");
            }

            Console.WriteLine("Press Enter to return to Main Menu");
            
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult Purchase()
        {
            PurchaseMenu purchaseMenu = new PurchaseMenu(VendingMachine, Product);
            purchaseMenu.Show();
            return MenuOptionResult.DoNotWaitAfterMenuSelection;

        }
        
        private static MenuOptionResult Exit()
        {
            return MenuOptionResult.CloseMenuAfterSelection;
        }

    }


    
}
