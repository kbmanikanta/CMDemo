using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace CMDemo.API.Models
{
    public class ProductRepository : IProductRepository
    {
        private IDbConnectionFactory factory;

        protected IMongoCollection<Product> collection;

        public ProductRepository(IDbConnectionFactory factory)
        {
            this.factory = factory;
            this.collection = factory.OpenConnection().GetCollection<Product>("Products");
        }

        public IList<Product> GetAll()
        {
            var filter = Builders<Product>.Filter.Empty;
            var query = collection.Find(filter).ToListAsync();
            return query.Result;
        }

        public Product Get(int id)
        {
            var filter = Builders<Product>.Filter.Eq(s => s.Id, id);
            var query = collection.Find(filter).FirstAsync();
            return query.Result;
        }

        public IList<Product> Filter(string jsonQuery)
        {
            var query = new QueryDocument(BsonSerializer.Deserialize<BsonDocument>(jsonQuery));
            return collection.Find<Product>(query).ToList();
        }

        public void Create(Product product)
        {
            collection.InsertOneAsync(product);
        }

        public void Remove(int id)
        {
            var filter = Builders<Product>.Filter.Eq(s => s.Id, id);
            var operation = collection.DeleteOneAsync(filter);
        }

        public void Update(int id, Product product)
        {
            var filter = Builders<Product>.Filter.Eq(s => s.Id, id);
            var operation = collection.ReplaceOneAsync(filter, product);
        }

        public IList<Product> GetByPrice(decimal min, decimal max)
        {
            var jsonQuery = string.Format("{{'price':{{$gte:{0},$lte:{1}}}}}", min, max);

            var query = new QueryDocument(BsonSerializer.Deserialize<BsonDocument>(jsonQuery));
            return collection.Find<Product>(query).ToList();
        }

        public IList<Product> GetByFantastic(decimal min, decimal max)
        {
            var jsonQuery = string.Format("{{'attribute.fantastic.value':{{$gte:{0},$lte:{1}}}}}", min, max);

            var query = new QueryDocument(BsonSerializer.Deserialize<BsonDocument>(jsonQuery));
            return collection.Find<Product>(query).ToList();
        }

        public IList<Product> GetByRating(decimal min, decimal max)
        {
            var jsonQuery = string.Format("{{'attribute.rating.value':{{$gte:{0},$lte:{1}}}}}", min, max);

            var query = new QueryDocument(BsonSerializer.Deserialize<BsonDocument>(jsonQuery));
            return collection.Find<Product>(query).ToList();
        }
    }
}