using AutoMapper;
using CreateOrders.Api.Domain;
using CreateOrders.Api.Domain.Exceptions;
using CreateOrders.Api.Domain.Models;
using CreateOrders.Api.Domain.Models.ModelResponse;
using CreateOrders.Api.Infrastructure.Entities;
using CreateOrders.Api.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreateOrders.Api.DomainServices
{
    public class ProductsDomain : IProductsDomain
    {
        private readonly IProductsRepository productsRepository;
        private readonly IMapper mapper;

        public ProductsDomain(IProductsRepository productsRepository, IMapper mapper)
        {
            this.productsRepository = productsRepository;
            this.mapper = mapper;
        }

        public ProductsViewResponse Create(Products product)
        {
            Products products = null;

            if (products == null)
            {
                throw new ProductIsNullException();
            }

            productsRepository.Create(product);

            var result = mapper.Map<ProductsViewResponse>(product);

            return result;
        }

        public void Delete(int id)
        {
            productsRepository.Delete(id);
        }

        public IEnumerable<ProductsViewModel> GetAll()
        {
            var products = productsRepository.GetAll();

            var result = mapper.Map<IEnumerable<ProductsViewModel>>(products);

            return result;
        }

        public ProductsViewModel GetById(int id)
        {
            var product = productsRepository.GetById(id);
            var productModel = mapper.Map<ProductsViewModel>(product);

            return productModel;
        }

        public ProductsViewModel Update(ProductsViewModel productModel)
        {
            var products = mapper.Map<Products>(productModel);

            productsRepository.Update(products);

            return productModel;
        }
    }
}
