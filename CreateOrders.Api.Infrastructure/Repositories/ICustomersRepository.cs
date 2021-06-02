using CreateOrders.Api.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreateOrders.Api.Infrastructure.Repositories
{
    public interface ICustomersRepository
    {
        IEnumerable<Customers> GetAll();
        Customers GetById(int id);
        Customers Create(Customers customer);
        Customers Update(Customers customer);
        void Delete(int id);
    }
}
