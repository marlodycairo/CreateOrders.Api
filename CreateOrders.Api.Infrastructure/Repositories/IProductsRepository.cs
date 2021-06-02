using CreateOrders.Api.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreateOrders.Api.Infrastructure.Repositories
{
    public interface IProductsRepository
    {
        IEnumerable<Products> GetAll();
        Products GetById(int id);
        Products Create(Products product);
        Products Update(Products product);
        void Delete(int id);
    }
}
