using CreateOrders.Api.Domain.Models;
using CreateOrders.Api.Domain.Models.ModelResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreateOrders.Api.Application
{
    public interface IOrdersApplication
    {
        IEnumerable<OrdersViewModel> GetAll();
        OrdersViewModel GetById(int id);
        OrdersViewResponse Create(OrdersViewModel order);
        OrdersViewModel Update(OrdersViewModel order);
        void Delete(int id);
    }
}
