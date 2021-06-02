using CreateOrders.Api.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreateOrders.Api.Infrastructure.Repositories
{
    public interface IOrdersRepository
    {
        IEnumerable<Orders> GetAll();
        Orders GetById(int id);
        Orders Create(Orders order);
        Orders Update(Orders order);
        void Delete(int id);
    }
}
