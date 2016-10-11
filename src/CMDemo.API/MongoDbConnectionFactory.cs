using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CMDemo.API
{
    public class MongoDbConnectionFactory : IDbConnectionFactory
    {
        protected static IMongoClient client;

        protected static IMongoDatabase database;

        private MongoDbSettings settings { get; set; }

        public MongoDbConnectionFactory(IOptions<MongoDbSettings> settings)
        {
            this.settings = settings.Value;

            client = new MongoClient(this.settings.Connection);
            database = client.GetDatabase(this.settings.Database);
        }

        public IMongoDatabase OpenConnection()
        {
            return database;
        }
    }
}