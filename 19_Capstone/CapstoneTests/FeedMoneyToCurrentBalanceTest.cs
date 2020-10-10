using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class FeedMoneyToCurrentBalanceTest
    {
        [DataTestMethod]
        [DataRow(2, 2)]
        [DataRow(5, 5)]
        [DataRow(10, 10)]
        [DataRow(1, 1)]

        public void MoneyIncrementerTest(int moneyInput, int expectedValue)
        {
            //Arrange
            VMInventoryLoader vMInventoryLoader = new VMInventoryLoader();
            vMInventoryLoader.StockProducts();

            IEnumerable<Product> products = vMInventoryLoader.StockProducts();

            VendingMachine vendingMachine = new VendingMachine(products);

            decimal decMoneyInput = (decimal)(moneyInput);

            decimal decExpectedValue = (decimal)(expectedValue);

            //Act
            vendingMachine.FeedMoneyToCurrentBalance(decMoneyInput);

            //Assert
            Assert.AreEqual(vendingMachine.CurrentMoneyProvided, decExpectedValue);
        }

    }
}
