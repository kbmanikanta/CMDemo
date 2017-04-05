using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace CMDemo.API.Models
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="CMDemo.API.Models.IProductRepository" />
    public class ProductRepository : IProductRepository
    {
        /// <summary>
        /// The factory
        /// </summary>
        private readonly IDbConnectionFactory factory;

        /// <summary>
        /// The collection
        /// </summary>
        protected IMongoCollection<Product> collection;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository"/> class.
        /// </summary>
        /// <param name="factory">The factory.</param>
        public ProductRepository(IDbConnectionFactory factory)
        {
            this.factory = factory;
            this.collection = factory.OpenConnection().GetCollection<Product>("Products");
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public IList<Product> GetAll()
        {
            var filter = Builders<Product>.Filter.Empty;
            var query = collection.Find(filter).ToListAsync();
            return query.Result;
        }

        /// <summary>
        /// Gets the total count.
        /// </summary>
        /// <returns></returns>
        public long GetTotalCount()
        {
            //var query = collection.Find(e => true).ToListAsync();
            //return query.Result.Count;
            var filter = Builders<Product>.Filter.Empty;
            var count = collection.Count(filter);
            return count;
        }

        /// <summary>
        /// Gets all for pagination.
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns></returns>
        public IList<Product> GetAllForPagination(int pageIndex, int pageSize)
        {
            var query = collection.Find(e => true).Skip((pageIndex - 1) * pageSize).Limit(pageSize).ToListAsync();
            return query.Result;
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Product Get(int id)
        {
            var filter = Builders<Product>.Filter.Eq(s => s.Id, id);
            var query = collection.Find(filter).FirstAsync();
            return query.Result;
        }

        /// <summary>
        /// Filters the specified json query.
        /// </summary>
        /// <param name="jsonQuery">The json query.</param>
        /// <returns></returns>
        public IList<Product> Filter(string jsonQuery)
        {
            var query = new QueryDocument(BsonSerializer.Deserialize<BsonDocument>(jsonQuery));
            return collection.Find<Product>(query).ToList();
        }

        /// <summary>
        /// Creates the specified product.
        /// </summary>
        /// <param name="product">The product.</param>
        public void Create(Product product)
        {
            collection.InsertOneAsync(product);
        }

        /// <summary>
        /// Removes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Remove(int id)
        {
            var filter = Builders<Product>.Filter.Eq(s => s.Id, id);
            var operation = collection.DeleteOneAsync(filter);
        }

        /// <summary>
        /// Updates the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="product">The product.</param>
        public void Update(int id, Product product)
        {
            var filter = Builders<Product>.Filter.Eq(s => s.Id, id);
            var operation = collection.ReplaceOneAsync(filter, product);
        }

        /// <summary>
        /// Gets the by price.
        /// </summary>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <returns></returns>
        public IList<Product> GetByPrice(decimal min, decimal max)
        {
            var jsonQuery = $"{{'price':{{$gte:{min},$lte:{max}}}}}";
            var query = new QueryDocument(BsonSerializer.Deserialize<BsonDocument>(jsonQuery));
            return collection.Find<Product>(query).ToList();
        }

        /// <summary>
        /// Gets the by fantastic.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public IList<Product> GetByFantastic(string value)
        {
            var jsonQuery = $"{{'attribute.fantastic.value':{{$eq:{value}}}}}";
            var query = new QueryDocument(BsonSerializer.Deserialize<BsonDocument>(jsonQuery));
            return collection.Find<Product>(query).ToList();
        }

        /// <summary>
        /// Gets the by rating.
        /// </summary>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <returns></returns>
        public IList<Product> GetByRating(decimal min, decimal max)
        {
            var jsonQuery = $"{{'attribute.rating.value':{{$gte:{min},$lte:{max}}}}}";
            var query = new QueryDocument(BsonSerializer.Deserialize<BsonDocument>(jsonQuery));
            return collection.Find<Product>(query).ToList();
        }
    }
}