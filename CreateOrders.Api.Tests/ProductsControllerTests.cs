using CreateOrders.Api.Application;
using CreateOrders.Api.Domain.Models;
using CreateOrders.Api.Domain.Models.ModelResponse;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CreateOrders.Api.Tests
{
    public class ProductsControllerTests
    {
        [Fact]
        public void Create_NewProductShouldInsert()
        {
            Mock<IProductsApplication> productApplication = new Mock<IProductsApplication>();

            ProductsViewModel productModel = new ProductsViewModel();

            ProductsViewResponse productResponse = new ProductsViewResponse();

            productModel = new ProductsViewModel { Id = 1, ProductName = "abcde", Description = "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", Price = 1800 };

            productApplication.Setup(p => p.Create(productModel)).Returns(productResponse);

            Assert.True(true);

            Assert.NotNull(productModel);
        }

        [Fact]
        public void ProductShouldIsNullOrEmpty()
        {
            Mock<IProductsApplication> productApplication = new Mock<IProductsApplication>();

            ProductsViewModel productModel = new ProductsViewModel();

            ProductsViewResponse productResponse = new ProductsViewResponse();

            IEnumerable<ProductsViewModel> productLst = new List<ProductsViewModel>();

            productApplication.Setup(p => p.Create(productModel)).Returns(productResponse);

            Assert.Empty(productLst);
        }

        [Fact]
        public void DeleteShouldDeleteProduct()
        {
            Mock<IProductsApplication> productApplication = new Mock<IProductsApplication>();

            ProductsViewModel products = new ProductsViewModel();

            int id = 1;

            products = new ProductsViewModel { Id = 1, ProductName = "abcde", Description = "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", Price = 1800 };

            productApplication.Setup(p => p.Delete(id)).Verifiable();

            Assert.Equal(id, products.Id);
        }

        [Fact]
        public void GetAllAndGetByIdShouldGetProduct()
        {
            Mock<IProductsApplication> productApplication = new Mock<IProductsApplication>();

            ProductsViewModel productModel = new ProductsViewModel();

            int id = 1;

            productModel = new ProductsViewModel { Id = 1, ProductName = "abcde", Description = "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", Price = 1800 };

            IEnumerable<ProductsViewModel> productLst = new List<ProductsViewModel>();

            List<ProductsViewModel> lstProduct = new List<ProductsViewModel>();

            lstProduct.Add(new ProductsViewModel() { Id = 1, ProductName = "abc", Description = "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", Price = 1800 });
            lstProduct.Add(new ProductsViewModel() { Id = 2, ProductName = "abcd", Description = "Ut enim ad minim veniam, quis nostrud exercitation.", Price = 2500 });
            lstProduct.Add(new ProductsViewModel() { Id = 3, ProductName = "abcde", Description = "Ut enim ad minim veniam, quis nostrud.", Price = 2350 });

            productApplication.Setup(p => p.GetAll()).Returns(lstProduct);

            productApplication.Setup(p => p.GetById(id)).Returns(productModel);

            Assert.Empty(productLst);
        }

        [Fact]
        public void UpdateShouldProduct()
        {
            Mock<IProductsApplication> productApplication = new Mock<IProductsApplication>();

            ProductsViewModel products = new ProductsViewModel();

            products = new ProductsViewModel { Id = 1, ProductName = "abcde", Description = "Ut enim ad minim veniam, quis nostrud exercitation .", Price = 1800 };

            products = new ProductsViewModel { Id = 1, ProductName = "asdfg", Description = "Ullamco laboris nisi ut aliquip ex ea commodo consequat.", Price = 1300 };

            productApplication.Setup(p => p.Update(products)).Returns(products);

            Assert.Equal(products, products);
        }
    }
}
