using CreateOrders.Api.Domain.Models;
using CreateOrders.Api.Domain.Models.ModelResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreateOrders.Api.Application
{
    public interface IProductsApplication
    {
        IEnumerable<ProductsViewModel> GetAll();
        ProductsViewModel GetById(int id);
        ProductsViewResponse Create(ProductsViewModel product);
        ProductsViewModel Update(ProductsViewModel product);
        void Delete(int id);
    }
}
