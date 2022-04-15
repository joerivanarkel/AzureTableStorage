using Azure.Data.Tables;
using TableStorage;
using Azure.Data.Tables.Models;
using Azure;

string tableName = "mytable";
TableRepository tableRepository = new TableRepository(tableName);

string partitionKey = "parKey";
string rowKey = "rowKey";

var entity = new TableEntity(partitionKey, rowKey)
{
    ["Name"] = "John Doe",
    ["Age"] = "42",
    ["Address"] = "123 Main St"
};
tableRepository.CreateTableEntity(entity);

Pageable<TableEntity> queryResultsFilter = tableRepository.QueryTableEntity(partitionKey);
foreach (TableEntity qEntity in queryResultsFilter)
{
    Console.WriteLine($"{qEntity.GetString("Product")}: {qEntity.GetDouble("Price")}");
}

tableRepository.DeleteTableEntity(partitionKey, rowKey);