using Azure.Data.Tables;
using TableStorage;
using Azure.Data.Tables.Models;
using Azure;

TableRepository tableRepository = new TableRepository();
string partitionKey = "huhaaaha";
string rowKey = "huhaaaha";

tableRepository.CreateTableEntity(partitionKey, rowKey, "Product", 10.00, 10);

Pageable<TableEntity> queryResultsFilter = tableRepository.QueryTableEntity(partitionKey);

foreach (TableEntity qEntity in queryResultsFilter)
{
    Console.WriteLine($"{qEntity.GetString("Product")}: {qEntity.GetDouble("Price")}");
}

tableRepository.DeleteTableEntity(partitionKey, rowKey);