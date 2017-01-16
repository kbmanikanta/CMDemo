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

        public long GetTotalCount()
        {
            //var query = collection.Find(e => true).ToListAsync();
            //return query.Result.Count;
            var filter = Builders<Product>.Filter.Empty;
            long count = collection.Count(filter);
            return count;
        }

        public IList<Product> GetAllForPagination(int pageIndex, int pageSize)
        {
            var query = collection.Find(e => true).Skip((pageIndex - 1) * pageSize).Limit(pageSize).ToListAsync();
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
            var jsonQuery = $"{{'price':{{$gte:{min},$lte:{max}}}}}";
            var query = new QueryDocument(BsonSerializer.Deserialize<BsonDocument>(jsonQuery));
            return collection.Find<Product>(query).ToList();
        }

        public IList<Product> GetByFantastic(string value)
        {
            var jsonQuery = $"{{'attribute.fantastic.value':{{$eq:{value}}}}}";
            var query = new QueryDocument(BsonSerializer.Deserialize<BsonDocument>(jsonQuery));
            return collection.Find<Product>(query).ToList();
        }

        public IList<Product> GetByRating(decimal min, decimal max)
        {
            var jsonQuery = $"{{'attribute.rating.value':{{$gte:{min},$lte:{max}}}}}";
            var query = new QueryDocument(BsonSerializer.Deserialize<BsonDocument>(jsonQuery));
            return collection.Find<Product>(query).ToList();
        }
    }
}
