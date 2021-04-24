namespace esourcing_project_net5.Products.Settings {
    public class ProductDatabaseSettings : IProductDatabaseSettings {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CollectionName { get; set; }
    }
}
