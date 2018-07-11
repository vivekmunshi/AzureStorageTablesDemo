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

        }
    }
}
