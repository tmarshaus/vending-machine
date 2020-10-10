using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class ReturnChangeTest
    {
        [DataTestMethod]
        [DataRow(7, 0)]
        [DataRow(8, 0)]
        [DataRow(3, 0)]
        [DataRow(11, 0)]

        public void BalanceToZero(int initialBalance, int expectedBalance)
        {
            //Arrange 
            VMInventoryLoader vMInventoryLoader = new VMInventoryLoader();
            vMInventoryLoader.StockProducts();

            IEnumerable<Product> products = vMInventoryLoader.StockProducts();

            VendingMachine vendingMachine = new VendingMachine(products);

            decimal decInitialBalance = (decimal)(initialBalance);
            decimal decExpectedBalance = (decimal)(expectedBalance);

            //Act
            vendingMachine.CurrentMoneyProvided += decInitialBalance;
            vendingMachine.ReturnChange();

            //Assert 

            Assert.AreEqual(vendingMachine.CurrentMoneyProvided, decExpectedBalance);

        }
    }
}
