using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Capstone.Classes
{
    public class FileLogger
    {
               
        //Create a file in the local folder to write result to 
        string filePath = @"..\..\..\..\Log.txt";

        public FileLogger()
        {
           
            
        }

        public void AuditLogEntry(string transactionType, decimal initialBalance, decimal finalBalance, Product product)
        {
            using (StreamWriter streamWriter = new StreamWriter(filePath, true))
            {
                if (transactionType == "feedMoney")
                {
                    streamWriter.WriteLine($"{DateTime.Now} FEED MONEY: {initialBalance} {finalBalance}");
                }
                else if (transactionType == "purchase")
                {
                    streamWriter.WriteLine($"{DateTime.Now} {product.ProductName} {product.SlotLocation} {initialBalance} {finalBalance}");
                }
                else
                {
                    streamWriter.WriteLine($"{DateTime.Now} GIVE CHANGE: {initialBalance} {finalBalance}");
                }
            }
        }
    }
}
