using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Product
    {
        public string SlotLocation { get; private set; }
        public string ProductName { get; private set; }
        public decimal Price { get; private set; }
        public string Type { get; private set; }
        public int Quantity { get; set; } = 5;

        public Product (string slotLocation, string productName, decimal price, string type)
        {
            this.SlotLocation = slotLocation;
            this.ProductName = productName;
            this.Price = price;
            this.Type = type;
        }



    }
}
