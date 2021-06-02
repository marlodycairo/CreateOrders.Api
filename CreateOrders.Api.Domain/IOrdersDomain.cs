using CreateOrders.Api.Domain.Models;
using CreateOrders.Api.Domain.Models.ModelResponse;
using CreateOrders.Api.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreateOrders.Api.Domain
{
    public interface IOrdersDomain
    {
        IEnumerable<OrdersViewModel> GetAll();
        OrdersViewModel GetById(int id);
        OrdersViewResponse Create(Orders order);
        OrdersViewModel Update(OrdersViewModel order);
        void Delete(int id);
    }
}
