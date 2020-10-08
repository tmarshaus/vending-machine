using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        //Set up a SortedDictionary to store inventory
        public SortedDictionary<string, List<Product>> vendingMachineInventory; 

        //Create a constructor for class 
        public VendingMachine(IEnumerable<Product> productList)
        {
            //Load the inventory Dictionary for lookup by SlotLocation - each Key will point to a product assigned to it 
            this.vendingMachineInventory = new SortedDictionary<string, List<Product>>();

            //Loop through the products 
            //foreach (Product product in vendingMachineInventory)
            //{
            //    if (!vendingMachineInventory.ContainsKey(product.SlotLocation))
            //    {
            //        //Add the KVP with SlotLocation as the Key and a new empty List<product> as the value
            //        vendingMachineInventory[product.SlotLocation] = new List<Product>();
            //    }

            //    vendingMachineInventory[product.SlotLocation].Add(product);

            //}

        }
    }
}
