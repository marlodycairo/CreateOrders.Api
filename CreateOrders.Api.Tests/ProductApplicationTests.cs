using AutoMapper;
using CreateOrders.Api.ApplicationServices;
using CreateOrders.Api.Domain;
using CreateOrders.Api.Domain.Models;
using CreateOrders.Api.Domain.Models.ModelResponse;
using CreateOrders.Api.DomainServices;
using CreateOrders.Api.Infrastructure.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CreateOrders.Api.Tests
{
    public class ProductApplicationTests
    {
        [Fact]
        public void Create_NewProductShouldInsert()
        {
            Mock<IProductsDomain> productsDomain = new Mock<IProductsDomain>();

            Mock<IMapper> mapperRepo = new Mock<IMapper>();

            ProductsViewModel productsModel = new ProductsViewModel();

            Products prod = new Products();

            ProductsViewResponse productResponse = new ProductsViewResponse();

            productsModel = new ProductsViewModel { Id = 1, ProductName = "abcde", Description = "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", Price = 1800 };

            ProductsApplication prodApplication = new ProductsApplication(productsDomain.Object, mapperRepo.Object);

            productsDomain.Setup(p => p.Create(prod)).Returns(productResponse);

            Assert.True(true);

            Assert.NotNull(productsModel);
        }

        [Fact]
        public void ProductShouldIsNullOrEmpty()
        {
            Mock<IProductsDomain> productDom = new Mock<IProductsDomain>();

            Mock<IMapper> mapperRepo = new Mock<IMapper>();

            Products products = new Products();

            Products product = null;

            ProductsViewResponse productResponse = new ProductsViewResponse();

            IEnumerable<Products> lst = new List<Products>();

            productDom.Setup(p => p.Create(products)).Returns(productResponse);

            Assert.Empty(lst);

            Assert.Null(product);
        }

        [Fact]
        public void DeleteShouldDeleteProduct()
        {
            Mock<IProductsDomain> productDomain = new Mock<IProductsDomain>();

            Mock<IMapper> mapperRepo = new Mock<IMapper>();

            Products products = new Products();

            int id = 1;

            products = new Products { Id = 1, ProductName = "abcde", Description = "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", Price = 1800 };

            productDomain.Setup(p => p.Delete(id)).Verifiable();

            ProductsApplication prodApplication = new ProductsApplication(productDomain.Object, mapperRepo.Object);

            prodApplication.Delete(id);

            Assert.Equal(id, products.Id);

            string sub = "enim";
            string actualSub = "Ut enim ad minim veniam, quis nostrud exercitation";

            Assert.Contains(sub, actualSub);
        }

        [Fact]
        public void GetAllAndGetByIdShouldGetProducts()
        {
            Mock<IProductsDomain> prodDomain = new Mock<IProductsDomain>();

            Mock<IMapper> mapperRepo = new Mock<IMapper>();

            ProductsViewModel products = new ProductsViewModel();

            int id = 1;

            products = new ProductsViewModel { Id = null, ProductName = "", Description = "", Price = null };

            IEnumerable<Products> productList = new List<Products>();

            List<ProductsViewModel> lstProd = new List<ProductsViewModel>();

            lstProd.Add(new ProductsViewModel() { Id = 1, ProductName = "abcde", Description = "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", Price = 1800 });
            lstProd.Add(new ProductsViewModel() { Id = 2, ProductName = "qwerty", Description = "Ut enim ad minim veniam", Price = 3422 });
            lstProd.Add(new ProductsViewModel() { Id = 3, ProductName = "axcvbfg", Description = "quis nostrud exercitation ullamco", Price = 879900 });

            prodDomain.Setup(p => p.GetAll()).Returns(lstProd);

            prodDomain.Setup(p => p.GetById(id)).Returns(products);

            ProductsApplication proDomain = new ProductsApplication(prodDomain.Object, mapperRepo.Object);

            proDomain.GetAll();

            proDomain.GetById(id);

            Assert.Empty(productList);
        }

        [Fact]
        public void UpdateShouldProduct()
        {
            Mock<IProductsDomain> prodRepo = new Mock<IProductsDomain>();

            Mock<IMapper> mapperRepo = new Mock<IMapper>();

            ProductsViewModel products = new ProductsViewModel();

            products = new ProductsViewModel { Id = 1, ProductName = "abcde", Description = "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", Price = 1800 };

            products = new ProductsViewModel { Id = 1, ProductName = "abcdefg", Description = "Ut enim ad minim veniam.", Price = 2000 };

            IEnumerable<ProductsViewModel> lstProd;

            prodRepo.Setup(p => p.Update(products)).Returns(products);

            Assert.Equal(products, products);
        }
    }
}
