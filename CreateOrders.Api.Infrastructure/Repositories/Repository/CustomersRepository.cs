using CreateOrders.Api.Infrastructure.Context;
using CreateOrders.Api.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreateOrders.Api.Infrastructure.Repositories.Repository
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly ApplicationDbContext context;

        public CustomersRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Customers Create(Customers customer)
        {
            context.Customers.Add(customer);
            context.SaveChanges();

            return customer;
        }

        public void Delete(int id)
        {
            var customer = context.Customers.FirstOrDefault(p => p.Id ==id);
            context.Remove(customer);
            context.SaveChanges();
        }

        public IEnumerable<Customers> GetAll()
        {
            return context.Customers.ToList();
        }

        public Customers GetById(int id)
        {
            return context.Customers.Find(id);
        }

        public Customers Update(Customers customer)
        {
            context.Entry(customer).State = EntityState.Modified;
            context.SaveChanges();

            return customer;
        }
    }
}
