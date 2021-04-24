using esourcing_project_net5.Products.entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace esourcing_project_net5.Products.Repositories.Interfaces {
    public interface IProductRepository {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(string id);
        Task<IEnumerable<Product>> GetProductByName(string name);
        Task<IEnumerable<Product>> GetProductByCategory(string categoryName);
        Task Create(Product product);
        Task<bool> Update(Product product);
        Task<bool> Delete(string id);
    }
}
