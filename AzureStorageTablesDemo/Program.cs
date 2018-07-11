using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace AzureStorageTablesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            CloudStorageAccount storedAccount = CloudStorageAccount.Parse
                                                (CloudConfigurationManager.GetSetting("StorageConnectionString"));
            CloudTableClient tableClient = storedAccount.CreateCloudTableClient();
            CloudTable table = tableClient.GetTableReference("customers");
            table.CreateIfNotExists();
            Console.WriteLine("Table customers is ready!");

            //Insert 
            CustomerEntity customer1 = new CustomerEntity("AP", "A01");
            customer1.LastName = "Mark";
            customer1.FirstName = "wines";
            customer1.Email = "markl@gmail.com";
            customer1.PhoneNumber = "9100945142";


            TableOperation insertOperation =  TableOperation.Insert(customer1);
            table.Execute(insertOperation);
            Console.WriteLine("Row Added!");

        }

        public class CustomerEntity:TableEntity
        {
            public CustomerEntity(string state,string customerId)
            {
                this.PartitionKey = state;
                this.RowKey = customerId;
            }
            public CustomerEntity()
            {

            }

            public string LastName { get; set; }
            public string FirstName { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
        }
    }
}
