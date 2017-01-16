using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CMDemo.API.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CMDemo.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private IProductRepository repository;

        public ProductsController(IProductRepository repository)
        {
            this.repository = repository;
        }

        // GET: api/products
        [HttpGet]
        public IList<Product> Get(string query = "")
        {
            if (string.IsNullOrEmpty(query))
            {
                return repository.GetAll();
            }

            return repository.Filter(query);
        }

        // GET: api/products/1/10
        [HttpGet("{pageIndex:int}/{pageSize:int}")]
        public ActionResult GetAllForPagination(int pageIndex, int pageSize)
        {
            var products = repository.GetAllForPagination(pageIndex, pageSize);
            var count = repository.GetTotalCount();
            return Json(new { data = products, page = pageIndex, total = count });
        }

        // POST api/products
        [HttpPost]
        public void Post([FromBody] Product p)
        {
            repository.Create(p);
        }

        // GET api/products/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return repository.Get(id);
        }

        // PUT api/products/5
        [HttpPut("{id}")]
        public void Put(int id, Product p)
        {
            repository.Update(id, p);
        }

        // DELETE api/products/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repository.Remove(id);
        }

        [HttpGet]
        [Route("[action]")]
        public IList<Product> GetByPrice(decimal min = 0, decimal max = 0)
        {
            return repository.GetByPrice(min, max);
        }

        [HttpGet]
        [Route("[action]")]
        public IList<Product> GetByFantastic(string value = "")
        {
            return repository.GetByFantastic(value);
        }

        [HttpGet]
        [Route("[action]")]
        public IList<Product> GetByRating(decimal min = 0, decimal max = 0)
        {
            return repository.GetByRating(min, max);
        }
    }
}
