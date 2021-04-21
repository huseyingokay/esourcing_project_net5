using esourcing_project_net5.Products.Data.Interfaces;
using esourcing_project_net5.Products.entities;
using esourcing_project_net5.Products.Settings;
using MongoDB.Driver;

namespace esourcing_project_net5.Products.Data {
    public class ProductContext : IProductContext {

        public ProductContext(IProductDatabaseSettings settings) {
            var client = new MongoClient(settings.ConnectionStrings);
            var database = client.GetDatabase(settings.DatabaseName);

            Products = database.GetCollection<Product>(settings.CollectionName);
            ProductContextSeed.SeedData(Products);
        }
        public IMongoCollection<Product> Products { get; set; }
    }
}
