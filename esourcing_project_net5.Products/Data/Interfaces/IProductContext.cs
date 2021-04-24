using esourcing_project_net5.Products.entities;
using MongoDB.Driver;

namespace esourcing_project_net5.Products.Data.Interfaces {
    public interface IProductContext {
        IMongoCollection<Product> Products { get; set; }
    }
}
