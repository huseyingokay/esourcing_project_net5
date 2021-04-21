using esourcing_project_net5.Products.entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace esourcing_project_net5.Products.Data.Interfaces {
    public interface IProductContext {
        IMongoCollection<Product> Products { get; set; }
    }
}
