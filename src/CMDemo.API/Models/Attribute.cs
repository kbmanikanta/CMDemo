using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CMDemo.API.Models
{
    public class Attribute
    {
        [BsonElement("fantastic")]
        public Fantastic Fantastic { get; set; }

        [BsonElement("rating")]
        public Rating Rating { get; set; }
    }
}