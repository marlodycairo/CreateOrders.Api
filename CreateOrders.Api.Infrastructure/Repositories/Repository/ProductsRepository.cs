using CreateOrders.Api.Infrastructure.Context;
using CreateOrders.Api.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreateOrders.Api.Infrastructure.Repositories.Repository
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ApplicationDbContext context;

        public ProductsRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Products Create(Products product)
        {
            context.Products.Add(product);
            context.SaveChanges();

            return product;
        }

        public void Delete(int id)
        {
            var product = context.Products.FirstOrDefault(p => p.Id == id);
            context.Remove(product);
            context.SaveChanges();
        }

        public IEnumerable<Products> GetAll()
        {
            return context.Products.ToList();
        }

        public Products GetById(int id)
        {
            return context.Products.Find(id);
        }

        public Products Update(Products product)
        {
            context.Entry(product).State = EntityState.Modified;
            context.SaveChanges();

            return product;
        }
    }
}
