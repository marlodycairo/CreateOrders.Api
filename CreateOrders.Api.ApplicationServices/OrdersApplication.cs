using AutoMapper;
using CreateOrders.Api.Application;
using CreateOrders.Api.Domain;
using CreateOrders.Api.Domain.Models;
using CreateOrders.Api.Domain.Models.ModelResponse;
using CreateOrders.Api.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreateOrders.Api.ApplicationServices
{
    public class OrdersApplication : IOrdersApplication
    {
        private readonly IOrdersDomain ordersDomain;
        private readonly IMapper mapper;

        public OrdersApplication(IOrdersDomain ordersDomain, IMapper mapper)
        {
            this.ordersDomain = ordersDomain;
            this.mapper = mapper;
        }

        public OrdersViewResponse Create(OrdersViewModel order)
        {
            ordersDomain.GetById(order.Id);

            if (OrderExists(order.Id))
            {
                throw new Exception("El Pedido ya existe.");
            }

            var result = mapper.Map<Orders>(order);
            var products = ordersDomain.Create(result);

            return products;
        }

        public void Delete(int id)
        {
            ordersDomain.Delete(id);
        }

        public IEnumerable<OrdersViewModel> GetAll()
        {
            return ordersDomain.GetAll();
        }

        public OrdersViewModel GetById(int id)
        {
            return ordersDomain.GetById(id);
        }

        public OrdersViewModel Update(OrdersViewModel order)
        {
            return ordersDomain.Update(order);
        }

        private bool OrderExists(int id)
        {
            return ordersDomain.GetAll().Any(p => p.Id == id);
        }
    }
}
