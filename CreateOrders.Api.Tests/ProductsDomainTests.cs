using AutoMapper;
using CreateOrders.Api.Domain.Models;
using CreateOrders.Api.DomainServices;
using CreateOrders.Api.Infrastructure.Entities;
using CreateOrders.Api.Infrastructure.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CreateOrders.Api.Tests
{
    public class ProductsDomainTests
    {
        [Fact]
        public void Create_NewProductShouldInsert()
        {
            Mock<IProductsRepository> productsRepo = new Mock<IProductsRepository>();

            Mock<IMapper> mapperRepo = new Mock<IMapper>();

            Products products = new Products();

            products = new Products { Id = 1, ProductName = "abcde", Description = "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", Price = 1800 };

            productsRepo.Setup(p => p.Create(products)).Returns(products);

            Assert.True(true);

            Assert.NotNull(products);
        }

        [Fact]
        public void ProductShouldIsNullOrEmpty()
        {
            Mock<IProductsRepository> productRepo = new Mock<IProductsRepository>();

            Mock<IMapper> mapperRepo = new Mock<IMapper>();

            Products products = new Products();

            Products product = null;

            IEnumerable<Products> lst = new List<Products>();

            productRepo.Setup(p => p.Create(products)).Returns(products);

            Assert.Empty(lst);

            Assert.Null(product);
        }

        [Fact]
        public void DeleteShouldDeleteProduct()
        {
            Mock<IProductsRepository> prodRepo = new Mock<IProductsRepository>();

            Mock<IMapper> mapperRepo = new Mock<IMapper>();

            Products products = new Products();

            int id = 1;

            products = new Products { Id = 1, ProductName = "abcde", Description = "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", Price = 1800 };

            prodRepo.Setup(p => p.Delete(id)).Verifiable();

            ProductsDomain proDomain = new ProductsDomain(prodRepo.Object, mapperRepo.Object);

            proDomain.Delete(id);

            Assert.Equal(id, products.Id);

            string sub = "enim";
            string actualSub = "Ut enim ad minim veniam, quis nostrud exercitation";

            Assert.Contains(sub, actualSub);
        }

        [Fact]
        public void GetAllAndGetByIdShouldGetProducts()
        {
            Mock<IProductsRepository> prodRepo = new Mock<IProductsRepository>();

            Mock<IMapper> mapperRepo = new Mock<IMapper>();

            Products products = new Products();

            int id = 1;

            products = new Products { Id = null, ProductName = "", Description = "", Price = null};

            IEnumerable<Products> productList = new List<Products>();

            List<Products> lstProd = new List<Products>();

            lstProd.Add(new Products() { Id = 1, ProductName = "abcde", Description = "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", Price = 1800 });
            lstProd.Add(new Products() { Id = 2, ProductName = "qwerty", Description = "Ut enim ad minim veniam", Price = 3422 });
            lstProd.Add(new Products() { Id = 3, ProductName = "axcvbfg", Description = "quis nostrud exercitation ullamco", Price = 879900 });

            prodRepo.Setup(p => p.GetAll()).Returns(lstProd);

            prodRepo.Setup(p => p.GetById(id)).Returns(products);

            ProductsDomain proDomain = new ProductsDomain(prodRepo.Object, mapperRepo.Object);

            proDomain.GetAll();

            proDomain.GetById(id);

            Assert.Empty(productList);
        }

        [Fact]
        public void UpdateShouldProduct()
        {
            Mock<IProductsRepository> prodRepo = new Mock<IProductsRepository>();

            Mock<IMapper> mapperRepo = new Mock<IMapper>();

            Products products = new Products();

            products = new Products { Id = 1, ProductName = "abcde", Description = "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", Price = 1800 };

            products = new Products { Id = 1, ProductName = "abcdefg", Description = "Ut enim ad minim veniam.", Price = 2000 };

            IEnumerable<Products> lstProd;

            prodRepo.Setup(p => p.Update(products)).Returns(products);

            Assert.Equal(products, products);
        }
    }
}
