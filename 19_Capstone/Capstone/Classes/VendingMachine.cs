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

    }
}
