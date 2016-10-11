using Moq;
using Newtonsoft.Json;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using CMDemo.API.Controllers;
using CMDemo.API.Models;
using Xunit;

namespace CMDemo.Tests
{
    public class ProductsControllerTests
    {
        private Mock<IProductRepository> repository;

        private ProductsController sut;

        private List<Product> products;

        public ProductsControllerTests()
        {
            // Prepare Test Data
            string json = @"[
                {'id':1,'sku':'170-10-8596','name':'Birch','price':960.3,'attribute':{'fantastic':{'value':true,'type':1,'name':'fantastic'},'rating':{'name':'rating','type':'2','value':2.7}}},
                {'id':2,'sku':'370-04-2494','name':'Cocoa butter, Phenylephrine HCl, Shark liver oil','price':983.7,'attribute':{'fantastic':{'value':true,'type':1,'name':'fantastic'},'rating':{'name':'rating','type':'2','value':2.0}}},
                {'id':3,'sku':'470-21-1561','name':'simvastatin','price':196.75,'attribute':{'fantastic':{'value':true,'type':1,'name':'fantastic'},'rating':{'name':'rating','type':'2','value':4.0}}}
            ]";

            products = JsonConvert.DeserializeObject<List<Product>>(json);

            // Prepare Mock
            repository = new Mock<IProductRepository>();
            sut = new ProductsController(repository.Object);
        }

        [Fact]
        public void GetAllProductsReturnsCorrectListFromRepository()
        {
            // Arrange
            repository.Setup(x => x.GetAll()).Returns(products);

            // Act
            var result = sut.Get("");

            // Assert
            result.ShouldBe(products);
        }

        [Fact]
        public void GetProductWithId_ShouldReturnsCorrectItem_FromRepository()
        {
            // Arrange
            List<Product> list = products.Where(x => x.Id == 1).ToList();
            string json = "query={id:1}";
            repository.Setup(x => x.Filter(json)).Returns(list);

            // Act
            var result = sut.Get(json);

            // Assert
            result.ShouldBe(list);
        }

        [Fact]
        public void GetProductWithIncorrectId_ShooldReturnNull()
        {
            // Arrange
            List<Product> list = new List<Product>();
            string json = "query={'id':-1}";
            repository.Setup(x => x.Filter(json)).Returns(list);

            // Act
            var result = sut.Get(json);

            // Assert
            //Should.Throw<Exception>(() => sut.Get(json));
            result.ShouldBe(list);
        }
    }
}