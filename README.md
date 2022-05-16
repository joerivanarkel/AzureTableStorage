[← Return to AZ-204](README.md)<br>

[![.NET](https://github.com/joerivanarkel/AzureTableStorage/actions/workflows/dotnet.yml/badge.svg)](https://github.com/joerivanarkel/AzureTableStorage/actions/workflows/dotnet.yml)
## Azure Table Storage
In this example I am Creating, Querying and Deleting Tables and TableEntities in Azure Table Storage. I have used dotnet secrets to set up a secret connectionstring, in ``DatabaseConnection.cs`` it is converted from secret to string. I am using the Azure.Data.Tables NuGet package.

### Setting up Table Storage
Here we create a ``tableclient``, with that we can Create, Query and Delete TableEntities. We initialize the TableClient first and secondly ensures that it exists.
```csharp
var tableClient = new TableClient(DatabaseConnection<Program>.Get(), tableName);
tableClient.CreateIfNotExists();
return tableClient;
```

### Deleting a Table
Individual tables can be deleted from the ``tableclient``.
```csharp
_tableClient.Delete();
```

### Creating a Table Entity
In the underlying example I create a new TableEntity. When calling this method you have to specify the ``partitionKey`` and ``rowKey``. In the parameter we can specify the columns with this entity.
```csharp
var entity = new TableEntity(partitionKey, rowKey)
{
  { "Product", Product },
  { "Price", Price },
  { "Quantity", Quantity }
};
_tableClient.AddEntity(entity);
```

## Quering a Table Entity
Here I query a Pageable of TableEntity. I have also filtered out the result not matching the specified ``partitionKey``.
```csharp
Pageable<TableEntity> queryResultsFilter = _tableClient.Query<TableEntity>(filter: $"PartitionKey eq '{partitionKey}'");
```

## Deleting a Table Entity
To delete a Table Entity, I use the ``DeleteEntity()`` method. To delete the right entity, you'll have to specify the ``partitionKey`` and ``rowKey``
```csharp
_tableClient.DeleteEntity(partitionKey, rowKey);
```
