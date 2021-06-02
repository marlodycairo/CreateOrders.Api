using AutoMapper;
using CreateOrders.Api.Application;
using CreateOrders.Api.Domain;
using CreateOrders.Api.Domain.Exceptions;
using CreateOrders.Api.Domain.Models;
using CreateOrders.Api.Domain.Models.ModelResponse;
using CreateOrders.Api.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreateOrders.Api.ApplicationServices
{
    public class ProductsApplication : IProductsApplication
    {
        private readonly IProductsDomain productsDomain;
        private readonly IMapper mapper;

        public ProductsApplication(IProductsDomain productsDomain, IMapper mapper)
        {
            this.productsDomain = productsDomain;
            this.mapper = mapper;
        }

        public ProductsViewResponse Create(ProductsViewModel product)
        {
            productsDomain.GetById(product.Id);

            if (ProductExists(product.Id))
            {
                throw new ProductExistsException();
            }

            var result = mapper.Map<Products>(product);
            var products = productsDomain.Create(result);

            return products;
        }

        public void Delete(int id)
        {
            productsDomain.Delete(id);
        }

        public IEnumerable<ProductsViewModel> GetAll()
        {
            return productsDomain.GetAll();
        }

        public ProductsViewModel GetById(int id)
        {
            return productsDomain.GetById(id);
        }

        public ProductsViewModel Update(ProductsViewModel product)
        {
            return productsDomain.Update(product);
        }

        private bool ProductExists(int id)
        {
            return productsDomain.GetAll().Any(p => p.Id == id);
        }
    }
}
