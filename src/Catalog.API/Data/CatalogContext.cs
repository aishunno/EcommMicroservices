using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data;

/// <summary>
/// CatalogContext class 
/// </summary>
public class CatalogContext : ICatalogContext
{
    /// <summary>
    /// Base constructor 
    /// </summary>
    /// <param name="configuration"></param>
    public CatalogContext(IConfiguration  configuration)
    {
        var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

        Products = database.GetCollection<Product>($"{nameof(Product)}s");
        CatalogContextSeed.SeedData(Products);
    }

    public IMongoCollection<Product> Products {  get; }
}
