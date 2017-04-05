using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CMDemo.API
{
    /// <summary>
    /// MongoDb Connection Factory
    /// </summary>
    /// <seealso cref="CMDemo.API.IDbConnectionFactory" />
    public class MongoDbConnectionFactory : IDbConnectionFactory
    {
        /// <summary>
        /// The client
        /// </summary>
        protected static IMongoClient client;

        /// <summary>
        /// The database
        /// </summary>
        protected static IMongoDatabase database;

        /// <summary>
        /// Gets or sets the settings.
        /// </summary>
        /// <value>
        /// The settings.
        /// </value>
        private MongoDbSettings settings { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MongoDbConnectionFactory"/> class.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public MongoDbConnectionFactory(IOptions<MongoDbSettings> settings)
        {
            this.settings = settings.Value;

            client = new MongoClient(this.settings.Connection);
            database = client.GetDatabase(this.settings.Database);
        }

        /// <summary>
        /// Opens the connection.
        /// </summary>
        /// <returns></returns>
        public IMongoDatabase OpenConnection()
        {
            return database;
        }
    }
}