using CreateOrders.Api.Infrastructure.Context;
using CreateOrders.Api.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreateOrders.Api.Infrastructure.Repositories.Repository
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly ApplicationDbContext context;

        public OrdersRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Orders Create(Orders order)
        {
            context.Orders.Add(order);
            context.SaveChanges();

            return order;
        }

        public void Delete(int id)
        {
            var order = context.Orders.FirstOrDefault(p => p.Id == id);
            context.Remove(order);
            context.SaveChanges();
        }

        public IEnumerable<Orders> GetAll()
        {
            return context.Orders.ToList();
        }

        public Orders GetById(int id)
        {
            return context.Orders.Find(id);
        }

        public Orders Update(Orders order)
        {
            context.Entry(order).State = EntityState.Modified;
            context.SaveChanges();

            return order;
        }
    }
}
