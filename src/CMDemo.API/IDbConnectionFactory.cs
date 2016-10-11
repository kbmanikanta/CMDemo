using MongoDB.Driver;

namespace CMDemo.API
{
    public interface IDbConnectionFactory
    {
        IMongoDatabase OpenConnection();
    }
}