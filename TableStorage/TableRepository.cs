using Azure;
using Azure.Data.Tables;

namespace TableStorage
{
    public class TableRepository
    {
        private readonly TableClient _tableClient;

        public TableRepository(string tableName)
        {
            _tableClient = TableRepository.CreateTable(tableName);
        }

        public static TableClient CreateTable(string tableName)
        {
            var tableClient = new TableClient(DatabaseConnection<Program>.Get(), tableName);
            tableClient.CreateIfNotExists();
            return tableClient;
        }

        public bool DeleteTable()
        {
            _tableClient.Delete();
            return true;
        }

        public bool CreateTableEntity(TableEntity entity)
        {
            _tableClient.InsertEntity(entity);
            return true;
        }

        public bool DeleteTableEntity(string partitionKey, string rowKey)
        {
            _tableClient.DeleteEntity(partitionKey, rowKey);
            return true;
        }

        public Pageable<TableEntity> QueryTableEntity(string partitionKey)
        {
            Pageable<TableEntity> queryResultsFilter = _tableClient.Query<TableEntity>(filter: $"PartitionKey eq '{partitionKey}'");
            return queryResultsFilter;
        }
    }
}