using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class PurchaseProductQuantityTest
    {
        
        [DataTestMethod]
        [DataRow(4)]
        public void BuyProduct(int expectedQuantity)
        {
            //Arrange
            VMInventoryLoader vMInventoryLoader = new VMInventoryLoader();
            vMInventoryLoader.StockProducts();

            IEnumerable<Product> products = vMInventoryLoader.StockProducts();

            VendingMachine vendingMachine = new VendingMachine(products);

            string userInputKey = "A1";
            Product product = vendingMachine.vendingMachineInventory[userInputKey];

            //Act
            vendingMachine.PurchaseProduct(product);

            //Assert 
            Assert.AreEqual(product.Quantity, expectedQuantity);
        }
    }
}
