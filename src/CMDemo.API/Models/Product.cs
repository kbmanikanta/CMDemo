using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CMDemo.API.Models
{
    public class Product
    {
        [BsonId]
        public ObjectId _Id { get; set; }

        [BsonElement("id")]
        public int Id { get; set; }

        [BsonElement("sku")]
        public string SKU { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("price")]
        public double Price { get; set; }

        [BsonElement("attribute")]
        public Attribute Attribute { get; set; }
    }
}