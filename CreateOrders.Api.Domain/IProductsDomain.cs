using CreateOrders.Api.Domain.Models;
using CreateOrders.Api.Domain.Models.ModelResponse;
using CreateOrders.Api.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreateOrders.Api.Domain
{
    public interface IProductsDomain
    {
        IEnumerable<ProductsViewModel> GetAll();
        ProductsViewModel GetById(int id);
        ProductsViewResponse Create(Products product);
        ProductsViewModel Update(ProductsViewModel product);
        void Delete(int id);
    }
}
