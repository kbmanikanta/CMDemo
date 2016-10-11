using System.Collections.Generic;

namespace CMDemo.API.Models
{
    public interface IProductRepository
    {
        IList<Product> GetAll();

        Product Get(int id);

        IList<Product> Filter(string jsonQuery);

        void Create(Product product);

        void Update(int id, Product product);

        void Remove(int id);

        IList<Product> GetByPrice(decimal min, decimal max);

        IList<Product> GetByFantastic(string value);

        IList<Product> GetByRating(decimal min, decimal max);
    }
}