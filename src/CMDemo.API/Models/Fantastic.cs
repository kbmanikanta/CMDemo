using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CMDemo.API.Models
{
    public class Fantastic
    {
        [BsonElement("value")]
        public bool Value { get; set; }

        [BsonElement("type")]
        public int Type { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }
    }
}