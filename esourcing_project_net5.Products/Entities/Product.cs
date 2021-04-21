using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace esourcing_project_net5.Products.entities {
    public class Product {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]  //it provides a unique value for id and increases for each product
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }
        public string Category { get; set; }
        public string Summary { get; set; }
        public string ImageFile { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
