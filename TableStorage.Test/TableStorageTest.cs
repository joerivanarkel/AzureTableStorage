using Xunit;
using TableStorage;
using Azure;
using Azure.Data.Tables;

namespace TableStorage.Test;

public class TableStorageTest
{
    [Fact]
    public void ShouldCreateTableEntity()
    {
        // Arrange
        TableRepository tableRepository = new TableRepository();
        string partitionKey = "huhaaaha";
        string rowKey = "huhaaaha";

        // Act
        var result = tableRepository.CreateTableEntity(partitionKey, rowKey, "Product", 10.00, 10);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void ShouldDeleteTableEntity()
    {
        // Arrange
        TableRepository tableRepository = new TableRepository();
        string partitionKey = "huhaaaha";
        string rowKey = "huhaaaha";

        // Act
        var result = tableRepository.DeleteTableEntity(partitionKey, rowKey);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void ShouldQueryTableEntity()
    {
        // Arrange
        TableRepository tableRepository = new TableRepository();
        string partitionKey = "huhaaaha";

        // Act
        Pageable<TableEntity> queryResultsFilter = tableRepository.QueryTableEntity(partitionKey);

        // Assert
        Assert.NotNull(queryResultsFilter);
    }

    [Fact]
    public void ShouldDeleteTable()
    {
        // Arrange
        TableRepository tableRepository = new TableRepository();

        // Act
        var result = tableRepository.DeleteTable();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void ShouldCreateTable()
    {
        // Arrange
        TableRepository tableRepository = new TableRepository();
        string tableName = "huhaaaha";

        // Act
        var result = TableRepository.CreateTable(tableName);

        // Assert
        Assert.NotNull(result);
    }
}
