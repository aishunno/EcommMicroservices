using Catalog.API.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Catalog.API.Data;

public class CatalogContextSeed
{
    /// <summary>
    /// Seeding data for proudct
    /// </summary>
    /// <param name="collection"></param>
    public static void SeedData(IMongoCollection<Product> collection)
    {
        var existProduct = collection.Find(x => true).Any();
        if (!existProduct)
        {
            collection.InsertMany(new Product[]
            {
                new() {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Name = "Product 1",
                    Description = "Description of Product 1",
                    Category = "Category 1",
                    Summary = "Summary of Product 1",
                    ImageFile = "image1.jpg",
                    Price = 10.99m
                },
                new() {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Name = "Product 2",
                    Description = "Description of Product 2",
                    Category = "Category 2",
                    Summary = "Summary of Product 2",
                    ImageFile = "image2.jpg",
                    Price = 20.99m
                },
                new() {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Name = "Product 3",
                    Description = "Description of Product 3",
                    Category = "Category 3",
                    Summary = "Summary of Product 3",
                    ImageFile = "image3.jpg",
                    Price = 30.99m
                },
                new() {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Name = "Product 4",
                    Description = "Description of Product 4",
                    Category = "Category 1",
                    Summary = "Summary of Product 4",
                    ImageFile = "image4.jpg",
                    Price = 40.99m
                },
                new() {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Name = "Product 5",
                    Description = "Description of Product 5",
                    Category = "Category 2",
                    Summary = "Summary of Product 5",
                    ImageFile = "image5.jpg",
                    Price = 50.99m
                }
                }
            );
        }
    }
}
