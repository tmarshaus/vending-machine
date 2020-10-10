using Capstone.Classes;
using Capstone.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{

    [TestClass]
    public class VMInventoryLoaderTest
    {
        //private VendingMachine VendingMachine;

        [DataTestMethod]
        [DataRow(@"..\..\..\..\vendingmachine.csv")]
        
        public void FileLoaderTest(string filePath)
        {
            //Arrange
            VMInventoryLoader vMInventoryLoader = new VMInventoryLoader();

            //Act
            List<Product> actual = vMInventoryLoader.StockProducts();

            //Assess
            CollectionAssert.AllItemsAreNotNull(actual);
            
        }
    }
}
