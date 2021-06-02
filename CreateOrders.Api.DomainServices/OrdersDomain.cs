using AutoMapper;
using CreateOrders.Api.Domain;
using CreateOrders.Api.Domain.Models;
using CreateOrders.Api.Domain.Models.ModelResponse;
using CreateOrders.Api.Infrastructure.Entities;
using CreateOrders.Api.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreateOrders.Api.DomainServices
{
    public class OrdersDomain : IOrdersDomain
    {
        private readonly IOrdersRepository ordersRepository;
        private readonly IMapper mapper;

        public OrdersDomain(IOrdersRepository ordersRepository, IMapper mapper)
        {
            this.ordersRepository = ordersRepository;
            this.mapper = mapper;
        }

        public OrdersViewResponse Create(Orders order)
        {
            ordersRepository.Create(order);

            var result = mapper.Map<OrdersViewResponse>(order);

            return result;
        }

        public void Delete(int id)
        {
            ordersRepository.Delete(id);
        }

        public IEnumerable<OrdersViewModel> GetAll()
        {
            var orders = ordersRepository.GetAll();

            var result = mapper.Map<IEnumerable<OrdersViewModel>>(orders);

            return result;
        }

        public OrdersViewModel GetById(int id)
        {
            var order = ordersRepository.GetById(id);
            var result = mapper.Map<OrdersViewModel>(order);

            return result;
        }

        public OrdersViewModel Update(OrdersViewModel orderModel)
        {
            var orders = mapper.Map<Orders>(orderModel);

            ordersRepository.Update(orders);

            return orderModel;
        }
    }
}
